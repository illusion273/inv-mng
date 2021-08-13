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
    public partial class NewCustomer : Form
    {
        public string Query { get; set; }
        public NewCustomer()
        {
            InitializeComponent();
            Query = "select BusinessEntityID,Name from Sales.Store";
        }

        private void LoadCustomers()
        {
            Customers.GridCustomers.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(Customers.CustomerQuery2, Customers.GridCustomers);
            Customers.GridCustomers.Columns[6].Visible = false;
        }

        private void btn_registerctmr_Click(object sender, EventArgs e)
        {
            string firstname, middlename, lastname, address1, address2, city, personType, territoryIDkey, personTypekey, addresstype, postalcode;
            int territoryID, storeid, addrtype = 0, postalResault, Resault;
            //string customerQuer = CustomerQuery2;
            if (txt_firstname.Text == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else if (txt_middlename.Text == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else if (txt_lastname.Text == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else if (txt_city.Text == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else if (txt_postalcode.Text == "")
            {
                MessageBox.Show("Postal Code Error");
            }
            else if (txt_address1.Text == "")
            {
                MessageBox.Show("Empty field(s) found.");
            }
            else
            {
                firstname = txt_firstname.Text;
                middlename = txt_middlename.Text;
                lastname = txt_lastname.Text;
                address1 = txt_address1.Text;
                address2 = txt_address2.Text;
                city = txt_city.Text;
                addresstype = combo_addresstype.SelectedItem.ToString();
                personTypekey = combo_type.SelectedItem.ToString();
                postalcode = txt_postalcode.Text.ToString();
                switch (personTypekey)
                {
                    case "Store Contact":
                        {
                            personType = "SC";
                            break;
                        }
                    case "Individual Customer":
                        {
                            personType = "IN";
                            break;
                        }
                    default:
                        {
                            personType = "IN";
                            break;
                        }
                }
                territoryIDkey = combo_region.SelectedItem.ToString();
                if (combo_type.SelectedItem.ToString() == "Store Contact")
                {
                    storeid = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                    switch (territoryIDkey)
                    {
                        case "1. Northwest - US":
                            {
                                territoryID = 1;
                                break;
                            }
                        case "2. Northeast - US":
                            {
                                territoryID = 2;
                                break;
                            }
                        case "3. Central - US":
                            {
                                territoryID = 3;
                                break;
                            }
                        case "24. Southwest - US":
                            {
                                territoryID = 4;
                                break;
                            }
                        case "5. Southeast - US":
                            {
                                territoryID = 5;
                                break;
                            }
                        case "6. Canada - CA":
                            {
                                territoryID = 6;
                                break;
                            }
                        case "7. France - FR":
                            {
                                territoryID = 7;
                                break;
                            }
                        case "8. Germany - DE":
                            {
                                territoryID = 8;
                                break;
                            }
                        case "9. Australia - AU":
                            {
                                territoryID = 9;
                                break;
                            }
                        case "10. United Kingdom - UK":
                            {
                                territoryID = 10;
                                break;
                            }
                        default:
                            {
                                territoryID = 1;
                                break;
                            }
                    }
                    switch (addresstype)
                    {
                        case "Home":
                            {
                                addrtype = 2;
                                break;
                            }
                        case "Billing":
                            {
                                addrtype = 1;
                                break;
                            }
                        case "Main Office":
                            {
                                addrtype = 3;
                                break;
                            }
                        case "Primary":
                            {
                                addrtype = 4;
                                break;
                            }
                        case "Shipping":
                            {
                                addrtype = 5;
                                break;
                            }
                        case "Archive":
                            {
                                addrtype = 6;
                                break;
                            }
                    }

                    string regquery = "insert into Person.BusinessEntity " +
                        "values(NEWID(), GETDATE()) " +
                        "declare @bid int; " +
                        "set @bid = (select max(Person.BusinessEntity.BusinessEntityID) " +
                        "from Person.BusinessEntity) " +
                        "insert into Person.Person(BusinessEntityID, PersonType, NameStyle, FirstName, MiddleName, LastName, EmailPromotion, rowguid, ModifiedDate) " +
                        $"values(@bid, '{personType.Replace("'", "''")}', 0, '{firstname.Replace("'", "''")}', '{middlename.Replace("'", "''")}', '{lastname.Replace("'", "''")}', 0, NEWID(), GETDATE()); " +
                        "insert into Person.Address " +
                        $"values('{address1.Replace("'", "''")}', '{address2.Replace("'", "''")}', '{city.Replace("'", "''")}', 79, '{postalcode}', null, NEWID(), GETDATE()) " +
                        "declare @aid int; " +
                        "set @aid = (select max(Person.Address.AddressID) " +
                        "from Person.Address) " +
                        "insert into Person.BusinessEntityAddress " +
                        $"values(@bid, @aid, {addrtype}, NEWID(), GETDATE()) " +
                        "insert into sales.Customer(PersonID, StoreID, TerritoryID) " +
                        $"values(@bid, {storeid}, {territoryID}) ";
                    SqlConnection conn2 = new SqlConnection(Classes.SQLConnection.connectionString);
                    SqlCommand command2 = new SqlCommand(regquery, conn2);
                    conn2.Open();
                    command2.ExecuteNonQuery();
                    conn2.Close();
                    MessageBox.Show("New customer added.");
                    Customers.PanelContainer.Visible = false;
                    LoadCustomers();
                    this.Dispose();
                    this.Close();               
                }
                else
                {
                    storeid = 0;
                    switch (territoryIDkey)
                    {
                        case "1. Northwest - US":
                            {
                                territoryID = 1;
                                break;
                            }
                        case "2. Northeast - US":
                            {
                                territoryID = 2;
                                break;
                            }
                        case "3. Central - US":
                            {
                                territoryID = 3;
                                break;
                            }
                        case "24. Southwest - US":
                            {
                                territoryID = 4;
                                break;
                            }
                        case "5. Southeast - US":
                            {
                                territoryID = 5;
                                break;
                            }
                        case "6. Canada - CA":
                            {
                                territoryID = 6;
                                break;
                            }
                        case "7. France - FR":
                            {
                                territoryID = 7;
                                break;
                            }
                        case "8. Germany - DE":
                            {
                                territoryID = 8;
                                break;
                            }
                        case "9. Australia - AU":
                            {
                                territoryID = 9;
                                break;
                            }
                        case "10. United Kingdom - UK":
                            {
                                territoryID = 10;
                                break;
                            }
                        default:
                            {
                                territoryID = 1;
                                break;
                            }
                    }
                    switch (addresstype)
                    {
                        case "Home":
                            {
                                addrtype = 2;
                                break;
                            }
                        case "Billing":
                            {
                                addrtype = 1;
                                break;
                            }
                        case "Main Office":
                            {
                                addrtype = 3;
                                break;
                            }
                        case "Primary":
                            {
                                addrtype = 4;
                                break;
                            }
                        case "Shipping":
                            {
                                addrtype = 5;
                                break;
                            }
                        case "Archive":
                            {
                                addrtype = 6;
                                break;
                            }
                    }
                    string regquery2 = "insert into Person.BusinessEntity " +
                        "values(NEWID(), GETDATE()) " +
                        "declare @bid int; " +
                        "set @bid = (select max(Person.BusinessEntity.BusinessEntityID) " +
                        "from Person.BusinessEntity) " +
                        "insert into Person.Person(BusinessEntityID, PersonType, NameStyle, FirstName, MiddleName, LastName, EmailPromotion, rowguid, ModifiedDate) " +
                        $"values(@bid, '{personType.Replace("'", "''")}', 0, '{firstname.Replace("'", "''")}', '{middlename.Replace("'", "''")}', '{lastname.Replace("'", "''")}', 0, NEWID(), GETDATE()); " +
                        "insert into Person.Address " +
                        $"values('{address1.Replace("'", "''")}', '{address2.Replace("'", "''")}', '{city.Replace("'", "''")}', 79, '{postalcode}', null, NEWID(), GETDATE()) " +
                        "declare @aid int; " +
                        "set @aid = (select max(Person.Address.AddressID) " +
                        "from Person.Address) " +
                        "insert into Person.BusinessEntityAddress " +
                        $"values(@bid, @aid, {addrtype}, NEWID(), GETDATE()) " +
                        "insert into sales.Customer(PersonID, StoreID, TerritoryID) " +
                        $"values(@bid, NULL, {territoryID}) ";
                    SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
                    SqlCommand command = new SqlCommand(regquery2, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("New customer added.");
                    Customers.PanelContainer.Visible = false;
                    LoadCustomers();
                    this.Dispose();
                    this.Close();  
                }
            }
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            string str_name = txt_filter_stores.Text.ToString();
            string filterquery = $"{Query} where Name Like '%{str_name.Replace("'", "''")}%'";
            this.dataGridView1.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(filterquery, this.dataGridView1);
        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key;
            key = combo_type.SelectedItem.ToString();
            if (key == "Store Contact")
            {
                panel3.Enabled = true;
            }
            else if (key == "Individual Customer")
            {
                panel3.Enabled = false;
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {
            combo_type.SelectedItem = "Individual Customer";
            combo_region.SelectedItem = "- - - Select region - - -";
            combo_addresstype.SelectedItem = "Home";
            this.dataGridView1.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(Query, this.dataGridView1);
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Customers.PanelContainer.Visible = false;
            Customers.GridCustomers.Visible = true;
            this.Dispose();
            this.Close();
        }
    }
}
