
namespace app3rework.Forms
{
    partial class NewSale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSale));
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_verify = new System.Windows.Forms.Panel();
            this.lbl_address = new System.Windows.Forms.Label();
            this.btn_SaveOrder = new System.Windows.Forms.Button();
            this.lbl_postal = new System.Windows.Forms.Label();
            this.btn_PlaceOrder = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_city = new System.Windows.Forms.Label();
            this.lbl_ShipCost = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.lbl_taxCost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_notaxCost = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_totalCost = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoveBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel_addProd = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_AddToGrid = new System.Windows.Forms.Button();
            this.panel_cInfo = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_removesaved = new System.Windows.Forms.Button();
            this.lbl_saveid_desc = new System.Windows.Forms.Label();
            this.lbl_savedid = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_cid = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.lbl_fullname = new System.Windows.Forms.Label();
            this.panel_main.SuspendLayout();
            this.panel_verify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_addProd.SuspendLayout();
            this.panel_cInfo.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.Silver;
            this.panel_main.Controls.Add(this.panel_verify);
            this.panel_main.Controls.Add(this.dataGridView1);
            this.panel_main.Controls.Add(this.panel_addProd);
            this.panel_main.Controls.Add(this.panel_cInfo);
            this.panel_main.Controls.Add(this.panel_top);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(709, 590);
            this.panel_main.TabIndex = 1;
            // 
            // panel_verify
            // 
            this.panel_verify.BackColor = System.Drawing.Color.White;
            this.panel_verify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_verify.Controls.Add(this.lbl_address);
            this.panel_verify.Controls.Add(this.btn_SaveOrder);
            this.panel_verify.Controls.Add(this.lbl_postal);
            this.panel_verify.Controls.Add(this.btn_PlaceOrder);
            this.panel_verify.Controls.Add(this.label14);
            this.panel_verify.Controls.Add(this.label9);
            this.panel_verify.Controls.Add(this.lbl_city);
            this.panel_verify.Controls.Add(this.lbl_ShipCost);
            this.panel_verify.Controls.Add(this.label12);
            this.panel_verify.Controls.Add(this.label8);
            this.panel_verify.Controls.Add(this.label11);
            this.panel_verify.Controls.Add(this.comboBox3);
            this.panel_verify.Controls.Add(this.lbl_taxCost);
            this.panel_verify.Controls.Add(this.label7);
            this.panel_verify.Controls.Add(this.lbl_notaxCost);
            this.panel_verify.Controls.Add(this.label6);
            this.panel_verify.Controls.Add(this.label5);
            this.panel_verify.Controls.Add(this.lbl_totalCost);
            this.panel_verify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_verify.Location = new System.Drawing.Point(0, 412);
            this.panel_verify.Name = "panel_verify";
            this.panel_verify.Size = new System.Drawing.Size(709, 178);
            this.panel_verify.TabIndex = 12;
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_address.Location = new System.Drawing.Point(408, 33);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(0, 17);
            this.lbl_address.TabIndex = 20;
            // 
            // btn_SaveOrder
            // 
            this.btn_SaveOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_SaveOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SaveOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_SaveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveOrder.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveOrder.Location = new System.Drawing.Point(456, 105);
            this.btn_SaveOrder.Name = "btn_SaveOrder";
            this.btn_SaveOrder.Size = new System.Drawing.Size(111, 59);
            this.btn_SaveOrder.TabIndex = 11;
            this.btn_SaveOrder.Text = "Save Order";
            this.btn_SaveOrder.UseVisualStyleBackColor = true;
            this.btn_SaveOrder.Click += new System.EventHandler(this.btn_SaveOrder_Click);
            // 
            // lbl_postal
            // 
            this.lbl_postal.AutoSize = true;
            this.lbl_postal.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_postal.Location = new System.Drawing.Point(620, 11);
            this.lbl_postal.Name = "lbl_postal";
            this.lbl_postal.Size = new System.Drawing.Size(0, 17);
            this.lbl_postal.TabIndex = 19;
            // 
            // btn_PlaceOrder
            // 
            this.btn_PlaceOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PlaceOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_PlaceOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_PlaceOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_PlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlaceOrder.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlaceOrder.Location = new System.Drawing.Point(580, 104);
            this.btn_PlaceOrder.Name = "btn_PlaceOrder";
            this.btn_PlaceOrder.Size = new System.Drawing.Size(111, 59);
            this.btn_PlaceOrder.TabIndex = 10;
            this.btn_PlaceOrder.Text = "Place Order";
            this.btn_PlaceOrder.UseVisualStyleBackColor = true;
            this.btn_PlaceOrder.Click += new System.EventHandler(this.btn_PlaceOrder_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(545, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 15);
            this.label14.TabIndex = 18;
            this.label14.Text = "Postal Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "Shipping Cost :";
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_city.Location = new System.Drawing.Point(441, 52);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(0, 17);
            this.lbl_city.TabIndex = 17;
            // 
            // lbl_ShipCost
            // 
            this.lbl_ShipCost.AutoSize = true;
            this.lbl_ShipCost.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ShipCost.Location = new System.Drawing.Point(131, 113);
            this.lbl_ShipCost.Name = "lbl_ShipCost";
            this.lbl_ShipCost.Size = new System.Drawing.Size(0, 21);
            this.lbl_ShipCost.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(408, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "City";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 27);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ship Method : ";
            this.label8.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(407, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "Bill to Address";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(129, 13);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(150, 25);
            this.comboBox3.TabIndex = 6;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // lbl_taxCost
            // 
            this.lbl_taxCost.AutoSize = true;
            this.lbl_taxCost.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_taxCost.Location = new System.Drawing.Point(113, 81);
            this.lbl_taxCost.Name = "lbl_taxCost";
            this.lbl_taxCost.Size = new System.Drawing.Size(0, 21);
            this.lbl_taxCost.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "VAT (24%) :";
            // 
            // lbl_notaxCost
            // 
            this.lbl_notaxCost.AutoSize = true;
            this.lbl_notaxCost.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notaxCost.Location = new System.Drawing.Point(113, 49);
            this.lbl_notaxCost.Name = "lbl_notaxCost";
            this.lbl_notaxCost.Size = new System.Drawing.Size(0, 21);
            this.lbl_notaxCost.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Initial Cost :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Cost :";
            // 
            // lbl_totalCost
            // 
            this.lbl_totalCost.AutoSize = true;
            this.lbl_totalCost.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalCost.Location = new System.Drawing.Point(112, 140);
            this.lbl_totalCost.Name = "lbl_totalCost";
            this.lbl_totalCost.Size = new System.Drawing.Size(0, 25);
            this.lbl_totalCost.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductNumber,
            this.ProductName,
            this.UnitPrice,
            this.Quantity,
            this.LineTotal,
            this.ProductID,
            this.WeightType,
            this.Weight,
            this.RemoveBtn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 232);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(709, 180);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // ProductNumber
            // 
            this.ProductNumber.HeaderText = "Product #";
            this.ProductNumber.Name = "ProductNumber";
            this.ProductNumber.ReadOnly = true;
            this.ProductNumber.Width = 79;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 60;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 75;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 48;
            // 
            // LineTotal
            // 
            this.LineTotal.HeaderText = "LineTotal";
            this.LineTotal.Name = "LineTotal";
            this.LineTotal.ReadOnly = true;
            this.LineTotal.Width = 76;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Pr.ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 56;
            // 
            // WeightType
            // 
            this.WeightType.HeaderText = "WeightType";
            this.WeightType.Name = "WeightType";
            this.WeightType.ReadOnly = true;
            this.WeightType.Visible = false;
            this.WeightType.Width = 90;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Visible = false;
            this.Weight.Width = 66;
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveBtn.HeaderText = "Remove";
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RemoveBtn.Text = "-";
            this.RemoveBtn.UseColumnTextForButtonValue = true;
            this.RemoveBtn.Width = 53;
            // 
            // panel_addProd
            // 
            this.panel_addProd.BackColor = System.Drawing.Color.White;
            this.panel_addProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_addProd.Controls.Add(this.button4);
            this.panel_addProd.Controls.Add(this.button3);
            this.panel_addProd.Controls.Add(this.label1);
            this.panel_addProd.Controls.Add(this.comboBox1);
            this.panel_addProd.Controls.Add(this.label3);
            this.panel_addProd.Controls.Add(this.comboBox2);
            this.panel_addProd.Controls.Add(this.txt_qty);
            this.panel_addProd.Controls.Add(this.label2);
            this.panel_addProd.Controls.Add(this.btn_AddToGrid);
            this.panel_addProd.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_addProd.Location = new System.Drawing.Point(0, 142);
            this.panel_addProd.Name = "panel_addProd";
            this.panel_addProd.Size = new System.Drawing.Size(709, 90);
            this.panel_addProd.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(485, 51);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 21);
            this.button4.TabIndex = 9;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(485, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 21);
            this.button3.TabIndex = 8;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(163, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 25);
            this.comboBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(396, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Qty";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Bikes",
            "Components",
            "Clothing",
            "Accessories"});
            this.comboBox2.Location = new System.Drawing.Point(16, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 25);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txt_qty
            // 
            this.txt_qty.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty.Location = new System.Drawing.Point(396, 38);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(83, 25);
            this.txt_qty.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product Name";
            // 
            // btn_AddToGrid
            // 
            this.btn_AddToGrid.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddToGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddToGrid.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_AddToGrid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_AddToGrid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_AddToGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddToGrid.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddToGrid.Location = new System.Drawing.Point(638, 18);
            this.btn_AddToGrid.Name = "btn_AddToGrid";
            this.btn_AddToGrid.Size = new System.Drawing.Size(53, 49);
            this.btn_AddToGrid.TabIndex = 5;
            this.btn_AddToGrid.Text = "+";
            this.btn_AddToGrid.UseVisualStyleBackColor = false;
            this.btn_AddToGrid.Click += new System.EventHandler(this.btn_AddToGrid_Click);
            // 
            // panel_cInfo
            // 
            this.panel_cInfo.BackColor = System.Drawing.Color.White;
            this.panel_cInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_cInfo.Controls.Add(this.label10);
            this.panel_cInfo.Controls.Add(this.btn_removesaved);
            this.panel_cInfo.Controls.Add(this.lbl_saveid_desc);
            this.panel_cInfo.Controls.Add(this.lbl_savedid);
            this.panel_cInfo.Controls.Add(this.label4);
            this.panel_cInfo.Controls.Add(this.lbl_cid);
            this.panel_cInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cInfo.Location = new System.Drawing.Point(0, 39);
            this.panel_cInfo.Name = "panel_cInfo";
            this.panel_cInfo.Size = new System.Drawing.Size(709, 103);
            this.panel_cInfo.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(565, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Remove from Saved";
            this.label10.Visible = false;
            // 
            // btn_removesaved
            // 
            this.btn_removesaved.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_removesaved.BackgroundImage")));
            this.btn_removesaved.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_removesaved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_removesaved.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_removesaved.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_removesaved.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_removesaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_removesaved.Location = new System.Drawing.Point(638, 36);
            this.btn_removesaved.Name = "btn_removesaved";
            this.btn_removesaved.Size = new System.Drawing.Size(53, 48);
            this.btn_removesaved.TabIndex = 12;
            this.btn_removesaved.UseVisualStyleBackColor = true;
            this.btn_removesaved.Visible = false;
            this.btn_removesaved.Click += new System.EventHandler(this.btn_removesaved_Click);
            // 
            // lbl_saveid_desc
            // 
            this.lbl_saveid_desc.AutoSize = true;
            this.lbl_saveid_desc.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_saveid_desc.Location = new System.Drawing.Point(13, 54);
            this.lbl_saveid_desc.Name = "lbl_saveid_desc";
            this.lbl_saveid_desc.Size = new System.Drawing.Size(115, 21);
            this.lbl_saveid_desc.TabIndex = 11;
            this.lbl_saveid_desc.Text = "SavedOrderID :";
            this.lbl_saveid_desc.Visible = false;
            // 
            // lbl_savedid
            // 
            this.lbl_savedid.AutoSize = true;
            this.lbl_savedid.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_savedid.Location = new System.Drawing.Point(134, 54);
            this.lbl_savedid.Name = "lbl_savedid";
            this.lbl_savedid.Size = new System.Drawing.Size(0, 21);
            this.lbl_savedid.TabIndex = 10;
            this.lbl_savedid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "CustomerID :";
            // 
            // lbl_cid
            // 
            this.lbl_cid.AutoSize = true;
            this.lbl_cid.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cid.Location = new System.Drawing.Point(115, 18);
            this.lbl_cid.Name = "lbl_cid";
            this.lbl_cid.Size = new System.Drawing.Size(0, 21);
            this.lbl_cid.TabIndex = 8;
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.panel_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_top.Controls.Add(this.lbl_fullname);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(709, 39);
            this.panel_top.TabIndex = 10;
            // 
            // lbl_fullname
            // 
            this.lbl_fullname.AutoSize = true;
            this.lbl_fullname.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fullname.ForeColor = System.Drawing.Color.Black;
            this.lbl_fullname.Location = new System.Drawing.Point(12, 9);
            this.lbl_fullname.Name = "lbl_fullname";
            this.lbl_fullname.Size = new System.Drawing.Size(0, 21);
            this.lbl_fullname.TabIndex = 2;
            // 
            // NewSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 590);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Sale Order";
            this.panel_main.ResumeLayout(false);
            this.panel_verify.ResumeLayout(false);
            this.panel_verify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_addProd.ResumeLayout(false);
            this.panel_addProd.PerformLayout();
            this.panel_cInfo.ResumeLayout(false);
            this.panel_cInfo.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_verify;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Button btn_SaveOrder;
        private System.Windows.Forms.Label lbl_postal;
        private System.Windows.Forms.Button btn_PlaceOrder;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.Label lbl_ShipCost;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label lbl_taxCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_notaxCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_totalCost;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveBtn;
        private System.Windows.Forms.Panel panel_addProd;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddToGrid;
        private System.Windows.Forms.Panel panel_cInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_removesaved;
        private System.Windows.Forms.Label lbl_saveid_desc;
        private System.Windows.Forms.Label lbl_savedid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_cid;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label lbl_fullname;
    }
}