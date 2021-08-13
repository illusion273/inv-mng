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
    public partial class Stores : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        public string StoresQuery { get; set; }

        public Stores()
        {
            InitializeComponent();
            StoresQuery = "select ss.BusinessEntityID as 'Store ID', ss.Name as 'Store Name', pat.Name as 'Adr. Type', pa.AddressLine1, pa.AddressLine2, pa.City, pa.PostalCode " +
                                    "from sales.Store ss " +
                                    "join person.BusinessEntityAddress bea " +
                                    "on ss.BusinessEntityID = bea.BusinessEntityID " +
                                    "join person.Address pa " +
                                    "on bea.AddressID = pa.AddressID " +
                                    "join Person.AddressType pat " +
                                    "on bea.AddressTypeID = pat.AddressTypeID";
            GetStores();
            comboBox2.SelectedItem = "Main Office";
        }

        private void GetStores()
        {
            this.gridStores.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(StoresQuery, this.gridStores);
        }

        private void btn_stores_reg_Click(object sender, EventArgs e)
        {
            if (panelAddStore.Visible == false)
            {
                panelAddStore.Visible = true;
            }
            else if (panelAddStore.Visible == true)
            {
                panelAddStore.Visible = false;
            }
        }

        private void btn_stores_show_Click(object sender, EventArgs e)
        {
            GetStores();
        }

        private void btn_stores_remove_Click(object sender, EventArgs e)
        {
            
            if (gridStores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Store has not been selected.");
            }
            else if (gridStores.SelectedRows.Count == 1)
            {


                int sid = 0, cid = 0;
                sid = int.Parse(gridStores.SelectedCells[0].Value.ToString());
                string cidQuery = $"SELECT CUSTOMERID FROM SALES.Customer WHERE StoreID = {sid} AND PersonID IS NOT NULL";
                SqlConnection conn2 = new SqlConnection(Classes.SQLConnection.connectionString);
                SqlCommand command = new SqlCommand(cidQuery, conn2);
                conn2.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cid = int.Parse(reader.GetValue(0).ToString());
                }
                reader.Close();
                conn2.Close();
                string removequery = "declare @aid int; " +
                            "set @aid = (select AddressID from person.BusinessEntityAddress " +
                                        $"where BusinessEntityID = {sid}) " +
                                        $"DELETE FROM Sales.SalesOrderHeader WHERE CustomerID = {cid}" +
                                        "delete from sales.Customer " +
                                        $"where StoreID = {sid} " +
                                        "delete from sales.store " +
                                        $"where BusinessEntityID = {sid} " +
                                        "delete from Person.BusinessEntityAddress " +
                                        "where AddressID = @aid " +
                                        "delete from Person.Address " +
                                        "where AddressID = @aid";
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove store " + sid.ToString() + " ?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
                    command = new SqlCommand(removequery, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    GetStores();
                    MessageBox.Show("Store " + sid.ToString() + " has been removed.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Selection.");
            }
        }

        private void btn_store_filter_Click(object sender, EventArgs e)
        {
            string key;
            string input = textBox1.Text.ToString();
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a filter.");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a value.");
            }
            else
            {
                this.gridStores.DataSource = null;
                key = comboBox1.SelectedItem.ToString();
                switch (key)
                {
                    case "Store Name":
                        {
                            string searchquery = $"{StoresQuery} where ss.Name like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridStores);
                            break;
                        }
                    case "StoreID":
                        {
                            string searchquery = $"{StoresQuery} where ss.BusinessEntityID like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridStores);
                            break;
                        }
                    case "Address":
                        {
                            string searchquery = $"{StoresQuery} where pa.AddressLine1 like '%{input.Replace("'", "''")}%' or pa.AddressLine2 like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridStores);
                            break;
                        }
                    case "Address Type":
                        {
                            string searchquery = $"{StoresQuery} where pat.Name like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridStores);
                            break;
                        }
                    case "City":
                        {
                            string searchquery = $"{StoresQuery} where pa.City like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridStores);
                            break;
                        }
                    case "Postal Code":
                        {
                            string searchquery = $"{StoresQuery} where pa.PostalCode like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridStores);
                            break;
                        }

                }

            }
        }

        private void btn_RegiStore_Click(object sender, EventArgs e)
        {
            int parseResault, Resault;
            bool tryParse = Int32.TryParse(txt_postal.Text.ToString(), out parseResault);
            if (parseResault == 0)
            {
                Resault = 0;
            }
            else
            {
                Resault = parseResault;
            }
            if (txt_storename.Text.ToString() == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else if (txt_addr1.Text.ToString() == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else if (txt_city.Text.ToString() == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else if (txt_postal.Text.ToString() == "" || Resault == 0)
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else
            {
                bool varf;
                string storename_, addr1_, addr2_, city_, addrtype_;
                int final1, final2, addrinput = 0;
                storename_ = txt_storename.Text.ToString();
                addr1_ = txt_addr1.Text.ToString();
                addr2_ = txt_addr2.Text.ToString();
                city_ = txt_city.Text.ToString();
                addrtype_ = comboBox2.SelectedItem.ToString();
                varf = Int32.TryParse(txt_postal.Text.ToString(), out final1);
                if (varf)
                {
                    final2 = final1;
                }
                else
                {
                    return;
                }
                switch (addrtype_)
                {
                    case "Main Office":
                        {
                            addrinput = 3;
                            break;
                        }
                    case "Shipping":
                        {
                            addrinput = 5;
                            break;
                        }
                }
                string regstorequery = $"insert into Person.BusinessEntity " +
                                    "values(NEWID(),GETDATE()) " +
                                    "declare @sid int; " +
                                    "set @sid = (select max(Person.BusinessEntity.BusinessEntityID) " +
                                    "from Person.BusinessEntity) " +
                                    "insert into Sales.Store " +
                                    $"values(@sid,'{storename_.Replace("'", "''")}',null,null,NEWID(),GETDATE()) " +
                                    "insert into person.Address " +
                                    $"values ('{addr1_.Replace("'", "''")}','{addr2_.Replace("'", "''")}','{city_.Replace("'", "''")}',79,{final2},null,NEWID(),GETDATE()) " +
                                    "declare @aid int; " +
                                    "set @aid = (select max(Person.Address.AddressID) " +
                                    "from person.Address) " +
                                    "insert into Person.BusinessEntityAddress " +
                                    $"values (@sid, @aid, {addrinput}, NEWID(), GETDATE()) " +
                                    "insert into sales.Customer(StoreID,TerritoryID) " +
                                    "values(@sid,'1')";
                SqlConnection conn2 = new SqlConnection(Classes.SQLConnection.connectionString);
                SqlCommand command = new SqlCommand(regstorequery, conn2);
                conn2.Open();
                command.ExecuteNonQuery();
                conn2.Close();
                this.panelAddStore.Visible = false;
                txt_storename.Text = "";
                txt_addr1.Text = "";
                txt_addr2.Text = "";
                txt_city.Text = "";
                txt_postal.Text = "";
                comboBox2.SelectedItem = "Main Office";
                GetStores();
                MessageBox.Show("New store added.");
            }
        }
    }
}
