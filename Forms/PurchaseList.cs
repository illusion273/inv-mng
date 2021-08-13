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
    public partial class PurchaseList : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        public string purchaselist;

        public PurchaseList()
        {
            InitializeComponent();
            GetList();
            this.TopLevel = true;
            this.TopMost = false;
            nonsortableColumns();
        }

        private void GetList()
        {
            purchaselist = "select * from PurchaseList order by VendorID";
            Classes.SQLConnection.ReadDataFillGrid(purchaselist, this.dataGridView1);
        }

        private void nonsortableColumns()
        {
            foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btn_submitOrder_Click(object sender, EventArgs e)
        {
            int rowcount = this.dataGridView1.RowCount;
            if (rowcount != 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Place Order ? ", "Confirm ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int emplid = Core.Login.UserID;
                    //Temp insert DUMMY
                    string insertHeaderTEMP = $"insert into Purchasing.PurchaseOrderHeader values(1,1,{emplid},1699,1,GETDATE(),null,0,0,3.95,GETDATE())";
                    SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                    SqlCommand command = new SqlCommand(insertHeaderTEMP, myConnection);
                    myConnection.Open();
                    command.ExecuteNonQuery();
                    myConnection.Close();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int lastorderNum = 0, CurrVendor, LastVendor = 0; ;
                        string lastOrderID = "select max(PurchaseOrderID) from Purchasing.PurchaseOrderHeader";
                        myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                        command = new SqlCommand(lastOrderID, myConnection);
                        myConnection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            lastorderNum = int.Parse(reader.GetValue(0).ToString());
                        }
                        reader.Close();
                        string LastVendorID = "select VendorID from Purchasing.PurchaseOrderHeader " +
                                                $"where PurchaseOrderID = {lastorderNum}";
                        command = new SqlCommand(LastVendorID, myConnection);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            LastVendor = int.Parse(reader.GetValue(0).ToString());
                        }
                        reader.Close();
                        CurrVendor = int.Parse(row.Cells[1].Value.ToString());
                        if (CurrVendor != LastVendor && CurrVendor != 1700)
                        {
                            // INSERT STON HEADER 
                            string insertHeader = $"insert into Purchasing.PurchaseOrderHeader values(1,1,{emplid},{CurrVendor},1,GETDATE(),null,0,0,3.95,GETDATE())";
                            command = new SqlCommand(insertHeader, myConnection);
                            command.ExecuteNonQuery();
                            //NEO SALEORDERID
                            command = new SqlCommand(lastOrderID, myConnection);
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                lastorderNum = int.Parse(reader.GetValue(0).ToString());
                            }
                            reader.Close();
                            // INSERT STON DETAIL
                            string insertDetail = $"insert into Purchasing.PurchaseOrderDetail values({lastorderNum},getdate() + 7,{int.Parse(row.Cells[3].Value.ToString())},{int.Parse(row.Cells[2].Value.ToString())},{double.Parse(row.Cells[4].Value.ToString(), cultureUS)},{int.Parse(row.Cells[3].Value.ToString())},0,GETDATE())";
                            command = new SqlCommand(insertDetail, myConnection);
                            command.ExecuteNonQuery();
                            string updateHeader = $"update Purchasing.PurchaseOrderHeader set TaxAmt = (select SubTotal from purchasing.PurchaseOrderHeader where PurchaseOrderID = {lastorderNum})*0.24 where PurchaseOrderID = {lastorderNum}";
                            command = new SqlCommand(updateHeader, myConnection);
                            //Update TON HEADER
                            command.ExecuteNonQuery();
                        }
                        else if (CurrVendor == LastVendor && CurrVendor != 1700)
                        {
                            // INSERT STON DETAIL
                            string insertDetail = $"insert into Purchasing.PurchaseOrderDetail values({lastorderNum},getdate() + 7,{int.Parse(row.Cells[3].Value.ToString())},{int.Parse(row.Cells[2].Value.ToString())},{double.Parse(row.Cells[4].Value.ToString(), cultureUS)},{int.Parse(row.Cells[3].Value.ToString())},0,GETDATE())";
                            command = new SqlCommand(insertDetail, myConnection);
                            //Update TON HEADER
                            command.ExecuteNonQuery();
                            string updateHeader = $"update Purchasing.PurchaseOrderHeader set TaxAmt = (select SubTotal from purchasing.PurchaseOrderHeader where PurchaseOrderID = {lastorderNum})*0.24 where PurchaseOrderID = {lastorderNum}";
                            command = new SqlCommand(updateHeader, myConnection);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            string quickwork = $"insert into Production.WorkOrder values({int.Parse(row.Cells[2].Value.ToString())},{int.Parse(row.Cells[3].Value.ToString())},0,GETDATE(),null,GETDATE()+15,null,GETDATE())";
                            command = new SqlCommand(quickwork, myConnection);
                            command.ExecuteNonQuery();
                        }
                        myConnection.Close();
                    }
                    // SBHNOYME APO TON HEADER TO Temp INSERT
                    string deltemp = "delete from Purchasing.PurchaseOrderHeader where VendorID = 1699";
                    command = new SqlCommand(deltemp, myConnection);
                    myConnection.Open();
                    command.ExecuteNonQuery();
                    string emptylist = "delete from PurchaseList";
                    command = new SqlCommand(emptylist, myConnection);
                    command.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Orders placed Successfully");
                    this.Dispose();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error, List is Empty");
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(purchaselist, this.dataGridView1);
            nonsortableColumns();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Clear List ? ", "Confirm ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string clearlist = "delete from PurchaseList";
                SqlConnection myConnection = new SqlConnection(Classes.SQLConnection.connectionString);
                SqlCommand command = new SqlCommand(clearlist, myConnection);
                myConnection.Open();
                command.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("List Cleared");
                this.dataGridView1.DataSource = null;
                Classes.SQLConnection.ReadDataFillGrid(purchaselist, this.dataGridView1);
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No product selected");
            }
            else if (this.dataGridView1.SelectedRows.Count == 1)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
            }
        }
    }
}
