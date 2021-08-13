
namespace app3rework.Forms
{
    partial class Stores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelStoresOptions = new System.Windows.Forms.Panel();
            this.btn_stores_remove = new System.Windows.Forms.Button();
            this.panelAddStore = new System.Windows.Forms.Panel();
            this.btn_RegiStore = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_postal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_city = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_addr2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_addr1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_storename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_stores_dockdown = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_store_filter = new System.Windows.Forms.Button();
            this.btn_stores_reg = new System.Windows.Forms.Button();
            this.btn_stores_show = new System.Windows.Forms.Button();
            this.panelStoresMain = new System.Windows.Forms.Panel();
            this.gridStores = new System.Windows.Forms.DataGridView();
            this.panelStoresOptions.SuspendLayout();
            this.panelAddStore.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.panel_stores_dockdown.SuspendLayout();
            this.panelStoresMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStores)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStoresOptions
            // 
            this.panelStoresOptions.BackColor = System.Drawing.Color.White;
            this.panelStoresOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStoresOptions.Controls.Add(this.btn_stores_remove);
            this.panelStoresOptions.Controls.Add(this.panelAddStore);
            this.panelStoresOptions.Controls.Add(this.panel_stores_dockdown);
            this.panelStoresOptions.Controls.Add(this.btn_store_filter);
            this.panelStoresOptions.Controls.Add(this.btn_stores_reg);
            this.panelStoresOptions.Controls.Add(this.btn_stores_show);
            this.panelStoresOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelStoresOptions.Location = new System.Drawing.Point(843, 0);
            this.panelStoresOptions.Name = "panelStoresOptions";
            this.panelStoresOptions.Size = new System.Drawing.Size(225, 761);
            this.panelStoresOptions.TabIndex = 1;
            // 
            // btn_stores_remove
            // 
            this.btn_stores_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stores_remove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stores_remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_stores_remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_stores_remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_stores_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stores_remove.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stores_remove.Location = new System.Drawing.Point(0, 479);
            this.btn_stores_remove.Name = "btn_stores_remove";
            this.btn_stores_remove.Size = new System.Drawing.Size(223, 36);
            this.btn_stores_remove.TabIndex = 10;
            this.btn_stores_remove.Text = "Remove Store";
            this.btn_stores_remove.UseVisualStyleBackColor = false;
            this.btn_stores_remove.Click += new System.EventHandler(this.btn_stores_remove_Click);
            // 
            // panelAddStore
            // 
            this.panelAddStore.Controls.Add(this.btn_RegiStore);
            this.panelAddStore.Controls.Add(this.label9);
            this.panelAddStore.Controls.Add(this.comboBox2);
            this.panelAddStore.Controls.Add(this.label8);
            this.panelAddStore.Controls.Add(this.txt_postal);
            this.panelAddStore.Controls.Add(this.label5);
            this.panelAddStore.Controls.Add(this.txt_city);
            this.panelAddStore.Controls.Add(this.label4);
            this.panelAddStore.Controls.Add(this.txt_addr2);
            this.panelAddStore.Controls.Add(this.label3);
            this.panelAddStore.Controls.Add(this.txt_addr1);
            this.panelAddStore.Controls.Add(this.label2);
            this.panelAddStore.Controls.Add(this.txt_storename);
            this.panelAddStore.Controls.Add(this.label7);
            this.panelAddStore.Controls.Add(this.panel_top);
            this.panelAddStore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAddStore.Location = new System.Drawing.Point(0, 72);
            this.panelAddStore.Name = "panelAddStore";
            this.panelAddStore.Size = new System.Drawing.Size(223, 407);
            this.panelAddStore.TabIndex = 12;
            this.panelAddStore.Visible = false;
            // 
            // btn_RegiStore
            // 
            this.btn_RegiStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RegiStore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_RegiStore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_RegiStore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_RegiStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RegiStore.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RegiStore.Location = new System.Drawing.Point(87, 355);
            this.btn_RegiStore.Name = "btn_RegiStore";
            this.btn_RegiStore.Size = new System.Drawing.Size(125, 41);
            this.btn_RegiStore.TabIndex = 12;
            this.btn_RegiStore.Text = "Register";
            this.btn_RegiStore.UseVisualStyleBackColor = false;
            this.btn_RegiStore.Click += new System.EventHandler(this.btn_RegiStore_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "(*)optional";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Main Office",
            "Shipping"});
            this.comboBox2.Location = new System.Drawing.Point(12, 209);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(162, 25);
            this.comboBox2.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Address Type";
            // 
            // txt_postal
            // 
            this.txt_postal.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_postal.Location = new System.Drawing.Point(12, 304);
            this.txt_postal.Name = "txt_postal";
            this.txt_postal.Size = new System.Drawing.Size(95, 25);
            this.txt_postal.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Postal Code";
            // 
            // txt_city
            // 
            this.txt_city.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_city.Location = new System.Drawing.Point(12, 256);
            this.txt_city.Name = "txt_city";
            this.txt_city.Size = new System.Drawing.Size(162, 25);
            this.txt_city.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "City";
            // 
            // txt_addr2
            // 
            this.txt_addr2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_addr2.Location = new System.Drawing.Point(12, 161);
            this.txt_addr2.Name = "txt_addr2";
            this.txt_addr2.Size = new System.Drawing.Size(162, 25);
            this.txt_addr2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Address Line 2(*)";
            // 
            // txt_addr1
            // 
            this.txt_addr1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_addr1.Location = new System.Drawing.Point(12, 115);
            this.txt_addr1.Name = "txt_addr1";
            this.txt_addr1.Size = new System.Drawing.Size(162, 25);
            this.txt_addr1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Address Line 1";
            // 
            // txt_storename
            // 
            this.txt_storename.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_storename.Location = new System.Drawing.Point(12, 68);
            this.txt_storename.Name = "txt_storename";
            this.txt_storename.Size = new System.Drawing.Size(162, 25);
            this.txt_storename.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Store Name";
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.panel_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_top.Controls.Add(this.label6);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(223, 39);
            this.panel_top.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Register Store";
            // 
            // panel_stores_dockdown
            // 
            this.panel_stores_dockdown.Controls.Add(this.label1);
            this.panel_stores_dockdown.Controls.Add(this.comboBox1);
            this.panel_stores_dockdown.Controls.Add(this.textBox1);
            this.panel_stores_dockdown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_stores_dockdown.Location = new System.Drawing.Point(0, 626);
            this.panel_stores_dockdown.Name = "panel_stores_dockdown";
            this.panel_stores_dockdown.Size = new System.Drawing.Size(223, 97);
            this.panel_stores_dockdown.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search Stores by";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Store Name",
            "StoreID",
            "Address",
            "Address Type",
            "City",
            "Postal Code"});
            this.comboBox1.Location = new System.Drawing.Point(3, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 25);
            this.comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 25);
            this.textBox1.TabIndex = 7;
            // 
            // btn_store_filter
            // 
            this.btn_store_filter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_store_filter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_store_filter.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_store_filter.Location = new System.Drawing.Point(0, 723);
            this.btn_store_filter.Name = "btn_store_filter";
            this.btn_store_filter.Size = new System.Drawing.Size(223, 36);
            this.btn_store_filter.TabIndex = 8;
            this.btn_store_filter.Text = "Search";
            this.btn_store_filter.UseVisualStyleBackColor = true;
            this.btn_store_filter.Click += new System.EventHandler(this.btn_store_filter_Click);
            // 
            // btn_stores_reg
            // 
            this.btn_stores_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stores_reg.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stores_reg.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_stores_reg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_stores_reg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_stores_reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stores_reg.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stores_reg.Location = new System.Drawing.Point(0, 36);
            this.btn_stores_reg.Name = "btn_stores_reg";
            this.btn_stores_reg.Size = new System.Drawing.Size(223, 36);
            this.btn_stores_reg.TabIndex = 2;
            this.btn_stores_reg.Text = "New Store";
            this.btn_stores_reg.UseVisualStyleBackColor = false;
            this.btn_stores_reg.Click += new System.EventHandler(this.btn_stores_reg_Click);
            // 
            // btn_stores_show
            // 
            this.btn_stores_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stores_show.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_stores_show.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_stores_show.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_stores_show.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_stores_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stores_show.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stores_show.Location = new System.Drawing.Point(0, 0);
            this.btn_stores_show.Name = "btn_stores_show";
            this.btn_stores_show.Size = new System.Drawing.Size(223, 36);
            this.btn_stores_show.TabIndex = 1;
            this.btn_stores_show.Text = "All Stores / Refresh";
            this.btn_stores_show.UseVisualStyleBackColor = false;
            this.btn_stores_show.Click += new System.EventHandler(this.btn_stores_show_Click);
            // 
            // panelStoresMain
            // 
            this.panelStoresMain.Controls.Add(this.gridStores);
            this.panelStoresMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStoresMain.Location = new System.Drawing.Point(0, 0);
            this.panelStoresMain.Name = "panelStoresMain";
            this.panelStoresMain.Size = new System.Drawing.Size(843, 761);
            this.panelStoresMain.TabIndex = 2;
            // 
            // gridStores
            // 
            this.gridStores.AllowUserToAddRows = false;
            this.gridStores.AllowUserToDeleteRows = false;
            this.gridStores.AllowUserToResizeColumns = false;
            this.gridStores.AllowUserToResizeRows = false;
            this.gridStores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.gridStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridStores.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridStores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStores.Location = new System.Drawing.Point(0, 0);
            this.gridStores.Name = "gridStores";
            this.gridStores.ReadOnly = true;
            this.gridStores.Size = new System.Drawing.Size(843, 761);
            this.gridStores.TabIndex = 1;
            // 
            // Stores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 761);
            this.Controls.Add(this.panelStoresMain);
            this.Controls.Add(this.panelStoresOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stores";
            this.Text = "Stores";
            this.panelStoresOptions.ResumeLayout(false);
            this.panelAddStore.ResumeLayout(false);
            this.panelAddStore.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_stores_dockdown.ResumeLayout(false);
            this.panel_stores_dockdown.PerformLayout();
            this.panelStoresMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridStores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStoresOptions;
        private System.Windows.Forms.Panel panel_stores_dockdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_stores_remove;
        private System.Windows.Forms.Button btn_store_filter;
        private System.Windows.Forms.Button btn_stores_reg;
        private System.Windows.Forms.Button btn_stores_show;
        private System.Windows.Forms.Panel panelStoresMain;
        public System.Windows.Forms.DataGridView gridStores;
        private System.Windows.Forms.Panel panelAddStore;
        private System.Windows.Forms.Button btn_RegiStore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_postal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_city;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_addr2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_addr1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_storename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label6;
    }
}