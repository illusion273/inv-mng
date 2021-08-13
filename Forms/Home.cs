using app3rework.Classes;
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
    public partial class Home : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        public static int CidToPass { get; set; }
        public static int KeyToPass { get; set; }
        public static int SohID { get; set; }
        public static int PohID { get; set; }
        public static string SavedQ { get; set; }
        public static string PurchaseQ { get; set; }
        public static string SaleQ { get; set; }
        public static DataGridView SavedGrid { get; set; }
        public static DataGridView OrderGrid { get; set; }
        public static Panel PanelSaleEdit { get; set; }
        public static Panel PanelPurchaseEdit { get; set; }

        public Home()
        {
            InitializeComponent();

            OnStartCheck();
            showSalesProgress();
            GetScrapReason();
            InitForAccess();
        }

        private void InitForAccess()
        {
            SavedQ = "select CustomerID,FullName, CrrOrder,max(DATEADD(MINUTE, DATEDIFF(MINUTE, 0, date), 0)) as Date from SavedOrderHeader group by CustomerID,FullName,CrrOrder order by CustomerID";
            PurchaseQ = "select poh.PurchaseOrderID, " +
                                " poh.Status, poh.EmployeeID, poh.VendorID, " +
                                "poh.OrderDate from Purchasing.PurchaseOrderHeader poh " +
                                "where poh.Status = 1 " +
                                "order by poh.OrderDate desc";
            SaleQ = "SELECT soh.SalesOrderID, soh.customerID,CONCAT(per.FirstName + ' ', per.MiddleName + ' ', per.LastName) AS FullName, " +
                "soh.SalesOrderNumber,soh.PurchaseOrderNumber,soh.Status, soh.OrderDate,soh.DueDate,soh.ShipDate, " +
                "  soh.TotalDue " +
                "FROM Sales.SalesOrderHeader soh " +
                "JOIN sales.Customer SC " +
                "on soh.CustomerID = sc.CustomerID " +
                "join Person.Person per " +
                "ON SC.PersonID = per.BusinessEntityID " +
                "full outer join Sales.Store SST " +
                "ON SC.StoreID = SST.BusinessEntityID " +
                "WHERE SalesOrderID IS NOT NULL and soh.Status < 5";
            SavedGrid = this.dataGridView3;
            OrderGrid = this.dataGridView1;
            PanelSaleEdit = this.panel_sales_edit;
            PanelPurchaseEdit = this.panel_right_options;
        }

        private void OnStartCheck()
        {
            this.dataGridView3.DataSource = null;
            string query = "select CustomerID,FullName, CrrOrder,max(DATEADD(MINUTE, DATEDIFF(MINUTE, 0, date), 0)) as Date from SavedOrderHeader group by CustomerID,FullName,CrrOrder order by CustomerID";
            string savedQuery = query;
            SqlConnection conn2 = new SqlConnection(SQLConnection.connectionString);
            String InitQuery = "Select * from Purchasing.Vendor where BusinessEntityID = 1700";
            SqlCommand command = new SqlCommand(InitQuery, conn2);
            conn2.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                conn2.Close();
                MessageBox.Show("The Database will be adjusted to the program needs.");
                AdjustDB();
            }
            else
            {
                reader.Close();
                conn2.Close();
                SQLConnection.ReadDataFillGrid(savedQuery, this.dataGridView3);
            }
        }

        public void showSalesProgress()
        {
            this.panel_right_options.Controls.Clear();
            this.panel_right_options.Visible = false;
            this.panel_sales_edit.Controls.Clear();
            this.panel_sales_edit.Visible = false;
            string sales = "SELECT soh.SalesOrderID, soh.customerID,CONCAT(per.FirstName + ' ', per.MiddleName + ' ', per.LastName) AS FullName, " +
                "soh.SalesOrderNumber,soh.PurchaseOrderNumber,soh.Status, soh.OrderDate,soh.DueDate,soh.ShipDate, " +
                "  soh.TotalDue " +
                "FROM Sales.SalesOrderHeader soh " +
                "JOIN sales.Customer SC " +
                "on soh.CustomerID = sc.CustomerID " +
                "join Person.Person per " +
                "ON SC.PersonID = per.BusinessEntityID " +
                "full outer join Sales.Store SST " +
                "ON SC.StoreID = SST.BusinessEntityID " +
                "WHERE SalesOrderID IS NOT NULL and soh.Status < 5";
            this.dataGridView1.DataSource = null;
            SQLConnection.ReadDataFillGrid(sales, this.dataGridView1);
        }

        public void showPurchaseProgress()
        {
            this.panel_right_options.Controls.Clear();
            this.panel_right_options.Visible = false;
            this.panel_sales_edit.Controls.Clear();
            this.panel_sales_edit.Visible = false;
            string purchases = "select poh.PurchaseOrderID, " +
                                " poh.Status, poh.EmployeeID, poh.VendorID, " +
                                "poh.OrderDate from Purchasing.PurchaseOrderHeader poh " +
                                "where poh.Status = 1 " +
                                "order by poh.OrderDate desc";
            this.dataGridView1.DataSource = null;
            SQLConnection.ReadDataFillGrid(purchases, this.dataGridView1);
        }

        public void showSavedOrders()
        {
            string query = "select CustomerID,FullName, CrrOrder,max(DATEADD(MINUTE, DATEDIFF(MINUTE, 0, date), 0)) as Date from SavedOrderHeader group by CustomerID,FullName,CrrOrder order by CustomerID";
            this.dataGridView3.DataSource = null;
            SQLConnection.ReadDataFillGrid(query, this.dataGridView3);
        }

        private void GetScrapReason()
        {
            ScrapReason.Items.Add("Cancelled");
            ScrapReason.Items.Add("OK");
            SqlConnection conn2 = new SqlConnection(SQLConnection.connectionString);
            string Scrap = "Select Name from Production.ScrapReason";
            SqlCommand command = new SqlCommand(Scrap, conn2);
            SqlDataReader reader;
            conn2.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ScrapReason.Items.Add(reader.GetValue(0));
            }
            reader.Close();
            conn2.Close();
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var form = Application.OpenForms["NewSale"];
            if (form == null)
            {
                CidToPass = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                KeyToPass = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                var opensaved = new Forms.NewSale();
                opensaved.TopLevel = true;
                opensaved.TopMost = false;
                opensaved.OpenSavedOrder();
                opensaved.Show();
            }
            else
            {
                form.Dispose();
                form.Close();
                CidToPass = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                KeyToPass = int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                var opensaved = new Forms.NewSale();
                opensaved.TopLevel = true;
                opensaved.TopMost = false;
                opensaved.OpenSavedOrder();
                opensaved.Show();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            string gridCheck = this.dataGridView1.Columns[0].HeaderText;
            if (gridCheck == "PurchaseOrderID")
            {
                var form = Application.OpenForms["EditPurchase"];
                if (form == null)
                {
                    this.panel_right_options.Visible = true;
                    PohID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    this.panel_right_options.Controls.Clear();
                    var detailed = new Forms.EditPurchase();
                    detailed.TopLevel = false;
                    detailed.TopMost = true;
                    detailed.Dock = DockStyle.Fill;
                    this.panel_right_options.Controls.Add(detailed);
                    this.panel_right_options.Visible = true;
                    detailed.Show();
                }
                else
                {
                    form.Dispose();
                    form.Close();
                    this.panel_right_options.Visible = true;
                    PohID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    this.panel_right_options.Controls.Clear();
                    var detailed = new Forms.EditPurchase();
                    detailed.TopLevel = false;
                    detailed.TopMost = true;
                    detailed.Dock = DockStyle.Fill;
                    this.panel_right_options.Controls.Add(detailed);
                    this.panel_right_options.Visible = true;
                    detailed.Show();
                }
            }
            else if (gridCheck == "SalesOrderID")
            {
                var form = Application.OpenForms["EditSale"];
                if (form == null)
                {
                    this.panel_sales_edit.Visible = true;
                    SohID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    this.panel_sales_edit.Controls.Clear();
                    var saleEdit = new Forms.EditSale();
                    saleEdit.TopLevel = false;
                    saleEdit.TopMost = true;
                    saleEdit.Dock = DockStyle.Fill;
                    this.panel_sales_edit.Controls.Add(saleEdit);
                    this.panel_sales_edit.Visible = true;
                    saleEdit.Show();
                }
                else
                {
                    form.Dispose();
                    form.Close();
                    this.panel_sales_edit.Visible = true;
                    SohID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    this.panel_sales_edit.Controls.Clear();
                    var saleEdit = new Forms.EditSale();
                    saleEdit.TopLevel = false;
                    saleEdit.TopMost = true;
                    saleEdit.Dock = DockStyle.Fill;
                    this.panel_sales_edit.Controls.Add(saleEdit);
                    this.panel_sales_edit.Visible = true;
                    saleEdit.Show();
                }
            }
        }

        private void showWorkOrders()
        {
            this.panel_right_options.Controls.Clear();
            this.panel_right_options.Visible = false;
            this.panel_sales_edit.Controls.Clear();
            this.panel_sales_edit.Visible = false;
            string sales = "select WorkOrderID,ProductID,OrderQty,ScrappedQty,StartDate,DueDate from Production.WorkOrder where EndDate is null";
            this.dataGridView2.DataSource = null;
            this.dataGridView1.DataSource = null;
            SQLConnection.ReadDataFillGrid(sales, this.dataGridView2);
            this.dataGridView2.Columns[0].Width = 150;
            this.dataGridView2.Columns[1].Width = 60;
            this.dataGridView2.Columns[2].ReadOnly = true;
            this.dataGridView2.Columns[3].ReadOnly = true;
            this.dataGridView2.Columns[4].ReadOnly = true;
            this.dataGridView2.Columns[6].ReadOnly = true;
            this.dataGridView2.Columns[7].ReadOnly = true;
        }

        private void AdjustDB()
        {
            string initDBQuery = "update Purchasing.PurchaseOrderHeader set status = 4 where OrderDate < GETDATE() - 365 " +
                                        "create table SavedOrderHeader " +
                                        "(OrderID int not null identity(1, 1) primary key, " +
                                        "CustomerID int not null, " +
                                        "FullName varchar(50) not null, " +
                                        "ProdID int not null, " +
                                        "Qty int not null, " +
                                        "CrrOrder int not null, " +
                                        "date datetime not null) " +
                                        "insert into Purchasing.Vendor " +
                                        "values(1700, 'WORK', 'ORDER', 5, 0, 0, null, getdate()) " +
                                        "create table PurchaseList " +
                                        "(ListID int not null identity(1, 1) primary key, " +
                                        "VendorID int not null, " +
                                        "ProdID int not null, " +
                                        "Qty int not null, " +
                                        "StdPrice money not null) " +
                                        "insert into Purchasing.Vendor " +
                                        "values(1699, 'INACTIVE', 'TempInactive', 5, 0, 0, null, getdate())";
            SqlConnection conn2 = new SqlConnection(SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(initDBQuery, conn2);
            conn2.Open();
            command.ExecuteNonQuery();
            conn2.Close();
            MessageBox.Show("DB Initialized Successfully");
            string query = "select CustomerID,FullName, CrrOrder,max(DATEADD(MINUTE, DATEDIFF(MINUTE, 0, date), 0)) as Date from SavedOrderHeader group by CustomerID,FullName,CrrOrder order by CustomerID";
            SQLConnection.ReadDataFillGrid(query, this.dataGridView3);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var senderGrid = (DataGridView)sender;
            int rowcount = dataGridView1.RowCount;
            int scrapQty = 0;
            int WoID = 0;
            int scrapID = 0;
            int locid = 0;
            int prevQty = 0;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 1)
            {
                if (dataGridView2.CurrentRow.Cells[0].Value is null)
                {
                    MessageBox.Show("Select an option from the drop down box");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("End work order?", "Confirm", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == "OK")
                        {
                            WoID = int.Parse(this.dataGridView2.CurrentRow.Cells[2].Value.ToString());
                            SqlConnection conn = new SqlConnection(SQLConnection.connectionString);
                            string WorkQuery = $"update Production.WorkOrder set ScrappedQty = 0, EndDate = GETDATE(),ModifiedDate = GETDATE(),ScrapReasonID = null where WorkOrderID = {WoID}";
                            SqlCommand command = new SqlCommand(WorkQuery, conn);

                            conn.Open();
                            command.ExecuteNonQuery();
                            conn.Close();
                            string LocAndQty = "WITH " +
                                                  "cte1 AS " +
                                                  "(select ppr.ProductID, ppi.LocationID, ppi.Quantity, ppr.ReorderPoint, ppr.SafetyStockLevel " +
                                                  "from Production.Product ppr " +
                                                  "join Production.ProductInventory ppi " +
                                                  "on ppr.ProductID = ppi.ProductID),  " +
                                                  "cte2 As " +
                                                  "(select ProductID, MIN(Quantity) As MinQuantity, SUM(Quantity) As TotalQuantity " +
                                                  "from cte1 " +
                                                  "group by ProductID) " +
                                                  "select MIN(cte1.LocationID) As LocationID, cte2.MinQuantity " +
                                                  "from cte1 " +
                                                  "join cte2 " +
                                                  "on cte1.ProductID = cte2.ProductID " +
                                                  $"where cte1.Quantity = cte2.MinQuantity and cte1.ProductID = {dataGridView2.CurrentRow.Cells[3].Value} " +
                                                  "group by cte2.MinQuantity";
                            conn.Open();
                            command = new SqlCommand(LocAndQty, conn);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                locid = int.Parse(reader.GetValue(0).ToString());
                                prevQty = int.Parse(reader.GetValue(1).ToString());
                            }
                            reader.Close();
                            conn.Close();
                            prevQty += int.Parse(this.dataGridView2.CurrentRow.Cells[4].Value.ToString());
                            string updateInv = $"update production.productInventory set Quantity = {prevQty} where ProductId = {dataGridView2.CurrentRow.Cells[3].Value} and LocationID = {locid} ";
                            command = new SqlCommand(updateInv, conn);
                            conn.Open();
                            command.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Work order Completed");
                        }
                        else if (dataGridView2.CurrentRow.Cells[0].Value.ToString() == "Cancelled")
                        {
                            scrapQty = int.Parse(this.dataGridView2.CurrentRow.Cells[4].Value.ToString());
                            WoID = int.Parse(this.dataGridView2.CurrentRow.Cells[2].Value.ToString());
                            string updWo = $"update Production.WorkOrder set ScrappedQty = {scrapQty}, EndDate = GETDATE(),ModifiedDate = GETDATE() where WorkOrderID = {WoID}";
                            SqlConnection conn = new SqlConnection(SQLConnection.connectionString);
                            SqlCommand command = new SqlCommand(updWo, conn);
                            conn.Open();
                            command.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Work order Cancelled");
                        }
                        else
                        {
                            string scrapQuery = $"select ScrapReasonID from Production.ScrapReason where Name Like'%{dataGridView2.CurrentRow.Cells[0].Value.ToString()}%'";
                            SqlConnection conn2 = new SqlConnection(SQLConnection.connectionString);
                            SqlCommand command = new SqlCommand(scrapQuery, conn2);
                            conn2.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                scrapID = int.Parse(reader.GetValue(0).ToString());
                            }
                            reader.Close();
                            conn2.Close();
                            scrapQty = int.Parse(this.dataGridView2.CurrentRow.Cells[5].Value.ToString());
                            WoID = int.Parse(this.dataGridView2.CurrentRow.Cells[2].Value.ToString());
                            string WorkQuery = $"update Production.WorkOrder set ScrappedQty = {scrapQty}, EndDate = GETDATE(),ModifiedDate = GETDATE(),ScrapReasonID = {scrapID} where WorkOrderID = {WoID}";
                            command = new SqlCommand(WorkQuery, conn2);
                            conn2.Open();
                            command.ExecuteNonQuery();
                            conn2.Close();
                            string LocAndQty = "WITH " +
                                                  "cte1 AS " +
                                                  "(select ppr.ProductID, ppi.LocationID, ppi.Quantity, ppr.ReorderPoint, ppr.SafetyStockLevel " +
                                                  "from Production.Product ppr " +
                                                  "join Production.ProductInventory ppi " +
                                                  "on ppr.ProductID = ppi.ProductID),  " +
                                                  "cte2 As " +
                                                  "(select ProductID, MIN(Quantity) As MinQuantity, SUM(Quantity) As TotalQuantity " +
                                                  "from cte1 " +
                                                  "group by ProductID) " +
                                                  "select MIN(cte1.LocationID) As LocationID, cte2.MinQuantity " +
                                                  "from cte1 " +
                                                  "join cte2 " +
                                                  "on cte1.ProductID = cte2.ProductID " +
                                                  $"where cte1.Quantity = cte2.MinQuantity and cte1.ProductID = {dataGridView2.CurrentRow.Cells[3].Value} " +
                                                  "group by cte2.MinQuantity";
                            conn2.Open();
                            command = new SqlCommand(LocAndQty, conn2);
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                locid = int.Parse(reader.GetValue(0).ToString());
                                prevQty = int.Parse(reader.GetValue(1).ToString());
                            }
                            reader.Close();
                            conn2.Close();
                            prevQty = prevQty + int.Parse(this.dataGridView2.CurrentRow.Cells[4].Value.ToString()) - scrapQty;
                            string updateInv = $"update production.productInventory set Quantity = {prevQty} where ProductId = {dataGridView2.CurrentRow.Cells[3].Value} and LocationID = {locid} ";
                            command = new SqlCommand(updateInv, conn2);
                            conn2.Open();
                            command.ExecuteNonQuery();
                            conn2.Close();


                            MessageBox.Show("Work order Complete");
                        }
                        showWorkOrders();
                    }
                }
            }
        }

        private void btn_salesinprogress_Click(object sender, EventArgs e)
        {
            this.dataGridView3.Visible = false;
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Visible = false;
            this.dataGridView1.Visible = true;
            var form = Application.OpenForms["EditOrderStatus"];
            var form2 = Application.OpenForms["EditSaleOrderStatus"];
            if (form != null)
            { form.Dispose(); form.Close(); }
            if (form2 != null)
            { form2.Dispose(); form2.Close(); }
            showSalesProgress();
            lbl_grid_descr.Text = "Showing on going sales";
        }

        private void btn_purchaseinprogress_Click(object sender, EventArgs e)
        {
            this.dataGridView3.Visible = false;
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Visible = false;
            this.dataGridView1.Visible = true;
            var form = Application.OpenForms["EditOrderStatus"];
            var form2 = Application.OpenForms["EditSaleOrderStatus"];
            if (form != null)
            { form.Dispose(); form.Close(); }
            if (form2 != null)
            { form2.Dispose(); form2.Close(); }
            showPurchaseProgress();
            lbl_grid_descr.Text = "Showing on going purchases";
        }

        private void btn_SavedOrders_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            this.dataGridView2.Visible = false;
            this.dataGridView3.Visible = true;
            this.dataGridView3.Dock = DockStyle.Fill;
            var form = Application.OpenForms["EditSale"];
            var form2 = Application.OpenForms["EditPurchase"];
            if (form != null)
            { form.Dispose(); form.Close(); }
            if (form2 != null)
            { form2.Dispose(); form2.Close(); }
            lbl_grid_descr.Text = "Showing saved orders";
            showSavedOrders();
        }

        private void btn_workOrders_Click(object sender, EventArgs e)
        {
            this.dataGridView3.Visible = false;
            this.dataGridView1.Visible = false;
            this.dataGridView2.Visible = true;
            this.dataGridView2.Dock = DockStyle.Fill;
            var form = Application.OpenForms["EditOrderStatus"];
            var form2 = Application.OpenForms["EditSaleOrderStatus"];
            if (form != null)
            { form.Dispose(); form.Close(); }
            if (form2 != null)
            { form2.Dispose(); form2.Close(); }
            lbl_grid_descr.Text = "Showing on going work orders";
            showWorkOrders();
        }

        private void dataGridView3_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            this.dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            this.dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }
    }
}
