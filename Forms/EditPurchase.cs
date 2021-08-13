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
    public partial class EditPurchase : Form
    {

        DataTable table = new DataTable();
        DataRow row;
        DataColumn column;

        public EditPurchase()
        {
            InitializeComponent();
            getOrder();
            InitColumns();
        }

        private void getOrder()
        {
            string detailsquery = $"select PurchaseOrderID, OrderQty,ProductID,ReceivedQty,RejectedQty from Purchasing.PurchaseOrderDetail where PurchaseOrderID = {Forms.Home.PohID}";
            SQLConnection.ReadDataFillGrid(detailsquery, this.dataGridView1);
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = true;
            this.dataGridView1.Columns[4].ReadOnly = true;
        }

        private void InitColumns()
        {
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "prodid";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "received";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "rejected";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "locid";
            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "prevQty";
            table.Columns.Add(column);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowcount = -1;
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 0 &&
                e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm action?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int prodid = 0, received = 0, rejected = 0, locid = 0, prevQty = 0;
                    prodid = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());

                    row = table.NewRow();
                    row["prodid"] = prodid;
                    row["received"] = received;
                    row["rejected"] = rejected;
                    row["locid"] = locid;
                    row["prevQty"] = prevQty;
                    table.Rows.Add(row);
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                    rowcount = this.dataGridView1.RowCount;
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 1 &&
                e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm action?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int prodid = 0, received = 0, rejected = 0, locid = 0, prevQty = 0;
                    prodid = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    received = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                    rejected = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
                    SqlConnection conn = new SqlConnection(SQLConnection.connectionString);
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
                                          $"where cte1.Quantity = cte2.MinQuantity and cte1.ProductID = {dataGridView1.CurrentRow.Cells[4].Value} " +
                                          "group by cte2.MinQuantity";
                    conn.Open();
                    SqlCommand command = new SqlCommand(LocAndQty, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        locid = int.Parse(reader.GetValue(0).ToString());
                        prevQty = int.Parse(reader.GetValue(1).ToString());
                    }
                    reader.Close();
                    conn.Close();
                    prevQty = received + prevQty - rejected;
                    row = table.NewRow();
                    row["prodid"] = prodid;
                    row["received"] = received;
                    row["rejected"] = rejected;
                    row["locid"] = locid;
                    row["prevQty"] = prevQty;
                    table.Rows.Add(row);
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                    rowcount = this.dataGridView1.RowCount;
                }
            }
            if (rowcount == 0)
            {
                SqlConnection conn = new SqlConnection(SQLConnection.connectionString);
                SqlCommand command;
                foreach (DataRow rows in table.Rows)
                {
                    if (int.Parse(rows["received"].ToString()) == 0)
                    {
                        string updateQuery = $"update Purchasing.PurchaseOrderDetail set ReceivedQty = 0 , RejectedQty = 0, ModifiedDate=GETDATE() where PurchaseOrderID = {Forms.Home.PohID} and ProductID = {int.Parse(rows["prodid"].ToString())}";
                        command = new SqlCommand(updateQuery, conn);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    else if (int.Parse(rows[1].ToString()) != 0)
                    {
                        string updateQuery = $"update Purchasing.PurchaseOrderDetail set ReceivedQty = {int.Parse(rows["received"].ToString())} , RejectedQty = {int.Parse(rows["rejected"].ToString())}, ModifiedDate=GETDATE() where PurchaseOrderID = {Forms.Home.PohID} and ProductID = {int.Parse(rows["prodid"].ToString())}";
                        command = new SqlCommand(updateQuery, conn);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                        string updateInventory = $"update Production.ProductInventory set Quantity = {int.Parse(rows["prevQty"].ToString())}, ModifiedDate=GETDATE() where ProductID = {int.Parse(rows["prodid"].ToString())} and LocationID = {int.Parse(rows["locid"].ToString())}";
                        command = new SqlCommand(updateInventory, conn);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                string updHeader = $"update Purchasing.PurchaseOrderHeader set Status = 4 , ModifiedDate=GETDATE() where PurchaseOrderID = {Forms.Home.PohID}";
                command = new SqlCommand(updHeader, conn);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                table.Rows.Clear();
                Forms.Home.OrderGrid.DataSource = null;
                SQLConnection.ReadDataFillGrid(Forms.Home.PurchaseQ, Forms.Home.OrderGrid);
                Forms.Home.PanelPurchaseEdit.Visible = false;
                this.Dispose();
                this.Close();
                MessageBox.Show("Completed");
            }
        }

        private void btn_complete_order_Click(object sender, EventArgs e)
        {
            int prodID = 0, received = 0, rejected = 0, LocID = 0, prevQty = 0;
            DialogResult dialogResult = MessageBox.Show("Confirm action?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(SQLConnection.connectionString);
                SqlCommand command;
                SqlDataReader reader;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    prodID = int.Parse(row.Cells[4].Value.ToString());
                    received = Convert.ToInt32(row.Cells[5].Value);
                    rejected = Convert.ToInt32(row.Cells[6].Value);
                    string updateQuery = $"update Purchasing.PurchaseOrderDetail set ReceivedQty = {received} , RejectedQty = {rejected}, ModifiedDate=GETDATE() where PurchaseOrderID = {Forms.Home.PohID} and ProductID = {prodID}";
                    command = new SqlCommand(updateQuery, conn);
                    conn.Open();
                    command.ExecuteNonQuery();

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
                                              $"where cte1.Quantity = cte2.MinQuantity and cte1.ProductID = {prodID} " +
                                              "group by cte2.MinQuantity";
                    command = new SqlCommand(LocAndQty, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        LocID = int.Parse(reader.GetValue(0).ToString());
                        prevQty = int.Parse(reader.GetValue(1).ToString());
                    }
                    reader.Close();
                    string updateInventory = $"update Production.ProductInventory set Quantity = {prevQty}, ModifiedDate=GETDATE() where ProductID = {prodID} and LocationID = {LocID}";
                    command = new SqlCommand(updateInventory, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                string updHeader = $"update Purchasing.PurchaseOrderHeader set Status = 4 , ModifiedDate=GETDATE() where PurchaseOrderID = {Forms.Home.PohID}";
                command = new SqlCommand(updHeader, conn);
                conn.Open();
                command.ExecuteNonQuery();
                Forms.Home.OrderGrid.DataSource = null;
                SQLConnection.ReadDataFillGrid(Forms.Home.PurchaseQ, Forms.Home.OrderGrid);
                Forms.Home.PanelPurchaseEdit.Visible = false;
                this.Dispose();
                this.Close();
                MessageBox.Show("Completed");
            }
        }
    }
}
