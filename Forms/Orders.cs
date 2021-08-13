using app3rework.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app3rework.Forms
{
    public partial class Orders : Form
    {
        System.IFormatProvider cultureUS =
        new System.Globalization.CultureInfo("en-US");

        public string SaleQuery { get; set; }
        public string PurchaseQuery { get; set; }
        public static int Cid { get; set; }
        public static string Fname { get; set; }
        public static string Sonum { get; set; }
        public static string OrderDate { get; set; }

        public Orders()
        {
            InitializeComponent();
            InitQueries();
            GetSaleOrders();      
        }

        private void InitQueries()
        {
            this.SaleQuery = "SELECT soh.SalesOrderID, soh.customerID,CONCAT(per.FirstName + ' ', per.MiddleName + ' ', per.LastName) AS FullName, " +
                "soh.SalesOrderNumber,soh.PurchaseOrderNumber,soh.Status, soh.OrderDate,soh.DueDate,soh.ShipDate, " +
                "Name AS  " + "'Store Name'" + " , soh.TotalDue " +
                "FROM Sales.SalesOrderHeader soh " +
                "JOIN sales.Customer SC " +
                "on soh.CustomerID = sc.CustomerID " +
                "join Person.Person per " +
                "ON SC.PersonID = per.BusinessEntityID " +
                "full outer join Sales.Store SST " +
                "ON SC.StoreID = SST.BusinessEntityID " +
                "WHERE SalesOrderID IS NOT NULL";
            this.PurchaseQuery = "select PurchaseOrderID,Status,pp.FirstName+' '+pp.MiddleName+' '+pp.LastName as 'Employee Name',v.Name as Vendor,OrderDate," +
                                    "ShipDate,SubTotal,TaxAmt,Freight,TotalDue from Purchasing.PurchaseOrderHeader poh " +
                                    "join Person.Person pp on poh.EmployeeID = pp.BusinessEntityID " +
                                    "join Purchasing.Vendor v on poh.VendorID = v.BusinessEntityID";
        }

        private void GetSaleOrders()
        {
            this.gridOrders.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(SaleQuery, this.gridOrders);
        }
        private void GetPurchaseOrders()
        {
            this.gridOrders.DataSource = null;
            Classes.SQLConnection.ReadDataFillGrid(PurchaseQuery, this.gridOrders);
        }

        private void buttonSaleStat_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            gridOrders.Dock = DockStyle.Fill;
            if (panel_purchases.Visible == true)
                panel_purchases.Visible = false;
            if (panel1.Visible == true)
                panel1.Visible = false;
            if (panel_sales.Visible == false)
                panel_sales.Visible = true;
            else if (panel_sales.Visible == true)
                panel_sales.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void buttonPurchaseStat_Click(object sender, EventArgs e)
        {
            gridOrders.Dock = DockStyle.Fill;
            chart1.Visible = false;
            if (panel_sales.Visible == true)
                panel_sales.Visible = false;
            if (panel1.Visible == true)
                panel1.Visible = false;
            if (panel_purchases.Visible == false)
                panel_purchases.Visible = true;

            else if (panel_purchases.Visible == true)
                panel_purchases.Visible = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
        }

        private void buttonGraphs_Click(object sender, EventArgs e)
        {
            if (panel_sales.Visible == true)
                panel_sales.Visible = false;

            if (panel_purchases.Visible == true)
                panel_purchases.Visible = false;
            if (panel1.Visible == false)
                panel1.Visible = true;
            else if (panel1.Visible == true)
            {
                gridOrders.Dock = DockStyle.Fill;
                panel1.Visible = false;
            }
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
        }

        private void btn_sales_filter_search_Click(object sender, EventArgs e)
        {
            string key;
            string input = textBox1.Text;
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
                this.gridOrders.DataSource = null;
                key = comboBox1.SelectedItem.ToString();
                switch (key)
                {
                    case "Store Name":
                        {
                            string searchquery = $"{SaleQuery} and Name LIKE '%{input.Replace("'", "''")}%'";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Store Name input");
                            }
                            break;
                        }
                    case "Customer Last Name":
                        {
                            string searchquery = $"{SaleQuery} and LastName like '%{input.Replace("'", "''")}%'";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Customer Last Name input");
                            }
                            break;
                        }

                    case "Sale Order Number":
                        {
                            string searchquery = $"{SaleQuery} and SalesOrderNumber LIKE '%{input.Replace("'", "''")}%'";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Sale Order Number input");
                            }
                            break;
                        }
                    case "Purchase Order Number":
                        {
                            string searchquery = $"{SaleQuery} and PurchaseOrderNumber LIKE '%{input.Replace("'", "''")}%'";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Purchase Order Number input");
                            }
                            break;
                        }
                    case "CustomerID":
                        {
                            string searchquery = $"{SaleQuery} and soh.CustomerID like '%{input.Replace("'", "''")}%'";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(searchquery, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect CustomerID input");
                            }
                            break;
                        }
                    case "Purchase Order ID":
                        {
                            string purchaseList = "select PurchaseOrderID,Status,pp.FirstName+' '+pp.MiddleName+' '+pp.LastName as 'Employee Name',v.Name as Vendor,OrderDate," +
                                    "ShipDate,SubTotal,TaxAmt,Freight,TotalDue from Purchasing.PurchaseOrderHeader poh " +
                                    "join Person.Person pp on poh.EmployeeID = pp.BusinessEntityID " +
                                    $"join Purchasing.Vendor v on poh.VendorID = v.BusinessEntityID where PurchaseOrderID = {input.Replace("'", "''")}";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(purchaseList, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Purchase Order ID input");
                            }
                            break;
                        }
                    case "Status":
                        {
                            string purchaseList = "select PurchaseOrderID,Status,pp.FirstName+' '+pp.MiddleName+' '+pp.LastName as 'Employee Name',v.Name as Vendor,OrderDate," +
                                    "ShipDate,SubTotal,TaxAmt,Freight,TotalDue from Purchasing.PurchaseOrderHeader poh " +
                                    "join Person.Person pp on poh.EmployeeID = pp.BusinessEntityID " +
                                    $"join Purchasing.Vendor v on poh.VendorID = v.BusinessEntityID where Status = {input.Replace("'", "''")}";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(purchaseList, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Status input");
                            }
                            break;
                        }
                    case "Employee ID":
                        {
                            string purchaseList = "select PurchaseOrderID,Status,pp.FirstName+' '+pp.MiddleName+' '+pp.LastName as 'Employee Name',v.Name as Vendor,OrderDate," +
                                    "ShipDate,SubTotal,TaxAmt,Freight,TotalDue from Purchasing.PurchaseOrderHeader poh " +
                                    "join Person.Person pp on poh.EmployeeID = pp.BusinessEntityID " +
                                    $"join Purchasing.Vendor v on poh.VendorID = v.BusinessEntityID where EmployeeID = {input.Replace("'", "''")}";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(purchaseList, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Employee ID input");
                            }
                            break;
                        }
                    case "Vendor ID":
                        {
                            string purchaseList = "select PurchaseOrderID,Status,pp.FirstName+' '+pp.MiddleName+' '+pp.LastName as 'Employee Name',v.Name as Vendor,OrderDate," +
                                    "ShipDate,SubTotal,TaxAmt,Freight,TotalDue from Purchasing.PurchaseOrderHeader poh " +
                                    "join Person.Person pp on poh.EmployeeID = pp.BusinessEntityID " +
                                    $"join Purchasing.Vendor v on poh.VendorID = v.BusinessEntityID where VendorID = {input.Replace("'", "''")}";
                            try
                            {
                                Classes.SQLConnection.ReadDataFillGrid(purchaseList, this.gridOrders);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Incorrect Vendor ID input");
                            }
                            break;
                        }
                }
            }
        }

        private void gridOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            try
            {
                var form = Application.OpenForms["Invoice"];
                if (form == null)
                {
                    Fname = this.gridOrders.CurrentRow.Cells[2].Value.ToString();
                    Sonum = this.gridOrders.CurrentRow.Cells[3].Value.ToString();
                    OrderDate = this.gridOrders.CurrentRow.Cells[6].Value.ToString();
                    Cid = int.Parse(this.gridOrders.CurrentRow.Cells[1].Value.ToString());
                    var invoice = new Forms.Invoice();
                    invoice.TopLevel = true;
                    invoice.TopMost = false;
                    invoice.Show();
                }
                else
                {
                    form.Dispose();
                    form.Close();
                    Fname = this.gridOrders.CurrentRow.Cells[2].Value.ToString();
                    Sonum = this.gridOrders.CurrentRow.Cells[3].Value.ToString();
                    OrderDate = this.gridOrders.CurrentRow.Cells[6].Value.ToString();
                    Cid = int.Parse(this.gridOrders.CurrentRow.Cells[1].Value.ToString());
                    var invoice = new Forms.Invoice();
                    invoice.TopLevel = true;
                    invoice.TopMost = false;
                    invoice.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No invoice available");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton3.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void btn_SaleStat_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("Select a method");
            }
            else
            {


                if (radioButton3.Checked == true)
                {
                    string start = dateTimePicker1.Text, end = dateTimePicker2.Text;
                    string query = $"select count(*) as 'Total Count' from sales.SalesOrderHeader where (status = 6 or Status = 5) and (orderdate <='{end}' and OrderDate>='{start}')";
                    this.gridOrders.DataSource = null;
                    Classes.SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
                else if (radioButton4.Checked == true)
                {
                    string start = dateTimePicker1.Text, end = dateTimePicker2.Text;
                    string query = $"select count(*) as 'Shipped Count' from sales.SalesOrderHeader where Status = 5 and (orderdate <='{end}' and OrderDate>='{start}')";
                    this.gridOrders.DataSource = null;
                    Classes.SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
                else if (radioButton2.Checked == true)
                {
                    string start = dateTimePicker1.Text, end = dateTimePicker2.Text;
                    string query = $"select count(*) as 'Canceled Count' from sales.SalesOrderHeader where Status = 6 and (orderdate <='{end}' and OrderDate>='{start}')";
                    this.gridOrders.DataSource = null;
                    Classes.SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
                else if (radioButton1.Checked == true)
                {
                    string start = dateTimePicker1.Text, end = dateTimePicker2.Text;
                    string query = $"select SUM(TotalDue) as Revenue from sales.SalesOrderHeader where status = 5 and orderdate <='{end}' and OrderDate>='{start}'";
                    this.gridOrders.DataSource = null;
                    Classes.SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                radioButton5.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton8.Checked = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                radioButton5.Checked = false;
                radioButton7.Checked = false;
                radioButton6.Checked = false;
            }
        }

        private void btn_PurchaseStat_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false)
            {
                MessageBox.Show("Select a method");
            }
            else
            {


                if (radioButton6.Checked == true)
                {
                    string start = dateTimePicker3.Text, end = dateTimePicker4.Text;
                    string query = $"select count(*) as 'Total Count' from Purchasing.PurchaseOrderHeader where (status = 4 or Status = 3) and (orderdate <='{end}' and OrderDate>='{start}')";
                    this.gridOrders.DataSource = null;
                    SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
                else if (radioButton8.Checked == true)
                {
                    string start = dateTimePicker3.Text, end = dateTimePicker4.Text;
                    string query = $"select SUM(TotalDue) as Expenses from Purchasing.PurchaseOrderHeader where status = 4  and orderdate <='{end}' and OrderDate>='{start}'";
                    this.gridOrders.DataSource = null;
                    SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
                else if (radioButton7.Checked == true)
                {
                    string start = dateTimePicker3.Text, end = dateTimePicker4.Text;
                    string query = $"select count(*) as 'Canceled Count' from Purchasing.PurchaseOrderHeader where Status = 3 and (orderdate <='{end}' and OrderDate>='{start}')";
                    this.gridOrders.DataSource = null;
                    SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
                else if (radioButton5.Checked == true)
                {
                    string start = dateTimePicker3.Text, end = dateTimePicker4.Text;
                    string query = $"select count(*) as 'Received Count' from Purchasing.PurchaseOrderHeader where status = 4 and orderdate <='{end}' and OrderDate>='{start}'";
                    this.gridOrders.DataSource = null;
                    SQLConnection.ReadDataFillGrid(query, this.gridOrders);
                }
            }
        }

        private void btn_PurchaseList_Click(object sender, EventArgs e)
        {
            gridOrders.Dock = DockStyle.Fill;
            chart1.Visible = false;
            GetPurchaseOrders();
        }

        private void btn_sales_showall_Click(object sender, EventArgs e)
        {
            gridOrders.Dock = DockStyle.Fill;
            chart1.Visible = false;
            GetSaleOrders();
        }

        private void checkBoxSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearch.Checked == true)
            {
                label1.Text = "Search Purchases by";
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Purchase Order ID");
                comboBox1.Items.Add("Status");
                comboBox1.Items.Add("Employee ID");
                comboBox1.Items.Add("Vendor ID");

            }
            else if (checkBoxSearch.Checked == false)
            {
                label1.Text = "Search Sales by";
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Store Name");
                comboBox1.Items.Add("Customer Last Name");
                comboBox1.Items.Add("Sale Order Number");
                comboBox1.Items.Add("Purchase Order Number");
                comboBox1.Items.Add("CustomerID");

            }
        }

        private void btn_GenerateGraph_Click(object sender, EventArgs e)
        {
            if (radioButton10.Checked == false && radioButton11.Checked == false && radioButton9.Checked == false)
            { MessageBox.Show("Please select a function"); }
            else
            {
                if (radioButton9.Checked == true)
                {
                    this.gridOrders.DataSource = null;
                    chart1.Visible = true;
                    if (dateTimePicker5.Value.ToString().Equals(dateTimePicker6.Value.ToString()) || dateTimePicker5.Value > dateTimePicker6.Value)
                    {
                        MessageBox.Show("Start and End dates must be different");
                    }
                    else
                    {
                        string SalesQuery = "select saleYear = DATEPART(YEAR,OrderDate), " +
                                               "saleMonth = DATEPART(MONTH, OrderDate), " +
                                               "sum(TotalDue) as revenue " +
                                               "from sales.salesOrderHeader " +
                                               $"where OrderDate >= '{dateTimePicker5.Text}' " +
                                               $"and OrderDate <= '{dateTimePicker6.Text}' " +
                                               "and Status = 5 " +
                                               "group by DATEPART(YEAR, OrderDate),DATEPART(MONTH, OrderDate) " +
                                               "order by DATEPART(YEAR, OrderDate),DATEPART(MONTH, OrderDate)";
                        SQLConnection.ReadDataFillGrid(SalesQuery, this.gridOrders);
                        gridOrders.Dock = DockStyle.Bottom;
                        if (gridOrders.RowCount == 0)
                        {
                            MessageBox.Show("No Data");
                        }
                        else
                        {
                            double min = Double.Parse(this.gridOrders.CurrentRow.Cells[2].Value.ToString());
                            double max = 0;

                            foreach (DataGridViewRow row in gridOrders.Rows)
                            {

                                if (min > double.Parse(row.Cells[2].Value.ToString()))
                                {
                                    min = double.Parse(row.Cells[2].Value.ToString());
                                }
                                if (max < double.Parse(row.Cells[2].Value.ToString()))
                                {
                                    max = double.Parse(row.Cells[2].Value.ToString());
                                }
                            }
                            min += -100000;
                            max += 100000;
                            var ObjChart = chart1.ChartAreas[0];
                            string date = dateTimePicker5.Text.ToString();
                            ObjChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
                            ObjChart.AxisX.ScaleView.Zoomable = true;
                            ObjChart.CursorX.AutoScroll = true;
                            ObjChart.CursorX.IsUserSelectionEnabled = true;
                            ObjChart.AxisY.ScaleView.Zoomable = true;
                            ObjChart.CursorY.AutoScroll = true;
                            ObjChart.CursorY.IsUserSelectionEnabled = true;
                            ObjChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorX.Interval = 1;
                            ObjChart.CursorY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorY.Interval = 1;
                            chart1.Series.Clear();
                            Random random = new Random();
                            chart1.Series.Add(radioButton9.Text);
                            chart1.Series[radioButton9.Text].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                            chart1.Series[radioButton9.Text].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                            chart1.Series[radioButton9.Text].Legend = "Legend1";
                            chart1.Series[radioButton9.Text].ChartArea = "ChartArea1";
                            chart1.Series[radioButton9.Text].BorderWidth = 2;
                            chart1.ChartAreas[0].AxisX.Minimum = dateTimePicker5.Value.ToOADate();
                            chart1.ChartAreas[0].AxisX.Maximum = dateTimePicker6.Value.ToOADate();
                            chart1.ChartAreas[0].AxisY.Minimum = min;
                            chart1.ChartAreas[0].AxisY.Maximum = max;
                            chart1.Series[radioButton9.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                            foreach (DataGridViewRow row in gridOrders.Rows)
                            {
                                string years = row.Cells[0].Value.ToString();
                                string months = row.Cells[1].Value.ToString();
                                string dates = years + months;
                                DateTime dt1 = DateTime.ParseExact(dates, "yyyyM", CultureInfo.InvariantCulture);
                                chart1.Series[radioButton9.Text].Points.AddXY(dt1, Convert.ToDouble(row.Cells[2].Value));


                            }
                        }
                    }
                }
                else if (radioButton10.Checked == true)
                {
                    this.gridOrders.DataSource = null;
                    chart1.Visible = true;
                    if (dateTimePicker5.Value.ToString().Equals(dateTimePicker6.Value.ToString()) || dateTimePicker5.Value > dateTimePicker6.Value)
                    {
                        MessageBox.Show("Start and End dates must be different");
                    }
                    else
                    {
                        string PurchQuery = " select saleYear = DATEPART(YEAR,OrderDate), " +
                                           "saleMonth = DATEPART(MONTH, OrderDate), " +
                                           "sum(TotalDue) " +
                                           "from Purchasing.PurchaseOrderHeader " +
                                          $"where OrderDate >= '{dateTimePicker5.Text}' " +
                                          $"and OrderDate <= '{dateTimePicker6.Text}' " +
                                           "and Status = 4 " +
                                           "group by DATEPART(YEAR, OrderDate),DATEPART(MONTH, OrderDate) " +
                                           "order by DATEPART(YEAR, OrderDate),DATEPART(MONTH, OrderDate)";
                        SQLConnection.ReadDataFillGrid(PurchQuery, this.gridOrders);
                        gridOrders.Dock = DockStyle.Bottom;
                        if (gridOrders.RowCount == 0)
                        {
                            MessageBox.Show("No Data");
                        }
                        else
                        {
                            double min = Double.Parse(this.gridOrders.CurrentRow.Cells[2].Value.ToString());
                            double max = 0;

                            foreach (DataGridViewRow row in gridOrders.Rows)
                            {

                                if (min > double.Parse(row.Cells[2].Value.ToString()))
                                {
                                    min = double.Parse(row.Cells[2].Value.ToString());
                                }
                                if (max < double.Parse(row.Cells[2].Value.ToString()))
                                {
                                    max = double.Parse(row.Cells[2].Value.ToString());
                                }
                            }
                            min += -100000;
                            max += 100000;
                            var ObjChart = chart1.ChartAreas[0];
                            string date = dateTimePicker5.Text.ToString();
                            ObjChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
                            ObjChart.AxisX.ScaleView.Zoomable = true;
                            ObjChart.CursorX.AutoScroll = true;
                            ObjChart.CursorX.IsUserSelectionEnabled = true;
                            ObjChart.AxisY.ScaleView.Zoomable = true;
                            ObjChart.CursorY.AutoScroll = true;
                            ObjChart.CursorY.IsUserSelectionEnabled = true;
                            ObjChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorX.Interval = 1;
                            ObjChart.CursorY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorY.Interval = 1;

                            chart1.Series.Clear();
                            Random random = new Random();
                            chart1.Series.Add(radioButton10.Text);
                            chart1.Series[radioButton10.Text].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                            chart1.Series[radioButton10.Text].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                            chart1.Series[radioButton10.Text].Legend = "Legend1";
                            chart1.Series[radioButton10.Text].ChartArea = "ChartArea1";
                            chart1.Series[radioButton10.Text].BorderWidth = 2;
                            chart1.ChartAreas[0].AxisX.Minimum = dateTimePicker5.Value.ToOADate();
                            chart1.ChartAreas[0].AxisX.Maximum = dateTimePicker6.Value.ToOADate();
                            chart1.ChartAreas[0].AxisY.Minimum = min;
                            chart1.ChartAreas[0].AxisY.Maximum = max;
                            chart1.Series[radioButton10.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                            foreach (DataGridViewRow row in gridOrders.Rows)
                            {
                                string years = row.Cells[0].Value.ToString();
                                string months = row.Cells[1].Value.ToString();
                                string dates = years + months;
                                DateTime dt1 = DateTime.ParseExact(dates, "yyyyM", CultureInfo.InvariantCulture);
                                chart1.Series[radioButton10.Text].Points.AddXY(dt1, Convert.ToDouble(row.Cells[2].Value));


                            }
                        }
                    }
                }
                else if (radioButton11.Checked == true)
                {
                    this.gridOrders.DataSource = null;
                    chart1.Visible = true;
                    if (dateTimePicker5.Value.ToString().Equals(dateTimePicker6.Value.ToString()) || dateTimePicker5.Value > dateTimePicker6.Value)
                    {
                        MessageBox.Show("Start and End dates must be different");
                    }
                    else
                    {
                        string PurchQuery = "with cte1 as " +
                                               "(select saleYear = DATEPART(YEAR, OrderDate), " +
                                               "saleMonth = DATEPART(MONTH, OrderDate), " +
                                               "sum(TotalDue) as revenue " +
                                               "from sales.salesOrderHeader " +
                                               $"where OrderDate >= '{dateTimePicker5.Text}' " +
                                               $"and OrderDate <= '{dateTimePicker6.Text}' " +
                                               "and Status = 5 " +
                                               "group by DATEPART(YEAR, OrderDate), DATEPART(MONTH, OrderDate)), " +
                                               "cte2 as " +
                                               "(select saleYear = DATEPART(YEAR, OrderDate), " +
                                               "saleMonth = DATEPART(MONTH, OrderDate), " +
                                               "sum(TotalDue) as expenses " +
                                               "from Purchasing.PurchaseOrderHeader " +
                                               $"where OrderDate >= '{dateTimePicker5.Text}' " +
                                               $"and OrderDate <= '{dateTimePicker6.Text}' " +
                                               "and Status = 4 " +
                                               "group by DATEPART(YEAR, OrderDate),DATEPART(MONTH, OrderDate))  " +
                                               "select cte1.saleYear as year,cte1.saleMonth as month,(isnull(cte1.revenue, 0) - isnull(cte2.expenses, 0)) as turnover " +
                                               "from cte1 full outer " +
                                               "join cte2 on cte1.saleYear = cte2.saleYear " +
                                                "order by year, month";
                        SQLConnection.ReadDataFillGrid(PurchQuery, this.gridOrders);
                        gridOrders.Dock = DockStyle.Bottom;
                        if (gridOrders.RowCount == 0)
                        {
                            MessageBox.Show("No Data");
                        }
                        else
                        {
                            double min = Double.Parse(this.gridOrders.CurrentRow.Cells[2].Value.ToString());
                            double max = 0;

                            foreach (DataGridViewRow row in gridOrders.Rows)
                            {

                                if (min > double.Parse(row.Cells[2].Value.ToString()))
                                {
                                    min = double.Parse(row.Cells[2].Value.ToString());
                                }
                                if (max < double.Parse(row.Cells[2].Value.ToString()))
                                {
                                    max = double.Parse(row.Cells[2].Value.ToString());
                                }
                            }
                            min += -100000;
                            max += 100000;
                            var ObjChart = chart1.ChartAreas[0];
                            string date = dateTimePicker5.Text.ToString();
                            ObjChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
                            ObjChart.AxisX.ScaleView.Zoomable = true;
                            ObjChart.CursorX.AutoScroll = true;
                            ObjChart.CursorX.IsUserSelectionEnabled = true;
                            ObjChart.AxisY.ScaleView.Zoomable = true;
                            ObjChart.CursorY.AutoScroll = true;
                            ObjChart.CursorY.IsUserSelectionEnabled = true;
                            ObjChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorX.Interval = 1;
                            ObjChart.CursorY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
                            ObjChart.CursorY.Interval = 1;
                            chart1.Series.Clear();
                            Random random = new Random();
                            chart1.Series.Add(radioButton11.Text);
                            chart1.Series[radioButton11.Text].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
                            chart1.Series[radioButton11.Text].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                            chart1.Series[radioButton11.Text].Legend = "Legend1";
                            chart1.Series[radioButton11.Text].ChartArea = "ChartArea1";
                            chart1.Series[radioButton11.Text].BorderWidth = 2;
                            chart1.ChartAreas[0].AxisX.Minimum = dateTimePicker5.Value.ToOADate();
                            chart1.ChartAreas[0].AxisX.Maximum = dateTimePicker6.Value.ToOADate();
                            chart1.ChartAreas[0].AxisY.Minimum = min;
                            chart1.ChartAreas[0].AxisY.Maximum = max;
                            chart1.Series[radioButton11.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                            foreach (DataGridViewRow row in gridOrders.Rows)
                            {
                                string years = row.Cells[0].Value.ToString();
                                string months = row.Cells[1].Value.ToString();
                                string dates = years + months;
                                DateTime dt1 = DateTime.ParseExact(dates, "yyyyM", CultureInfo.InvariantCulture);
                                chart1.Series[radioButton11.Text].Points.AddXY(dt1, Convert.ToDouble(row.Cells[2].Value));
                            }
                        }
                    }
                }
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {
                radioButton10.Checked = false;
                radioButton11.Checked = false;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                radioButton9.Checked = false;
                radioButton11.Checked = false;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == true)
            {
                radioButton10.Checked = false;
                radioButton9.Checked = false;
            }
        }

        private void gridOrders_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            gridOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }
    }
}
