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
    public partial class EditSale : Form
    {
        public EditSale()
        {
            InitializeComponent();
            getSaleOrder();
        }

        private void getSaleOrder()
        {
            string detailsquery = $"select SalesOrderID, OrderQty,ProductID,LineTotal from Sales.SalesOrderDetail where SalesOrderID = {Forms.Home.SohID}";
            SQLConnection.ReadDataFillGrid(detailsquery, this.dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int rowcount = dataGridView1.RowCount;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 1 &&
                e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm Shipping?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string updHeader = $"update Sales.SalesOrderHeader set Status = 5, ModifiedDate=GETDATE() where SalesOrderID = {Forms.Home.SohID}";
                    SqlConnection conn = new SqlConnection(SQLConnection.connectionString);
                    SqlCommand command = new SqlCommand(updHeader, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    this.dataGridView1.DataSource = null;
                    Forms.Home.OrderGrid.DataSource = null;
                    SQLConnection.ReadDataFillGrid(Forms.Home.SaleQ, Forms.Home.OrderGrid);
                    Forms.Home.PanelSaleEdit.Visible = false;
                    this.Dispose();
                    this.Close();
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 0 &&
                e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm Cancellation?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(SQLConnection.connectionString);
                    int LocID = 0;
                    int OrderQty = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    int OrderPrID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                    int OldQty = 0;
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
                        LocID = int.Parse(reader.GetValue(0).ToString());
                        OldQty = int.Parse(reader.GetValue(1).ToString());

                    }
                    reader.Close();
                    conn.Close();
                    OldQty += OrderQty;
                    string updateInventory = $"update Production.ProductInventory set Quantity = {OldQty}, ModifiedDate=GETDATE() where ProductID = {dataGridView1.CurrentRow.Cells[4].Value} and LocationID = {LocID}";
                    command = new SqlCommand(updateInventory, conn);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                    if (rowcount == 1)
                    {
                        string updHeader = $"update Sales.SalesOrderHeader set Status = 6, ModifiedDate=GETDATE() where SalesOrderID = {Forms.Home.SohID}";
                        command = new SqlCommand(updHeader, conn);
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                        this.dataGridView1.DataSource = null;
                        Forms.Home.OrderGrid.DataSource = null;
                        SQLConnection.ReadDataFillGrid(Forms.Home.SaleQ, Forms.Home.OrderGrid);
                        Forms.Home.PanelSaleEdit.Visible = false;
                        this.Dispose();
                        this.Close();
                    }
                }
            }
        }
    }
}
