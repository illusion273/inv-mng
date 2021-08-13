using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app3rework.Forms
{
    public partial class Inventory : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");
        
        private readonly string partialQuery =
            "select ppr.ProductID, ppr.Name, ppr.ProductNumber " +
            "from Production.Product ppr " +
            "join Production.ProductInventory ppi " +
            "on ppr.ProductID = ppi.ProductID " +
            "where ppr.SellEndDate is null " +
            "group by ppr.productid, ppr.name,ppr.productnumber " +
            "order by ppr.ProductID";
        private string query;
        public bool identfier = false;

        public static int ProdID { get; set; }
        public static string ProdName { get; set; }
        public static Panel PanelContainer { get; set; }
        public static DataGridView GridInventory { get; set; }

        public Inventory()
        {
            InitializeComponent();
            GetProducts();
            PanelContainer = panelContainer;
            GridInventory = gridInventory;
        }

        private void GetProducts()
        {
            query = partialQuery;
            this.gridInventory.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
        }

        private void btn_inv_scan_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            { panel1.Visible = false; }
            else if (panel1.Visible == false)
            { panel1.Visible = true; }
        }

        private void btn_byProd_Click(object sender, EventArgs e)
        {
            query =
                "select ppr.ProductID, ppr.Name, SUM(ppi.Quantity) As Quantity " +
                "from Production.ProductInventory ppi " +
                "join Production.Product ppr " +
                "on ppi.ProductID = ppr.ProductID " +
                "where ppr.SellEndDate is null " +
                "group by ppr.ProductID, ppr.Name";
            this.gridInventory.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
        }

        private void btn_byLocID_Click(object sender, EventArgs e)
        {
            query =
                "select ppi.LocationID,pl.Name, sum(Quantity) from Production.ProductInventory ppi " +
                "join Production.Location pl on ppi.LocationID = pl.LocationID " +
                "group by ppi.LocationID,pl.Name";
            this.gridInventory.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
        }

        private void btn_workOrder_Click(object sender, EventArgs e)
        {
            this.gridInventory.DataSource = null;
            string uponOrderQuery = "select p.ProductID,Name,ProductNumber from Production.Product p " +
                                    "left join Production.ProductInventory pp " +
                                    "on p.productID = pp.ProductID  where MakeFlag = 1 and p.SellEndDate is null " +
                                    "group by p.ProductID, Name, ProductNumber";
            Classes.SQLConnection.ReadDataFillGrid(uponOrderQuery, this.gridInventory);
        }

        private void btn_inv_restock_Click(object sender, EventArgs e)
        {
            int employeeNumber = Core.Login.UserID;
            {
                query =
                 "WITH " +
                 "cte1 AS " +
                 "(select ppr.MakeFlag,ppr.ProductID, ppi.LocationID, ppi.Quantity, ppr.ReorderPoint, ppr.SafetyStockLevel " +
                 "from Production.Product ppr " +
                 "join Production.ProductInventory ppi " +
                 "on ppr.ProductID = ppi.ProductID), " +
                 "cte2 AS " +
                 "(select ProductID, MIN(Quantity) As MinQuantity, SUM(Quantity) As TotalQuantity " +
                 "from cte1 " +
                 "group by ProductID) " +
                 "select cte1.ProductID, MIN(cte1.LocationID) As LocationID, cte2.MinQuantity, cte2.TotalQuantity, cte1.ReorderPoint, cte1.SafetyStockLevel, cte1.MakeFlag " +
                 "from cte1 " +
                 "join cte2 " +
                 "on cte1.ProductID = cte2.ProductID " +
                 "where cte1.Quantity = cte2.MinQuantity " +
                 "group by cte1.ProductID, cte2.MinQuantity, cte2.TotalQuantity, cte1.ReorderPoint, cte1.SafetyStockLevel,cte1.MakeFlag ";

                SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dtbl2 = new DataTable();
                conn.Open();
                adapter.Fill(dtbl2);
                conn.Close();


                int productID, locationID, minQuantity, totalQuantity, reorderPoint, safetyStockLevel;
                int numToOrder = 0;
                var values = new List<Tuple<int, int>>();
                var makevalues = new List<Tuple<int, int>>();

                foreach (DataRow row in dtbl2.Rows)
                {


                    productID = int.Parse(row["ProductID"].ToString());
                    locationID = int.Parse(row["locationID"].ToString());
                    minQuantity = int.Parse(row["minQuantity"].ToString());
                    totalQuantity = int.Parse(row["totalQuantity"].ToString());
                    reorderPoint = int.Parse(row["reorderPoint"].ToString());
                    safetyStockLevel = int.Parse(row["safetyStockLevel"].ToString());

                    if (!bool.Parse(row["MakeFlag"].ToString()))
                    {
                        if (totalQuantity < safetyStockLevel)
                        {
                            numToOrder = safetyStockLevel - totalQuantity;
                            values.Add(Tuple.Create(productID, numToOrder));
                        }
                    }
                    else
                    {
                        if (totalQuantity < safetyStockLevel)
                        {
                            numToOrder = safetyStockLevel - totalQuantity;
                            makevalues.Add(Tuple.Create(productID, numToOrder));


                        }
                    }
                }
                DialogResult result = MessageBox.Show($"{values.Count + makevalues.Count} products will be added to Purchase List. Are you sure? ", "Confirm ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlCommand command;
                    foreach (Tuple<int, int> make in makevalues)
                    {
                        string quickorder = "insert into PurchaseList " +
                                   $"values(1700, {make.Item1}, {make.Item2} , 0)";
                        command = new SqlCommand(quickorder, conn);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    identfier = false;
                    foreach (Tuple<int, int> value in values)
                    {
                        int emplid = Core.Login.UserID;
                        string query2 =
                        "select max(pv.BusinessEntityID) from Purchasing.ProductVendor ppv " +
                        "join Purchasing.Vendor pv on ppv.BusinessEntityID = pv.BusinessEntityID " +
                        $"where ProductID = {value.Item1} and pv.ActiveFlag = 1";
                        int vendorID = 0;
                        double unitPrice = 0;
                        SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                        command = new SqlCommand(query2, myConnection);
                        myConnection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            vendorID = int.Parse(reader.GetValue(0).ToString());
                        }
                        reader.Close();
                        string stdprice = $"select StandardPrice from Purchasing.ProductVendor where ProductID = {value.Item1} and BusinessEntityID = {vendorID}";
                        command = new SqlCommand(stdprice, myConnection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            unitPrice = double.Parse(reader.GetValue(0).ToString());
                        }
                        reader.Close();
                        string quickorder = "insert into PurchaseList " +
                               $"values({vendorID}, {value.Item1}, {value.Item2} , {unitPrice.ToString()})";
                        command = new SqlCommand(quickorder, conn);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    var purchaselistform = Application.OpenForms["PurchaseList"];
                    if (purchaselistform == null)
                    {
                        var purchaselist = new Forms.PurchaseList();
                        purchaselist.TopLevel = true;
                        purchaselist.TopMost = false;
                        purchaselist.Show();
                    }
                    else
                    {
                        purchaselistform.Dispose();
                        purchaselistform.Close();
                        var purchaselist = new Forms.PurchaseList();
                        purchaselist.TopLevel = true;
                        purchaselist.TopMost = false;
                        purchaselist.Show();
                    }
                    MessageBox.Show($"{values.Count + makevalues.Count} products were added to List");
                }
                else
                {
                    MessageBox.Show($"{values.Count + makevalues.Count} products were NOT added to List");
                }
            }
        }

        private void btn_inv_reorder_Click(object sender, EventArgs e)
        {
            int employeeNumber = Core.Login.UserID;

            query =
                "WITH " +
                "cte1 AS " +
                "(select ppr.MakeFlag,ppr.ProductID, ppi.LocationID, ppi.Quantity, ppr.ReorderPoint, ppr.SafetyStockLevel " +
                "from Production.Product ppr " +
                "join Production.ProductInventory ppi " +
                "on ppr.ProductID = ppi.ProductID), " +
                "cte2 AS " +
                "(select ProductID, MIN(Quantity) As MinQuantity, SUM(Quantity) As TotalQuantity " +
                "from cte1 " +
                "group by ProductID) " +
                "select cte1.ProductID, MIN(cte1.LocationID) As LocationID, cte2.MinQuantity, cte2.TotalQuantity, cte1.ReorderPoint, cte1.SafetyStockLevel, cte1.MakeFlag " +
                "from cte1 " +
                "join cte2 " +
                "on cte1.ProductID = cte2.ProductID " +
                "where cte1.Quantity = cte2.MinQuantity " +
                "group by cte1.ProductID, cte2.MinQuantity, cte2.TotalQuantity, cte1.ReorderPoint, cte1.SafetyStockLevel,cte1.MakeFlag ";

            SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dtbl2 = new DataTable();
            conn.Open();
            adapter.Fill(dtbl2);
            conn.Close();

            int productID, locationID, minQuantity, totalQuantity, reorderPoint, safetyStockLevel;
            int numToOrder = 0;
            var values = new List<Tuple<int, int>>();
            var makevalues = new List<Tuple<int, int>>();

            foreach (DataRow row in dtbl2.Rows)
            {
                productID = int.Parse(row["ProductID"].ToString());
                locationID = int.Parse(row["locationID"].ToString());
                minQuantity = int.Parse(row["minQuantity"].ToString());
                totalQuantity = int.Parse(row["totalQuantity"].ToString());
                reorderPoint = int.Parse(row["reorderPoint"].ToString());
                safetyStockLevel = int.Parse(row["safetyStockLevel"].ToString());

                if (!bool.Parse(row["MakeFlag"].ToString()))
                {
                    if (totalQuantity < reorderPoint)
                    {
                        numToOrder = safetyStockLevel - totalQuantity;
                        values.Add(Tuple.Create(productID, numToOrder));
                    }
                }
                else
                {
                    if (totalQuantity < reorderPoint)
                    {
                        numToOrder = safetyStockLevel - totalQuantity;
                        makevalues.Add(Tuple.Create(productID, numToOrder));
                    }
                }
            }
            DialogResult result = MessageBox.Show($"{values.Count + makevalues.Count} products will be added to Purchase List. Are you sure? ", "Confirm ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlCommand command;
                foreach (Tuple<int, int> make in makevalues)
                {
                    string quickorder = "insert into PurchaseList " +
                                $"values(1700, {make.Item1}, {make.Item2} , 0)";
                    command = new SqlCommand(quickorder, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                identfier = false;
                foreach (Tuple<int, int> value in values)
                {
                    int emplid = Core.Login.UserID;
                    string query2 =
                    "select max(pv.BusinessEntityID) from Purchasing.ProductVendor ppv " +
                    "join Purchasing.Vendor pv on ppv.BusinessEntityID = pv.BusinessEntityID " +
                    $"where ProductID = {value.Item1} and pv.ActiveFlag = 1";
                    int vendorID = 0;
                    double unitPrice = 0;
                    SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                    command = new SqlCommand(query2, myConnection);
                    myConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        vendorID = int.Parse(reader.GetValue(0).ToString());
                    }
                    reader.Close();
                    string stdprice = $"select StandardPrice from Purchasing.ProductVendor where ProductID = {value.Item1} and BusinessEntityID = {vendorID}";
                    command = new SqlCommand(stdprice, myConnection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        unitPrice = double.Parse(reader.GetValue(0).ToString());
                    }
                    reader.Close();
                    string quickorder = "insert into PurchaseList " +
                            $"values({vendorID}, {value.Item1}, {value.Item2} , {unitPrice.ToString()})";
                    command = new SqlCommand(quickorder, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                var purchaselistform = Application.OpenForms["PurchaseList"];
                if (purchaselistform == null)
                {
                    var purchaselist = new Forms.PurchaseList();
                    purchaselist.TopLevel = true;
                    purchaselist.TopMost = false;
                    purchaselist.Show();
                }
                else
                {
                    purchaselistform.Dispose();
                    purchaselistform.Close();
                    var purchaselist = new Forms.PurchaseList();
                    purchaselist.TopLevel = true;
                    purchaselist.TopMost = false;
                    purchaselist.Show();
                }
                MessageBox.Show($"{values.Count + makevalues.Count} products were added to List");
            }
            else
            {
                MessageBox.Show($"{values.Count + makevalues.Count} products were NOT added to List");
            }
        }

        private void btn_purchaseList_Click(object sender, EventArgs e)
        {
            var purchaselistform = Application.OpenForms["PurchaseList"];
            if (purchaselistform == null)
            {
                var purchaselist = new Forms.PurchaseList();
                purchaselist.TopLevel = true;
                purchaselist.TopMost = false;
                purchaselist.Show();
            }
            else
            {
                purchaselistform.Dispose();
                purchaselistform.Close();
                var purchaselist = new Forms.PurchaseList();
                purchaselist.TopLevel = true;
                purchaselist.TopMost = false;
                purchaselist.Show();
            }
        }

        private void btn_inv_filter_search_Click(object sender, EventArgs e)
        {
            string partialQuery1 = "select ppr.ProductID, ppr.Name, ppr.ProductNumber " +
            "from Production.Product ppr " +
            "join Production.ProductInventory ppi " +
            "on ppr.ProductID = ppi.ProductID";
            string key;
            string input = txt_filter.Text;
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a filter.");
            }
            else if (txt_filter.Text == "")
            {
                MessageBox.Show("Please enter a value.");
            }
            else
            {
                this.gridInventory.DataSource = null;
                key = comboBox1.SelectedItem.ToString();
                switch (key)
                {
                    case "By Name":
                        {
                            query = $"{partialQuery1} where Name LIKE '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
                            break;
                        }
                    case "By ProductID":
                        {
                            query = $"{partialQuery1} where ppr.ProductID like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
                            break;
                        }

                    case "Quantity >=":
                        {
                            query = $"{partialQuery1} where ppi.Quantity >= '{input.Replace("'", "''")}'";
                            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
                            break;
                        }
                    case "Quantity <=":
                        {
                            query = $"{partialQuery1} where ppi.Quantity <= '{input.Replace("'", "''")}'";
                            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
                            break;
                        }
                    case "Location":
                        {
                            query = $"{partialQuery1} where ppi.LocationID = {input.Replace("'", "''")}";
                            Classes.SQLConnection.ReadDataFillGrid(query, this.gridInventory);
                            break;
                        }
                }
            }
        }

        private void gridInventory_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            ProdID = int.Parse(this.gridInventory.CurrentRow.Cells[0].Value.ToString());
            ProdName = this.gridInventory.CurrentRow.Cells[1].Value.ToString();
            this.panelContainer.Controls.Clear();
            var pInfo = new Forms.ProfileProduct();
            pInfo.TopLevel = false;
            pInfo.TopMost = true;
            pInfo.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(pInfo);
            this.panelContainer.Visible = true;
            pInfo.Show();
        }

        private void btn_inv_showAll_Click(object sender, EventArgs e)
        {
            GetProducts();
        }
    }
}
