
namespace app3rework.Forms
{
    partial class Customers
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
            this.panelCustomersOptions = new System.Windows.Forms.Panel();
            this.btn_customer_remove = new System.Windows.Forms.Button();
            this.panel_customer_dockdown = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_filter = new System.Windows.Forms.TextBox();
            this.btn_customeradd = new System.Windows.Forms.Button();
            this.btn_customer_filter = new System.Windows.Forms.Button();
            this.btn_customerlist = new System.Windows.Forms.Button();
            this.panelCustomersMain = new System.Windows.Forms.Panel();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelCustomersOptions.SuspendLayout();
            this.panel_customer_dockdown.SuspendLayout();
            this.panelCustomersMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCustomersOptions
            // 
            this.panelCustomersOptions.BackColor = System.Drawing.Color.White;
            this.panelCustomersOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCustomersOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomersOptions.Controls.Add(this.btn_customer_remove);
            this.panelCustomersOptions.Controls.Add(this.panel_customer_dockdown);
            this.panelCustomersOptions.Controls.Add(this.btn_customeradd);
            this.panelCustomersOptions.Controls.Add(this.btn_customer_filter);
            this.panelCustomersOptions.Controls.Add(this.btn_customerlist);
            this.panelCustomersOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCustomersOptions.Location = new System.Drawing.Point(843, 0);
            this.panelCustomersOptions.Name = "panelCustomersOptions";
            this.panelCustomersOptions.Size = new System.Drawing.Size(225, 761);
            this.panelCustomersOptions.TabIndex = 1;
            // 
            // btn_customer_remove
            // 
            this.btn_customer_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_customer_remove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_customer_remove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_customer_remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_customer_remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_customer_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_customer_remove.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customer_remove.Location = new System.Drawing.Point(0, 72);
            this.btn_customer_remove.Name = "btn_customer_remove";
            this.btn_customer_remove.Size = new System.Drawing.Size(223, 36);
            this.btn_customer_remove.TabIndex = 9;
            this.btn_customer_remove.Text = "Remove Customer";
            this.btn_customer_remove.UseVisualStyleBackColor = false;
            this.btn_customer_remove.Click += new System.EventHandler(this.btn_customer_remove_Click);
            // 
            // panel_customer_dockdown
            // 
            this.panel_customer_dockdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_customer_dockdown.Controls.Add(this.label1);
            this.panel_customer_dockdown.Controls.Add(this.comboBox1);
            this.panel_customer_dockdown.Controls.Add(this.txt_filter);
            this.panel_customer_dockdown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_customer_dockdown.Location = new System.Drawing.Point(0, 627);
            this.panel_customer_dockdown.Name = "panel_customer_dockdown";
            this.panel_customer_dockdown.Size = new System.Drawing.Size(223, 96);
            this.panel_customer_dockdown.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search Customers by";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CustomerID",
            "StoreID",
            "Last Name",
            "Address"});
            this.comboBox1.Location = new System.Drawing.Point(3, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 25);
            this.comboBox1.TabIndex = 2;
            // 
            // txt_filter
            // 
            this.txt_filter.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_filter.Location = new System.Drawing.Point(3, 64);
            this.txt_filter.Name = "txt_filter";
            this.txt_filter.Size = new System.Drawing.Size(207, 25);
            this.txt_filter.TabIndex = 3;
            // 
            // btn_customeradd
            // 
            this.btn_customeradd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_customeradd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_customeradd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_customeradd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_customeradd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_customeradd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_customeradd.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customeradd.Location = new System.Drawing.Point(0, 36);
            this.btn_customeradd.Name = "btn_customeradd";
            this.btn_customeradd.Size = new System.Drawing.Size(223, 36);
            this.btn_customeradd.TabIndex = 6;
            this.btn_customeradd.Text = "New Customer";
            this.btn_customeradd.UseVisualStyleBackColor = false;
            this.btn_customeradd.Click += new System.EventHandler(this.btn_customeradd_Click);
            // 
            // btn_customer_filter
            // 
            this.btn_customer_filter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_customer_filter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_customer_filter.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customer_filter.Location = new System.Drawing.Point(0, 723);
            this.btn_customer_filter.Name = "btn_customer_filter";
            this.btn_customer_filter.Size = new System.Drawing.Size(223, 36);
            this.btn_customer_filter.TabIndex = 4;
            this.btn_customer_filter.Text = "Search";
            this.btn_customer_filter.UseVisualStyleBackColor = true;
            this.btn_customer_filter.Click += new System.EventHandler(this.btn_customer_filter_Click);
            // 
            // btn_customerlist
            // 
            this.btn_customerlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_customerlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_customerlist.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_customerlist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_customerlist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_customerlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_customerlist.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customerlist.Location = new System.Drawing.Point(0, 0);
            this.btn_customerlist.Name = "btn_customerlist";
            this.btn_customerlist.Size = new System.Drawing.Size(223, 36);
            this.btn_customerlist.TabIndex = 1;
            this.btn_customerlist.Text = "All Customers / Refresh";
            this.btn_customerlist.UseVisualStyleBackColor = false;
            this.btn_customerlist.Click += new System.EventHandler(this.btn_customerlist_Click);
            // 
            // panelCustomersMain
            // 
            this.panelCustomersMain.Controls.Add(this.gridCustomers);
            this.panelCustomersMain.Controls.Add(this.panelContainer);
            this.panelCustomersMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomersMain.Location = new System.Drawing.Point(0, 0);
            this.panelCustomersMain.Name = "panelCustomersMain";
            this.panelCustomersMain.Size = new System.Drawing.Size(843, 761);
            this.panelCustomersMain.TabIndex = 2;
            // 
            // gridCustomers
            // 
            this.gridCustomers.AllowUserToAddRows = false;
            this.gridCustomers.AllowUserToDeleteRows = false;
            this.gridCustomers.AllowUserToResizeColumns = false;
            this.gridCustomers.AllowUserToResizeRows = false;
            this.gridCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCustomers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCustomers.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCustomers.Location = new System.Drawing.Point(0, 0);
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.ReadOnly = true;
            this.gridCustomers.Size = new System.Drawing.Size(305, 761);
            this.gridCustomers.TabIndex = 1;
            this.gridCustomers.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridCustomers_CellMouseDoubleClick);
            // 
            // panelContainer
            // 
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelContainer.Location = new System.Drawing.Point(305, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(538, 761);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Visible = false;
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 761);
            this.Controls.Add(this.panelCustomersMain);
            this.Controls.Add(this.panelCustomersOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Customers";
            this.Text = "Customers";
            this.panelCustomersOptions.ResumeLayout(false);
            this.panel_customer_dockdown.ResumeLayout(false);
            this.panel_customer_dockdown.PerformLayout();
            this.panelCustomersMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCustomersOptions;
        private System.Windows.Forms.Button btn_customer_remove;
        private System.Windows.Forms.Panel panel_customer_dockdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_filter;
        private System.Windows.Forms.Button btn_customeradd;
        private System.Windows.Forms.Button btn_customer_filter;
        private System.Windows.Forms.Button btn_customerlist;
        private System.Windows.Forms.Panel panelCustomersMain;
        public System.Windows.Forms.DataGridView gridCustomers;
        private System.Windows.Forms.Panel panelContainer;
    }
}