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
    public partial class Invoice : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        Bitmap bitmap;

        private int wid, hei;

        public Invoice()
        {
            InitializeComponent();
            getinvoice();
            wid = this.Width;
            hei = this.Height;
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            btn_Print.Hide();
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(size.Width, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);
            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            btn_Print.Show();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, e.PageBounds);
        }

        public void getinvoice()
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            bool data = false;
            if (date[0].ToString() == "0")
            {
                date = date.Remove(0, 1);
                data = true;
            }
            if (data == true)
            {
                if (date[2].ToString() == "0")
                {
                    date = date.Remove(2, 1);
                }
            }
            else
            {
                if (date[3].ToString() == "0")
                {
                    date = date.Remove(3, 1);
                }
            }
            string addrID = "select AddressID from Person.BusinessEntityAddress pba " +
                                    "join Sales.Customer sc " +
                                    "on pba.BusinessEntityID = sc.StoreID or pba.BusinessEntityID = sc.PersonID " +
                                    $"where CustomerID = {Orders.Cid}";
            int addressID = 0;
            SqlConnection myConnection = new SqlConnection(SQLConnection.connectionString);
            SqlCommand command = new SqlCommand(addrID, myConnection);
            myConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                addressID = int.Parse(reader.GetValue(0).ToString());
            }
            reader.Close();
            string Address = "select AddressLine1,City,PostalCode from Person.Address " +
                                        $"where AddressID = {addressID}";
            command = new SqlCommand(Address, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                label16.Text = reader.GetValue(0).ToString();
                label17.Text = reader.GetValue(1).ToString();
                label18.Text = reader.GetValue(2).ToString();
            }
            reader.Close();

            label12.Text = Orders.Fname;
            label13.Text = Orders.Sonum;
            label14.Text = Orders.OrderDate.Remove(Orders.OrderDate.Length - 11);
            label15.Text = date;

            string salequery = $"select SubTotal,TaxAmt,Freight,TotalDue from Sales.SalesOrderHeader where SalesOrderNumber = '{Orders.Sonum}'";
            command = new SqlCommand(salequery, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_notaxCost.Text = reader.GetValue(0).ToString() + " €";
                lbl_taxCost.Text = reader.GetValue(1).ToString() + " €";
                lbl_ShipCost.Text = reader.GetValue(2).ToString() + " €";
                lbl_totalCost.Text = reader.GetValue(3).ToString() + " €";
            }
            reader.Close();
            Orders.Sonum = Orders.Sonum.Remove(0, 2);
            string details = "select pp.Name,OrderQty,UnitPrice,LineTotal from Sales.SalesOrderDetail sod " +
                                "join Production.Product pp " +
                                "on sod.ProductID = pp.ProductID " +
                                $"where SalesOrderID = {Orders.Sonum}";
            command = new SqlCommand(details, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem();
                list.Text = reader.GetValue(0).ToString();
                list.SubItems.Add(reader.GetValue(1).ToString());
                list.SubItems.Add(reader.GetValue(2).ToString());
                list.SubItems.Add(reader.GetValue(3).ToString());
                listView1.Items.Add(list);
            }
            reader.Close();
            myConnection.Close();
        }
    }
}
