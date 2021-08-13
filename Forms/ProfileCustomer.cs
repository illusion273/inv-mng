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
    public partial class ProfileCustomer : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        public string Query { get; set; }
        public int var1, var4;
        public string var2, var3;

        public ProfileCustomer()
        {
            InitializeComponent();
            Query = "SELECT " +
                "soh.SalesOrderID,soh.SalesOrderNumber,soh.PurchaseOrderNumber,soh.Status, soh.OrderDate,soh.DueDate,soh.ShipDate, " +
                "Name AS  " + "'Store Name'" + " , soh.TotalDue " +
                "FROM Sales.SalesOrderHeader soh " +
                "JOIN sales.Customer SC " +
                "on soh.CustomerID = sc.CustomerID " +
                "join Person.Person per " +
                "ON SC.PersonID = per.BusinessEntityID " +
                "full outer join Sales.Store SST " +
                "ON SC.StoreID = SST.BusinessEntityID " +
                "WHERE SalesOrderID IS NOT NULL";
            InitCustomerInfo();
            getAddress();
            GetCustomerSales();
        }

        private void InitCustomerInfo()
        {
            var1 = Forms.Customers.TransferId;
            var2 = Forms.Customers.TrsfFullname;
            var3 = Forms.Customers.TrsfType;
            var4 = Forms.Customers.TrsfSid;
            lbl_cid.Text = var1.ToString();
            lbl_fullname.Text = var2.ToString() + " / Profile";
            lbl_persontype.Text = var3.ToString();
            if (var4 != 0)
                lbl_storeid.Text = var4.ToString();
        }

        private void getAddress()
        {
            int addrID = 0;
            string addressQuery = "select AddressID from Person.BusinessEntityAddress pba " +
                                    "join Sales.Customer sc " +
                                    "on pba.BusinessEntityID = sc.PersonID " +
                                    $"where CustomerID = {var1}";
            SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(addressQuery, myConnection);
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                addrID = int.Parse(reader.GetValue(0).ToString());
            }
            reader.Close();
            string comboAddress = "select AddressLine1,AddressLine2,City,PostalCode from Person.Address " +
                                        $"where AddressID = {addrID}";
            command = new SqlCommand(comboAddress, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_address1.Text = reader.GetValue(0).ToString();
                lbl_address2.Text = reader.GetValue(1).ToString();
                lbl_city.Text = reader.GetValue(2).ToString();
                lbl_postal.Text = reader.GetValue(3).ToString();
            }
            reader.Close();
            myConnection.Close();
            if (var3 == "SC")
            {
                panel_Stores.Visible = true;
                int StoreAddrID = 0;
                string StoreAddressQuery = "select AddressID from Person.BusinessEntityAddress pba " +
                                        "join Sales.Customer sc " +
                                        "on pba.BusinessEntityID = sc.StoreID " +
                                        $"where CustomerID = {var1}";
                command = new SqlCommand(StoreAddressQuery, myConnection);
                myConnection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StoreAddrID = int.Parse(reader.GetValue(0).ToString());
                }
                reader.Close();
                string StoreComboAddress = "select AddressLine1,AddressLine2,City,PostalCode from Person.Address " +
                                            $"where AddressID = {StoreAddrID}";
                command = new SqlCommand(StoreComboAddress, myConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lbl_storeAdd1.Text = reader.GetValue(0).ToString();
                    lbl_storeAdd2.Text = reader.GetValue(1).ToString();
                    lbl_storeCity.Text = reader.GetValue(2).ToString();
                    lbl_storePostal.Text = reader.GetValue(3).ToString();
                }
                reader.Close();
                myConnection.Close();
            }
        }
        private void GetCustomerSales()
        {
            this.dataGridView1.DataSource = null;
            string filterquery = $"{Query} and soh.CustomerID = {var1}";
            Classes.SQLConnection.ReadDataFillGrid(filterquery, this.dataGridView1);
        }

        private void btn_new_sale_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms["NewSale"];
            if (form == null)
            {
                var newsalesform = new NewSale();
                newsalesform.TopLevel = true;
                newsalesform.TopMost = false;
                newsalesform.Show();
                newsalesform.showCustomer();
            }
            else
            {
                form.Dispose();
                form.Close();
                var newsalesform = new NewSale();
                newsalesform.TopLevel = true;
                newsalesform.TopMost = false;
                newsalesform.Show();
                newsalesform.showCustomer();
            }
        }

        private void btn_getcustomersales_Click(object sender, EventArgs e)
        {
            GetCustomerSales();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Customers.PanelContainer.Visible = false;
            Customers.GridCustomers.Visible = true;
            this.Dispose();
            this.Close();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }

    }
}
