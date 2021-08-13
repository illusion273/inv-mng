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
    public partial class Customers : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        public static string CustomerQuery2 { get; set; }
        public static DataGridView GridCustomers { get; set; }
        public static Panel PanelContainer { get; set; }
        public static int TrsfSid { get; set; }
        public static int TransferId { get; set; }
        public static string TrsfFullname { get; set; }
        public static string TrsfType { get; set; }

        public Customers()
        {
            InitializeComponent();
            CustomerQuery2 = "select pp.BusinessEntityID, CustomerID, FirstName, MiddleName, LastName, pp.PersonType, sc.StoreID " +
                                "from Person.Address ppa " +
                                "join person.BusinessEntityAddress ppb " +
                                "on ppb.AddressID = ppa.AddressID " +
                                "join Sales.Customer sc " +
                                "on sc.PersonID = ppb.BusinessEntityID or sc.StoreID = ppb.BusinessEntityID " +
                                "join Person.Person pp " +
                                "on pp.BusinessEntityID = sc.PersonID or pp.BusinessEntityID = sc.StoreID " +
                                "join Person.AddressType pat " +
                                "on pat.AddressTypeID = ppb.AddressTypeID " +
                                "group by CustomerID,pp.BusinessEntityID,FirstName,MiddleName, LastName, pp.PersonType, sc.StoreID";
            GridCustomers = gridCustomers;
            PanelContainer = panelContainer;
            LoadCustomers();
        }
        private void LoadNewCustomer()
        {
            this.panelContainer.Controls.Clear();
            var newCust = new NewCustomer(/*this*/);
            newCust.TopLevel = false;
            newCust.TopMost = true;
            newCust.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(newCust);
            newCust.Show();
        }

        private void btn_customeradd_Click(object sender, EventArgs e)
        {
            if (panelContainer.Visible == false)
            {
                var profile = Application.OpenForms["ProfileCustomer"];
                if (profile == null) { }
                else { profile.Dispose(); profile.Close(); }
                var newCustomer = Application.OpenForms["NewCustomer"];
                if (newCustomer == null) { LoadNewCustomer(); }
                else { newCustomer.Dispose(); newCustomer.Close(); LoadNewCustomer(); }
                panelContainer.Visible = true;
            }
            else if (panelContainer.Visible == true)
            {
                var newCustomer = Application.OpenForms["NewCustomer"];
                if (newCustomer == null) { }
                else
                {
                    newCustomer.Dispose(); newCustomer.Close();
                    panelContainer.Visible = false;
                }
                var profile = Application.OpenForms["ProfileCustomer"];
                if (profile == null) { }
                else { profile.Dispose(); profile.Close(); LoadNewCustomer(); }            
            }
        }

        private void LoadCustomers()
        {
            this.gridCustomers.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(CustomerQuery2, this.gridCustomers);
            this.gridCustomers.Columns[6].Visible = false;
        }

        private void btn_customerlist_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btn_customer_remove_Click(object sender, EventArgs e)
        {
            if (this.gridCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Customer has not been selected.");
            }
            else if (this.gridCustomers.SelectedRows.Count == 1)
            {


                int cid, bid;
                bid = int.Parse(this.gridCustomers.SelectedCells[0].Value.ToString());
                cid = int.Parse(this.gridCustomers.SelectedCells[1].Value.ToString());
                string removecquery =
                                        "declare @aid int; " +
                                        "set @aid = (select AddressID from Person.BusinessEntityAddress " +
                                        $"where BusinessEntityID = {bid}) " +
                                        "delete from Person.BusinessEntityAddress " +
                                        $"where BusinessEntityID = {bid} " +
                                        $"delete from sales.SalesOrderHeader where CustomerID = {cid} " +
                                        "delete from Sales.Customer " +
                                        $"where CustomerID = {cid} " +
                                        $"delete from Person.Password where BusinessEntityID = {bid} " +
                                        $"delete from Sales.PersonCreditCard where BusinessEntityID = {bid} " +
                                        $"delete from Person.PersonPhone where BusinessEntityID = {bid} " +
                                        $"delete from Person.EmailAddress where BusinessEntityID = {bid} " +
                                        "delete from Person.Person " +
                                        $"where BusinessEntityID = {bid} " +
                                        "delete from Person.Address " +
                                        "where AddressID = @aid " +
                                        "delete from person.BusinessEntity " +
                                        $"where BusinessEntityID = {bid}";
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove customer " + cid.ToString() + " ?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
                    SqlCommand command = new SqlCommand(removecquery, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    LoadCustomers();
                    MessageBox.Show("Customer " + bid.ToString() + " has been removed.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Selection.");
            }
        }

        private void btn_customer_filter_Click(object sender, EventArgs e)
        {
            string customerQuerySearch = "select pp.BusinessEntityID, CustomerID, FirstName, MiddleName, LastName, pp.PersonType, sc.StoreID " +
                                "from Person.Address ppa " +
                                "join person.BusinessEntityAddress ppb " +
                                "on ppb.AddressID = ppa.AddressID " +
                                "join Sales.Customer sc " +
                                "on sc.PersonID = ppb.BusinessEntityID or sc.StoreID = ppb.BusinessEntityID " +
                                "join Person.Person pp " +
                                "on pp.BusinessEntityID = sc.PersonID or pp.BusinessEntityID = sc.StoreID " +
                                "join Person.AddressType pat " +
                                "on pat.AddressTypeID = ppb.AddressTypeID ";
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
                this.gridCustomers.DataSource = null;
                key = comboBox1.SelectedItem.ToString();
                switch (key)
                {
                    case "CustomerID":
                        {
                            string searchquery = $"{customerQuerySearch} WHERE sc.CustomerID like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridCustomers);
                            this.gridCustomers.Columns[6].Visible = false;
                            break;
                        }
                    case "StoreID":
                        {
                            string searchquery = $"{customerQuerySearch} WHERE sc.StoreID like '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridCustomers);
                            this.gridCustomers.Columns[6].Visible = false;
                            break;
                        }
                    case "Last Name":
                        {
                            string searchquery = $"{customerQuerySearch} WHERE pp.LastName LIKE '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridCustomers);
                            this.gridCustomers.Columns[6].Visible = false;
                            break;
                        }

                    case "Address":
                        {
                            string searchquery = $"{customerQuerySearch} WHERE ppa.AddressLine1 LIKE '%{input.Replace("'", "''")}%' or ppa.AddressLine2 LIKE '%{input.Replace("'", "''")}%'";
                            Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridCustomers);
                            this.gridCustomers.Columns[6].Visible = false;
                            break;
                        }
                }
            }
        }
        private void LoadProfile()
        {
            bool varf = Int32.TryParse(gridCustomers.CurrentRow.Cells[6].Value.ToString(), out int excep);
            if (varf)
            {
                TrsfSid = excep;
            }
            else
            {
                TrsfSid = 0;
            }
            string trsf_firstname = gridCustomers.CurrentRow.Cells[2].Value.ToString();
            string trsf_midname = gridCustomers.CurrentRow.Cells[3].Value.ToString();
            string trsf_lastname = gridCustomers.CurrentRow.Cells[4].Value.ToString();
            TrsfFullname = $"{trsf_firstname} {trsf_midname} {trsf_lastname}";//trsf_firstname + " " + trsf_midname + " " + trsf_lastname;
            TrsfType = gridCustomers.CurrentRow.Cells[5].Value.ToString();
            TransferId = int.Parse(gridCustomers.CurrentRow.Cells[1].Value.ToString());
            this.panelContainer.Controls.Clear();
            ProfileCustomer profile = new ProfileCustomer();
            profile.TopLevel = false;
            profile.TopMost = true;
            profile.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(profile);
            this.panelContainer.Visible = true;
            profile.Show();
        }

        private void gridCustomers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var newCustomer = Application.OpenForms["NewCustomer"];
            if (newCustomer == null) { }
            else { newCustomer.Dispose(); newCustomer.Close(); }
            var profile = Application.OpenForms["ProfileCustomer"];
            if (profile == null) { LoadProfile(); }
            else { profile.Dispose(); profile.Close(); LoadProfile(); }
            panelContainer.Visible = true;
        }
    }
}
