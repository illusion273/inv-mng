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
    public partial class NewSale : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        public int var1, var4, newSaved, addressID = 0, NotAvailID = 0, crrOrderSaved;
        public string var2, var3;
        public double notaxcostg = 0, taxcostg = 0;
        public double ShipCostg = 0;

        string shipQuery = "select Name from Purchasing.ShipMethod order by ShipMethodID asc";

        public NewSale()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            txt_qty.Text = "1";
            FillShipCombo();
            comboBox3.SelectedIndex = 0;
        }
        public void showCustomer()
        {
            var1 = Forms.Customers.TransferId;
            var2 = Forms.Customers.TrsfFullname;
            var3 = Forms.Customers.TrsfType;
            var4 = Forms.Customers.TrsfSid;
            newSaved = var1;
            lbl_cid.Text = var1.ToString();
            lbl_fullname.Text = var2.ToString() + " / New Sale";
            fillAddressCombo();
        }

        private void fillAddressCombo()
        {
            string addressQuery = "select AddressID from Person.BusinessEntityAddress pba " +
                                    "join Sales.Customer sc " +
                                    "on pba.BusinessEntityID = sc.StoreID or pba.BusinessEntityID = sc.PersonID " +
                                    $"where CustomerID = {newSaved}";
            SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(addressQuery, myConnection);
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                addressID = int.Parse(reader.GetValue(0).ToString());
            }
            reader.Close();
            string comboAddress = "select AddressLine1,City,PostalCode from Person.Address " +
                                    $"where AddressID = {addressID}";
            command = new SqlCommand(comboAddress, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_address.Text = reader.GetValue(0).ToString();
                lbl_city.Text = reader.GetValue(1).ToString();
                lbl_postal.Text = reader.GetValue(2).ToString();
            }
            reader.Close();
            myConnection.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string selection = comboBox2.SelectedItem.ToString();
            string filterquery;
            {
                filterquery = "select pp.ProductID, pp.Name from Production.Product pp " +
                                "join Production.ProductSubcategory pps " +
                                "on pp.ProductSubcategoryID = pps.ProductSubcategoryID " +
                                "join Production.ProductCategory ppc " +
                                "on pps.ProductCategoryID = ppc.ProductCategoryID " +
                                "join Production.ProductInventory ppi " +
                                "on pp.ProductID = ppi.ProductID " +
                                $"where ppc.Name = '{selection.Replace("'", "''")}' and pp.SellEndDate is null " +
                                "group by pp.ProductID, pp.Name " +
                                "order by pp.Name asc";
                SqlConnection conn2 = new SqlConnection(Classes.SQLConnection.connectionString);
                SqlCommand command = new SqlCommand(filterquery, conn2);
                conn2.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Name"].ToString());
                }
                reader.Close();
                conn2.Close();
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTotalCost();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }

        private void btn_removesaved_Click(object sender, EventArgs e)
        {
            int cid, orderid;
            cid = int.Parse(lbl_cid.Text.ToString());
            orderid = int.Parse(lbl_savedid.Text.ToString());
            DialogResult dialogResult = MessageBox.Show("Remove saved order?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "delete from SavedOrderHeader " +
                                $"where CustomerID = {cid} " +
                                $"and CrrOrder = {orderid}";
                SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                this.Dispose();
                this.Close();
                Classes.SQLConnection.ReadDataFillGrid(Home.SavedQ, Home.SavedGrid);
            }
        }

        private void btn_PlaceOrder_Click(object sender, EventArgs e)
        {
            int rowcount = this.dataGridView1.RowCount;
            if (rowcount == 0)
            {
                MessageBox.Show("Error, empty order");
            }
            else
            {
                int employeeNumber = Core.Login.UserID;
                
                if (ProductAvailability(dataGridView1) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Place order ?", "Confirm", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        double subtotal = notaxcostg;
                        double tax = taxcostg;
                        double freight = ShipCostg;
                        string PO = "";
                        long intPO = 0;

                        int shipmethod = int.Parse(comboBox3.SelectedIndex.ToString());
                        shipmethod++;

                        string maxPO = "select MAX(PurchaseOrderNumber) from sales.SalesOrderHeader";
                        SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                        SqlCommand command = new SqlCommand(maxPO, myConnection);
                        myConnection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            PO = reader.GetValue(0).ToString();
                        }
                        reader.Close();
                        intPO = long.Parse(PO.Remove(0, 2));
                        intPO++;
                        string POinsert = $"insert into Sales.SalesOrderHeader values (1,GETDATE(),GETDATE()+3,GETDATE()+7,1,0,'PO{intPO}',null,{newSaved},{employeeNumber},5,{addressID},{addressID},{shipmethod},null,null,null,{double.Parse(subtotal.ToString(), cultureUS)},{double.Parse(tax.ToString(), cultureUS)},{double.Parse(freight.ToString(), cultureUS)},null,NEWID(),GETDATE())";
                        command = new SqlCommand(POinsert, myConnection);
                        command.ExecuteNonQuery();

                        string getmaxid = "select max(SalesOrderID) from Sales.SalesOrderHeader";
                        int maxid = 0;
                        command = new SqlCommand(getmaxid, myConnection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            maxid = int.Parse(reader.GetValue(0).ToString());
                        }
                        reader.Close();
                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
                        {
                            int prodid = int.Parse(row.Cells[5].Value.ToString());
                            int qty = int.Parse(row.Cells[3].Value.ToString());

                            double unitprice = double.Parse(row.Cells[2].Value.ToString());
                            string detailQuery = $"insert into Sales.SalesOrderDetail values({maxid},null,{qty},{prodid},1,{double.Parse(unitprice.ToString(), cultureUS)},0.00,newid(),getdate())";
                            command = new SqlCommand(detailQuery, myConnection);
                            command.ExecuteNonQuery();
                            UpdateInventory(prodid, qty);
                        }
                        myConnection.Close();
                        MessageBox.Show("Success");
                        this.Dispose();
                        this.Close();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int parseResault;
            bool tryParse = Int32.TryParse(txt_qty.Text.ToString(), out parseResault);
            if (!tryParse)
            {
                txt_qty.Text = "1";
            }
            else
            {
                if (parseResault < 1)
                {
                    txt_qty.Text = "1";
                }
                else
                {
                    parseResault += 1;
                    txt_qty.Text = parseResault.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int parseResault;
            bool tryParse = Int32.TryParse(txt_qty.Text.ToString(), out parseResault);
            if (!tryParse)
            {
                txt_qty.Text = "1";
            }
            else
            {
                if (parseResault <= 1)
                {
                    txt_qty.Text = "1";
                }
                else
                {
                    parseResault -= 1;
                    txt_qty.Text = parseResault.ToString();
                }
            }
        }

        private void btn_SaveOrder_Click(object sender, EventArgs e)
        {
            string FullName = "";
            int PID = 0;
            int rowcount = this.dataGridView1.RowCount;
            if (rowcount == 0)
            {
                MessageBox.Show("Error, empty order");
            }
            else
            {
                int ProdID = 0, qty = 0, key = 0;
                SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                myConnection.Open();
                string maxOrder = "";
                string maxQuery = $"select max(CrrOrder) from SavedOrderHeader where CustomerID = {newSaved}";
                SqlCommand command = new SqlCommand(maxQuery, myConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    maxOrder = reader.GetValue(0).ToString();
                }
                reader.Close();
                string PersonID = $"select PersonID from Sales.Customer where CustomerID = {newSaved}";
                command = new SqlCommand(PersonID, myConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PID = int.Parse(reader.GetValue(0).ToString());
                }
                reader.Close();
                string NameQuery = $"select FirstName,MiddleName,LastName from person.person where BusinessEntityID = {PID}";
                command = new SqlCommand(NameQuery, myConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    FullName = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString();
                }
                reader.Close();
                if (maxOrder == "")
                {
                    foreach (DataGridViewRow datarow in dataGridView1.Rows)
                    {
                        key = 1;
                        ProdID = int.Parse(datarow.Cells[5].Value.ToString());
                        qty = int.Parse(datarow.Cells[3].Value.ToString());
                        string query = $"INSERT INTO SavedOrderHeader values ({newSaved},'{FullName.Replace("'", "''")}',{ProdID},{qty},{key},GETDATE())";
                        command = new SqlCommand(query, myConnection);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    key = int.Parse(maxOrder) + 1;
                    foreach (DataGridViewRow datarow in dataGridView1.Rows)
                    {
                        ProdID = int.Parse(datarow.Cells[5].Value.ToString());
                        qty = int.Parse(datarow.Cells[3].Value.ToString());
                        string query = $"INSERT INTO SavedOrderHeader values ({newSaved},'{FullName.Replace("'", "''")}',{ProdID},{qty},{key},GETDATE())";
                        command = new SqlCommand(query, myConnection);
                        command.ExecuteNonQuery();
                    }
                }
                myConnection.Close();
                //Classes.SQLConnection.ReadDataFillGrid(MainMenuForm.home_hndler.savedQuery, MainMenuForm.home_hndler.savedGrid);
                MessageBox.Show("Order Saved");
                this.Dispose();
                this.Close();
            }
        }

        private void FillShipCombo()
        {
            SqlConnection conn2 = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(shipQuery, conn2);
            conn2.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader["Name"].ToString());
            }
            reader.Close();
            conn2.Close();
        }

        private void btn_AddToGrid_Click(object sender, EventArgs e)
        {
            bool prCheck = false;
            int rowcount = int.Parse(this.dataGridView1.RowCount.ToString());

            if (txt_qty.Text == "")
            {
                MessageBox.Show("Quantity cannot be empty");
            }
            else
            {
                string qty = txt_qty.Text;
                int resault;
                bool tryparse = Int32.TryParse(txt_qty.Text.ToString(), out resault);
                if (resault == 0)
                {
                    MessageBox.Show("Quantity Error");
                }
                else
                {
                    if (comboBox2.SelectedItem == null)
                    {
                        MessageBox.Show("Category Error");
                    }
                    else if (comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Product Error");
                    }
                    else if (Classes.Validations.IntegerValidation(qty) || int.Parse(qty) <= 0)
                    {
                        MessageBox.Show("Quantity Error");
                    }
                    else
                    {
                        string ItemName = comboBox1.SelectedItem.ToString();
                        string ItemQuery = "select ProductNumber, Name , ListPrice, ProductID, WeightUnitMeasureCode, Weight " +
                                       "from Production.Product where Name = '" + ItemName.Replace("'", "''") + "'";
                        SqlConnection conn2 = new SqlConnection(Classes.SQLConnection.connectionString);
                        SqlCommand command = new SqlCommand(ItemQuery, conn2);
                        conn2.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string PRNumReader = reader.GetValue(0).ToString();
                            if (dataGridView1.RowCount == 0)
                            {
                                this.dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), txt_qty.Text, (Convert.ToDouble(txt_qty.Text) * Convert.ToDouble(reader.GetValue(2))).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString());
                            }
                            else
                            {
                                foreach (DataGridViewRow datarow in dataGridView1.Rows)
                                {
                                    string ExistingProductNumber = datarow.Cells["ProductNumber"].Value.ToString();
                                    prCheck = false;
                                    string currQty = datarow.Cells[3].Value.ToString();
                                    if (PRNumReader == ExistingProductNumber)
                                    {
                                        datarow.Cells[3].Value = (int.Parse(currQty) + int.Parse(txt_qty.Text.ToString())).ToString();
                                        datarow.Cells[4].Value = (Convert.ToDouble(datarow.Cells[3].Value) * Convert.ToDouble(reader.GetValue(2))).ToString();
                                        break;
                                    }
                                    else
                                    {
                                        prCheck = true;
                                    }
                                }
                                if (prCheck)
                                {
                                    this.dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), txt_qty.Text, (Convert.ToDouble(txt_qty.Text) * Convert.ToDouble(reader.GetValue(2))).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString());

                                }
                            }
                        }
                        reader.Close();
                        conn2.Close();
                    }
                }
            }
            ProductAvailability(this.dataGridView1);
            if (NotAvailID != 0)
            {
                foreach (DataGridViewRow datarow in this.dataGridView1.Rows)
                {
                    int prodId = int.Parse(datarow.Cells[5].Value.ToString());
                    if (NotAvailID == prodId)
                    {
                        dataGridView1.Rows.RemoveAt(datarow.Index);
                        NotAvailID = 0;
                        break;
                    }
                }
            }

            GetTotalCost();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int resault;
                bool tryparse = Int32.TryParse(this.dataGridView1.CurrentCell.Value.ToString(), out resault);
                if (resault == 0)
                {
                    MessageBox.Show("Quantity Error");
                }
                else
                {
                    int value = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                    double ListPrice = Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value);
                    double TotalPrice = Convert.ToDouble(value) * ListPrice;
                    dataGridView1.CurrentRow.Cells[4].Value = TotalPrice.ToString();
                    GetTotalCost();
                    ProductAvailability(this.dataGridView1);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                GetTotalCost();
            }
        }

        public void OpenSavedOrder()
        {
            string fname = "", mname = "", lname = "", fullname;
            int cidSaved = Home.CidToPass;
            crrOrderSaved = Home.KeyToPass;
            newSaved = cidSaved;
            string namequery = "select FirstName, MiddleName, LastName " +
                                "from Person.Person pp " +
                                "join Sales.Customer sc " +
                                "on pp.BusinessEntityID = sc.PersonID " +
                                $"where sc.CustomerID = {newSaved}";
            SqlConnection conn2 = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(namequery, conn2);
            conn2.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fname = reader.GetValue(0).ToString();
                mname = reader.GetValue(1).ToString();
                lname = reader.GetValue(2).ToString();
            }
            fullname = fname + " " + mname + " " + lname;
            reader.Close();
            conn2.Close();
            lbl_fullname.Text = fullname + " / New Sale";
            lbl_saveid_desc.Visible = true;
            lbl_savedid.Text = crrOrderSaved.ToString();
            lbl_savedid.Visible = true;
            lbl_cid.Text = cidSaved.ToString();
            btn_removesaved.Visible = true;
            label10.Visible = true;
            GetSavedProducts();
            GetTotalCost();
            fillAddressCombo();
        }

        private void GetSavedProducts()
        {
            string product = "select ProdID,Qty from SavedOrderHeader " +
                             $"where CustomerID = {newSaved} and crrOrder = {crrOrderSaved}";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(product, conn);
            conn.Open();
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                int prodID = int.Parse(row[0].ToString());
                int prodQty = int.Parse(row[1].ToString());
                string addtogrid = "select ProductNumber, Name , ListPrice, ProductID, WeightUnitMeasureCode, Weight " +
                                       $"from Production.Product where ProductID = {prodID}";
                SqlCommand command = new SqlCommand(addtogrid, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), prodQty.ToString(), Convert.ToDouble(reader.GetValue(2)) * Convert.ToDouble(prodQty.ToString()), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString());
                }
                reader.Close();
            }
            conn.Close();
        }

        private void GetTotalCost()
        {
            int RowCount = this.dataGridView1.Rows.Count;
            double notaxcost = 0, taxcost = 0;
            double ShipCost = 0;
            double TotalCost = 0;

            double Weight = 0;
            double SB, SR;
            int key = 0;
            string WeightType;
            foreach (DataGridViewRow datarow in this.dataGridView1.Rows)
            {
                WeightType = datarow.Cells[6].Value.ToString();
                notaxcost += Double.Parse(datarow.Cells[4].Value.ToString());
                if (WeightType.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
                {
                    Weight += 0;
                }
                else if (WeightType.Trim().Equals("LB", StringComparison.OrdinalIgnoreCase))
                {
                    Weight += Double.Parse(datarow.Cells[7].Value.ToString()) * Double.Parse(datarow.Cells[3].Value.ToString());
                }
                else if (WeightType.Trim().Equals("G", StringComparison.OrdinalIgnoreCase))
                {
                    Weight += (Double.Parse(datarow.Cells[7].Value.ToString()) * 0.002205) * Double.Parse(datarow.Cells[3].Value.ToString());
                }
            }
            key = comboBox3.SelectedIndex;
            switch (key)
            {
                case (0):
                    {
                        SB = 3.95;
                        SR = 0.99;
                        ShipCost = SB + SR * Convert.ToDouble(Math.Floor(Weight));
                        break;
                    }
                case (1):
                    {
                        SB = 9.95;
                        SR = 1.99;
                        ShipCost = SB + SR * Convert.ToDouble(Math.Floor(Weight));
                        break;
                    }
                case (2):
                    {
                        SB = 29.95;
                        SR = 2.99;
                        ShipCost = SB + SR * Convert.ToDouble(Math.Floor(Weight));
                        break;
                    }
                case (3):
                    {
                        SB = 21.95;
                        SR = 1.29;
                        ShipCost = SB + SR * Convert.ToDouble(Math.Floor(Weight));
                        break;
                    }
                case (4):
                    {
                        SB = 8.99;
                        SR = 1.49;
                        ShipCost = SB + SR * Convert.ToDouble(Math.Floor(Weight));
                        break;
                    }
            }
            TotalCost = (notaxcost + (0.24 * notaxcost) + ShipCost);
            taxcost = 0.24 * notaxcost;
            lbl_ShipCost.Text = ShipCost.ToString() + " €";
            lbl_notaxCost.Text = notaxcost.ToString() + " €";
            lbl_taxCost.Text = taxcost.ToString() + " €";
            lbl_totalCost.Text = TotalCost.ToString() + " €";
            notaxcostg = notaxcost;
            taxcostg = taxcost;
            ShipCostg = ShipCost;
        }

        private bool ProductAvailability(DataGridView grid1)
        {
            bool avail = true;
            int prodID;
            int dbQty = 0;
            int GridQty = 0;
            foreach (DataGridViewRow row in grid1.Rows)
            {
                SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                myConnection.Open();
                prodID = int.Parse(row.Cells[5].Value.ToString());
                GridQty = int.Parse(row.Cells[3].Value.ToString());

                string Availquery = "WITH cte1 AS " +
                                    "(select ppr.ProductID, ppi.LocationID, ppi.Quantity " +
                                    "from Production.Product ppr " +
                                    "join Production.ProductInventory ppi " +
                                    "on ppr.ProductID = ppi.ProductID), " +
                                    "cte2 AS " +
                                    "(select ProductID, SUM(Quantity) As TotalQuantity " +
                                    "from cte1 " +
                                    "group by ProductID) " +
                                    "select cte1.ProductID, cte2.TotalQuantity " +
                                    "from cte1 " +
                                    "join cte2 " +
                                    "on cte1.ProductID = cte2.ProductID " +
                                    $"where cte1.ProductID = {prodID} " +
                                    "group by cte1.ProductID, cte2.TotalQuantity  ";
                SqlCommand command = new SqlCommand(Availquery, myConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    avail = false;
                    NotAvailID = prodID;
                    MessageBox.Show($"Product {prodID} is available only after a\nWork Order is complete");
                }
                else
                {
                    dbQty = int.Parse(reader.GetValue(1).ToString());
                    if (dbQty < GridQty)
                    {
                        avail = false;
                        NotAvailID = prodID;
                        reader.Close();
                        myConnection.Close();
                        MessageBox.Show($"Product {prodID} is out of requested stock(avail: {dbQty})");
                        break;
                    }
                }
                reader.Close();
                myConnection.Close();

            }
            return avail;
        }

        private void UpdateInventory(int prodid, int qty)
        {
            int StoreQty = 0;
            int updQty = 0;
            int LocID = 0;
            do
            {
                string LocationQuery = "WITH cte1 AS " +
                                       "(select ppr.ProductID, ppi.LocationID, ppi.Quantity " +
                                       "from Production.Product ppr " +
                                       "join Production.ProductInventory ppi " +
                                       "on ppr.ProductID = ppi.ProductID), " +
                                       "cte2 AS " +
                                       "(select ProductID, Max(Quantity) As MaxQuantity " +
                                       "from cte1 " +
                                       "group by ProductID) " +
                                       "select cte1.ProductID, Max(cte1.LocationID) As LocationID, cte2.MaxQuantity " +
                                       "from cte1 " +
                                       "join cte2 " +
                                       "on cte1.ProductID = cte2.ProductID " +
                                       $"where cte1.Quantity = cte2.MaxQuantity and cte1.ProductID = {prodid} " +
                                       "group by cte1.ProductID, cte2.MaxQuantity";
                SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                myConnection.Open();
                SqlCommand command = new SqlCommand(LocationQuery, myConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StoreQty = int.Parse(reader.GetValue(2).ToString());
                    LocID = int.Parse(reader.GetValue(1).ToString());
                }
                reader.Close();

                if (qty > StoreQty)
                {
                    updQty = 0;
                    qty -= StoreQty;
                }
                else
                {
                    updQty = StoreQty - qty;
                    qty = 0;
                }
                string UpdateQuery = $"update Production.ProductInventory set Quantity = {updQty} where ProductID = {prodid} and LocationID = {LocID}";
                command = new SqlCommand(UpdateQuery, myConnection);
                command.ExecuteNonQuery();

                myConnection.Close();
            } while (qty > 0);
        }
    }
}
