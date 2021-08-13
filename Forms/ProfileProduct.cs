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
    public partial class ProfileProduct : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        private int prodID, qty, bid = 0;
        private string prodname;
        bool inlist = false;
        public bool novendor = false;
        public double stdprice;

        public ProfileProduct()
        {
            InitializeComponent();
            prodID = Forms.Inventory.ProdID;
            prodname = Forms.Inventory.ProdName;
            lbl_prodName.Text = $"{prodname} ID : {prodID}";//prodname.ToString() + "  ID : " + prodID.ToString();
            getlocation();
            gettotalqty();
            fillvendorcombo();
            getPrice_Stock();
            if (novendor) { btn_add_to_list.Enabled = false; btn_Work.Enabled = true; }
            else { comboBox1.SelectedIndex = 0; }
        }
        private void getlocation()
        {
            double listprice = 0;
            string locationQuery = "select LocationID, Shelf, Bin, Quantity, pp.ListPrice from Production.ProductInventory ppi " +
                                    "join Production.Product pp " +
                                    "on ppi.ProductID = pp.ProductID " +
                                    $"where pp.ProductID = {prodID}";
            Classes.SQLConnection.ReadDataFillGrid(locationQuery, this.dataGridView1);
            SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(locationQuery, myConnection);
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listprice = double.Parse(reader.GetValue(4).ToString());
            }
            reader.Close();
            myConnection.Close();
            label13.Text = listprice.ToString();
        }
        private void gettotalqty()
        {
            int totalQty = 0;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                totalQty += int.Parse(row.Cells[3].Value.ToString());
            }
            lbl_totalQty.Text = totalQty.ToString();
        }
        private void fillvendorcombo()
        {
            string vendor = "select pv.Name from Purchasing.Vendor pv " +
                                "join Purchasing.ProductVendor ppv " +
                                "on pv.BusinessEntityID = ppv.BusinessEntityID " +
                                "join Production.Product pp " +
                                "on ppv.ProductID = pp.ProductID " +
                                $"where pv.ActiveFlag = 1 and pp.ProductID = {prodID}";
            SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(vendor, myConnection);
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                novendor = true;
            }
            else
            {
                comboBox1.Items.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            myConnection.Close();
        }

        private void getPrice_Stock()
        {
            int safetyStock = 0, reorderPoint = 0;
            string StdCost = "";
            string getValues = $"select SafetyStockLevel,ReorderPoint,StandardCost from Production.Product where ProductID = {prodID}";
            SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(getValues, myConnection);
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                safetyStock = int.Parse(reader.GetValue(0).ToString());
                reorderPoint = int.Parse(reader.GetValue(1).ToString());
                StdCost = reader.GetValue(2).ToString();
            }
            reader.Close();
            myConnection.Close();
            lbl_safeStock.Text = safetyStock.ToString();
            lbl_reorderPoint.Text = reorderPoint.ToString();
            lbl_stdCost.Text = double.Parse(StdCost.ToString()).ToString();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Inventory.PanelContainer.Visible = false;
            Inventory.GridInventory.Visible = true;
            this.Dispose();
            this.Close();
        }

        private void btn_Work_Click(object sender, EventArgs e)
        {
            string qty = txt_qty.Text.ToString();
            if (qty == "")
            {
                MessageBox.Show("Enter Quantity");
            }
            else
            {
                SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                bool corr = false;
                int result = 0;
                corr = Int32.TryParse(txt_qty.Text.ToString(), out result);
                if (corr)
                {
                    DialogResult conf = MessageBox.Show("Are you sure you want to Place a Work Order ? ", "Confirm ", MessageBoxButtons.YesNo);
                    if (conf == DialogResult.Yes)
                    {
                        string quickwork = $"insert into Production.WorkOrder values({prodID},{result},0,GETDATE(),null,GETDATE()+15,null,GETDATE())";
                        SqlCommand command = new SqlCommand(quickwork, myConnection);
                        myConnection.Open();
                        command.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("Work Order placed");
                    }
                    else
                    {
                        MessageBox.Show("Work Order not placed");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Quantity!");
                }
            }
        }

        private void btn_SuggestPoint_Click(object sender, EventArgs e)
        {
            int qty = int.Parse(lbl_totalQty.Text.ToString());
            int safe = int.Parse(lbl_safeStock.Text.ToString());
            if (qty < safe)
            {
                txt_qty.Text = (safe - qty).ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int creditr = 0;
            bool prefstatus = false;
            string Vname = comboBox1.SelectedItem.ToString();
            string vendorPref = "select ppv.StandardPrice, PreferredVendorStatus, CreditRating, pv.BusinessEntityID from Purchasing.Vendor pv " +
                                    "join Purchasing.ProductVendor ppv " +
                                    "on pv.BusinessEntityID = ppv.BusinessEntityID " +
                                    $"where name like '{Vname.Replace("'", "''")}'";
            SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(vendorPref, myConnection);
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stdprice = double.Parse(reader.GetValue(0).ToString());
                prefstatus = bool.Parse(reader.GetValue(1).ToString());
                creditr = int.Parse(reader.GetValue(2).ToString());
                bid = int.Parse(reader.GetValue(3).ToString());
            }
            reader.Close();
            myConnection.Close();
            label6.Text = stdprice.ToString();
            if (prefstatus)
                label8.Text = "1";
            else
                label8.Text = "0";
            label10.Text = creditr.ToString();
            label15.Text = bid.ToString();
        }

        private void btn_add_to_list_Click(object sender, EventArgs e)
        {
            string Qty = txt_qty.Text;
            if (Qty == "")
            {
                MessageBox.Show("Enter Quantity");
            }
            else
            {
                int qtyResault;
                bool qtyValidation = Int32.TryParse(txt_qty.Text.ToString(), out qtyResault);
                if (qtyValidation)
                {
                    qty = qtyResault;
                }
                else
                {
                    qty = 0;
                }
                if (qty != 0)
                {
                    alreadyinlist(prodID);
                    if (inlist) { }
                    else
                    {
                        string toList = "insert into PurchaseList " +
                                   $"values({bid}, {prodID}, {qty}, {double.Parse(stdprice.ToString(), cultureUS)})";
                        SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                        SqlCommand command = new SqlCommand(toList, myConnection);
                        myConnection.Open();
                        command.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("Added");
                        txt_qty.Text = "";
                        inlist = false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input");
                }
            }
        }

        private void alreadyinlist(int prodId)
        {
            string purchaselist = "select VendorID, ProdID, Qty, StdPrice from PurchaseList order by VendorID";
            SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(purchaselist, conn);
            DataTable dtbl1 = new DataTable();
            conn.Open();
            adapter.Fill(dtbl1);
            conn.Close();
            foreach (DataRow row in dtbl1.Rows)
            {
                if (int.Parse(row[1].ToString()) == prodId)
                {
                    int prevqty = int.Parse(row[2].ToString());
                    int updqty = prevqty + qty;
                    string updatelist = $"update PurchaseList set Qty = {updqty} where ProdID = {prodId}";
                    SqlCommand command = new SqlCommand(updatelist, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    inlist = true;
                    MessageBox.Show("Added - inlist");
                    break;
                }
            }
            txt_qty.Text = "";
        }
    }
}
