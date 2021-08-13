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

namespace app3rework
{
    public partial class Main : Form
    {
        public static Panel PanelDash { get; set; }

        public Main()
        {
            InitializeComponent();
            LoadHome();
            GetUserInfo();
            PanelDash = panelDashboard;
            this.panelMenu.Width = 65;
        }

        private void LoadHome()
        {
            this.panelDashboard.Controls.Clear();
            Forms.Home home = new Forms.Home();
            home.TopLevel = false;
            home.TopMost = true;
            home.Dock = DockStyle.Fill;
            this.panelDashboard.Controls.Add(home);
            home.Show();
        }

        private void LoadCustomers()
        {
            this.panelDashboard.Controls.Clear();
            Forms.Customers customers = new Forms.Customers();
            customers.TopLevel = false;
            customers.TopMost = true;
            customers.Dock = DockStyle.Fill;
            this.panelDashboard.Controls.Add(customers);
            customers.Show();
        }

        private void LoadInventory()
        {
            this.panelDashboard.Controls.Clear();
            Forms.Inventory inventory = new Forms.Inventory();
            inventory.TopLevel = false;
            inventory.TopMost = true;
            inventory.Dock = DockStyle.Fill;
            this.panelDashboard.Controls.Add(inventory);
            inventory.Show();
        }

        private void LoadOrders()
        {
            this.panelDashboard.Controls.Clear();
            Forms.Orders orders = new Forms.Orders();
            orders.TopLevel = false;
            orders.TopMost = true;
            orders.Dock = DockStyle.Fill;
            this.panelDashboard.Controls.Add(orders);
            orders.Show();
        }

        private void LoadStores()
        {
            this.panelDashboard.Controls.Clear();
            Forms.Stores stores = new Forms.Stores();
            stores.TopLevel = false;
            stores.TopMost = true;
            stores.Dock = DockStyle.Fill;
            this.panelDashboard.Controls.Add(stores);
            stores.Show();
        }

        private void GetUserInfo()
        {
            lbl_Name.Text = Core.Login.UserName;
            lbl_ID.Text = Core.Login.UserID.ToString();
        }

        private void labelHomeClick_Click(object sender, EventArgs e)
        {
            var stores = Application.OpenForms["Stores"];
            if (stores == null) { }
            else { stores.Dispose(); stores.Close(); }
            var orders = Application.OpenForms["Orders"];
            if (orders == null) { }
            else { orders.Dispose(); orders.Close(); }
            var inventory = Application.OpenForms["Inventory"];
            if (inventory == null) { }
            else { inventory.Dispose(); inventory.Close(); }
            var customers = Application.OpenForms["Customers"];
            if (customers == null) { }
            else { customers.Dispose(); customers.Close(); }
            var home = Application.OpenForms["Home"];
            if (home == null) { LoadHome(); }
            else { home.Dispose(); home.Close(); LoadHome(); }
        }

        private void labelCustomersClick_Click(object sender, EventArgs e)
        {
            var stores = Application.OpenForms["Stores"];
            if (stores == null) { }
            else { stores.Dispose(); stores.Close(); }
            var orders = Application.OpenForms["Orders"];
            if (orders == null) { }
            else { orders.Dispose(); orders.Close(); }
            var inventory = Application.OpenForms["Inventory"];
            if (inventory == null) { }
            else { inventory.Dispose(); inventory.Close(); }
            var home = Application.OpenForms["Home"];
            if (home == null) { }
            else { home.Dispose(); home.Close(); }
            var customers = Application.OpenForms["Customers"];
            if (customers == null) { LoadCustomers(); }
            else { customers.Dispose(); customers.Close(); LoadCustomers(); }
        }

        private void labelProductsClick_Click(object sender, EventArgs e)
        {
            var stores = Application.OpenForms["Stores"];
            if (stores == null) { }
            else { stores.Dispose(); stores.Close(); }
            var orders = Application.OpenForms["Orders"];
            if (orders == null) { }
            else { orders.Dispose(); orders.Close(); }
            var home = Application.OpenForms["Home"];
            if (home == null) { }
            else { home.Dispose(); home.Close(); }
            var customers = Application.OpenForms["Customers"];
            if (customers == null) { }
            else { customers.Dispose(); customers.Close(); }
            var inventory = Application.OpenForms["Inventory"];
            if (inventory == null) { LoadInventory(); }
            else { inventory.Dispose(); inventory.Close(); LoadInventory(); }
        }

        private void labelOrdersClick_Click(object sender, EventArgs e)
        {
            var stores = Application.OpenForms["Stores"];
            if (stores == null) { }
            else { stores.Dispose(); stores.Close(); }
            var inventory = Application.OpenForms["Inventory"];
            if (inventory == null) { }
            else { inventory.Dispose(); inventory.Close(); }
            var customers = Application.OpenForms["Customers"];
            if (customers == null) { }
            else { customers.Dispose(); customers.Close(); }
            var home = Application.OpenForms["Home"];
            if (home == null) { }
            else { home.Dispose(); home.Close(); }
            var orders = Application.OpenForms["Orders"];
            if (orders == null) { LoadOrders(); }
            else { orders.Dispose(); orders.Close(); LoadOrders(); }
        }

        private void labelStoresClick_Click(object sender, EventArgs e)
        {
            var inventory = Application.OpenForms["Inventory"];
            if (inventory == null) { }
            else { inventory.Dispose(); inventory.Close(); }
            var customers = Application.OpenForms["Customers"];
            if (customers == null) { }
            else { customers.Dispose(); customers.Close(); }
            var home = Application.OpenForms["Home"];
            if (home == null) { }
            else { home.Dispose(); home.Close(); }
            var orders = Application.OpenForms["Orders"];
            if (orders == null) { }
            else { orders.Dispose(); orders.Close(); }
            var stores = Application.OpenForms["Stores"];
            if (stores == null) { LoadStores(); }
            else { stores.Dispose(); stores.Close(); LoadStores(); }
        }

        private void labelSwapClick_Click(object sender, EventArgs e)
        {
            if (panelMenuChangeUser.Visible == false)
            {
                panelMenuChangeUser.Visible = true;
            }
            else if (panelMenuChangeUser.Visible == true)
            {
                panelMenuChangeUser.Visible = false;
            }
        }

        private void labelLogoutClick_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
                Core.Login login = new Core.Login();
                login.Show();
            }
        }

        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_MenuOptions_Click(object sender, EventArgs e)
        {
            if(this.panelMenu.Width != 216)
            {
                this.panelDashboard.Visible = false;
                this.panelMenu.Width = 216;
                this.panelDashboard.Visible = true;
                panelNavContainer.Visible = false;
                panelNavContOpen.Visible = true;
                this.panelUserInfo.Visible = true;
            }        
            if (panelMenuBotOptions.Visible == false)
            {
                panelMenuBotOptions.Visible = true;
            }
            else if(panelMenuBotOptions.Visible == true)
            {
                panelMenuBotOptions.Visible = false;
                panelMenuChangeUser.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelMenuChangeUser.Visible = false;
        }

        private void btn_MenuOptions_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_MenuControl_Click(object sender, EventArgs e)
        {
            this.panelDashboard.Visible = false;
            if(this.panelMenu.Width == 65)
            {
                this.panelMenu.Width = 216;
                panelNavContainer.Visible = false;
                panelNavContOpen.Visible = true;
                panelUserInfo.Visible = true;
            }
            else if(this.panelMenu.Width == 216)
            {
                panelMenuBotOptions.Visible = false;
                panelMenuChangeUser.Visible = false;
                panelNavContainer.Visible = true;
                panelNavContOpen.Visible = false;
                panelUserInfo.Visible = false;
                this.panelMenu.Width = 65;
            }
            this.panelDashboard.Visible = true;
        }

        private void btn_employenum_Click(object sender, EventArgs e)
        {
            int parseresault;
            bool tryparse;
            if (txt_employenum.Text == "")
            {

            }
            else
            {
                tryparse = Int32.TryParse(txt_employenum.Text, out parseresault);
                if (tryparse && parseresault >= 274 && parseresault <= 290)
                {
                    Core.Login.UserID = parseresault;
                    string Fname, Mname, Lname;
                    string fullname = $"select FirstName, MiddleName, LastName as FullName from person.Person where BusinessEntityID = {Core.Login.UserID}";
                    SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
                    SqlCommand command = new SqlCommand(fullname, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Fname = reader.GetValue(0).ToString();
                        Mname = reader.GetValue(1).ToString();
                        Lname = reader.GetValue(2).ToString();
                        Core.Login.UserName = $"{Fname} {Mname} {Lname}";
                    }
                    reader.Close();
                    conn.Close();
                    GetUserInfo();
                }
            }
        }


    }
}
