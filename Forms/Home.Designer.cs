
namespace app3rework.Forms
{
    partial class Home
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_home_nav = new System.Windows.Forms.Panel();
            this.btn_SavedOrders = new System.Windows.Forms.Button();
            this.btn_workOrders = new System.Windows.Forms.Button();
            this.lbl_grid_descr = new System.Windows.Forms.Label();
            this.btn_purchaseinprogress = new System.Windows.Forms.Button();
            this.btn_salesinprogress = new System.Windows.Forms.Button();
            this.panel_fix = new System.Windows.Forms.Panel();
            this.panelHomeMain = new System.Windows.Forms.Panel();
            this.panel_sales_edit = new System.Windows.Forms.Panel();
            this.panel_right_options = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ScrapReason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Complete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.panel_home_nav.SuspendLayout();
            this.panelHomeMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_home_nav
            // 
            this.panel_home_nav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(131)))), ((int)(((byte)(140)))));
            this.panel_home_nav.Controls.Add(this.btn_SavedOrders);
            this.panel_home_nav.Controls.Add(this.btn_workOrders);
            this.panel_home_nav.Controls.Add(this.lbl_grid_descr);
            this.panel_home_nav.Controls.Add(this.btn_purchaseinprogress);
            this.panel_home_nav.Controls.Add(this.btn_salesinprogress);
            this.panel_home_nav.Controls.Add(this.panel_fix);
            this.panel_home_nav.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_home_nav.Location = new System.Drawing.Point(0, 0);
            this.panel_home_nav.Name = "panel_home_nav";
            this.panel_home_nav.Size = new System.Drawing.Size(1046, 53);
            this.panel_home_nav.TabIndex = 1;
            // 
            // btn_SavedOrders
            // 
            this.btn_SavedOrders.BackColor = System.Drawing.Color.Transparent;
            this.btn_SavedOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SavedOrders.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_SavedOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_SavedOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SavedOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_SavedOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SavedOrders.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SavedOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_SavedOrders.Location = new System.Drawing.Point(267, 0);
            this.btn_SavedOrders.Name = "btn_SavedOrders";
            this.btn_SavedOrders.Size = new System.Drawing.Size(194, 53);
            this.btn_SavedOrders.TabIndex = 6;
            this.btn_SavedOrders.Text = "Saved Orders";
            this.btn_SavedOrders.UseVisualStyleBackColor = false;
            this.btn_SavedOrders.Click += new System.EventHandler(this.btn_SavedOrders_Click);
            // 
            // btn_workOrders
            // 
            this.btn_workOrders.BackColor = System.Drawing.Color.Transparent;
            this.btn_workOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_workOrders.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_workOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_workOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_workOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_workOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_workOrders.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_workOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_workOrders.Location = new System.Drawing.Point(461, 0);
            this.btn_workOrders.Name = "btn_workOrders";
            this.btn_workOrders.Size = new System.Drawing.Size(194, 53);
            this.btn_workOrders.TabIndex = 5;
            this.btn_workOrders.Text = "Work Orders";
            this.btn_workOrders.UseVisualStyleBackColor = false;
            this.btn_workOrders.Click += new System.EventHandler(this.btn_workOrders_Click);
            // 
            // lbl_grid_descr
            // 
            this.lbl_grid_descr.AutoSize = true;
            this.lbl_grid_descr.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_grid_descr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.lbl_grid_descr.Location = new System.Drawing.Point(23, 16);
            this.lbl_grid_descr.Name = "lbl_grid_descr";
            this.lbl_grid_descr.Size = new System.Drawing.Size(182, 21);
            this.lbl_grid_descr.TabIndex = 4;
            this.lbl_grid_descr.Text = "Showing on going sales";
            // 
            // btn_purchaseinprogress
            // 
            this.btn_purchaseinprogress.BackColor = System.Drawing.Color.Transparent;
            this.btn_purchaseinprogress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_purchaseinprogress.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_purchaseinprogress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_purchaseinprogress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_purchaseinprogress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_purchaseinprogress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_purchaseinprogress.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_purchaseinprogress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_purchaseinprogress.Location = new System.Drawing.Point(655, 0);
            this.btn_purchaseinprogress.Name = "btn_purchaseinprogress";
            this.btn_purchaseinprogress.Size = new System.Drawing.Size(194, 53);
            this.btn_purchaseinprogress.TabIndex = 1;
            this.btn_purchaseinprogress.Text = "Purchases";
            this.btn_purchaseinprogress.UseVisualStyleBackColor = false;
            this.btn_purchaseinprogress.Click += new System.EventHandler(this.btn_purchaseinprogress_Click);
            // 
            // btn_salesinprogress
            // 
            this.btn_salesinprogress.BackColor = System.Drawing.Color.Transparent;
            this.btn_salesinprogress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salesinprogress.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_salesinprogress.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_salesinprogress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_salesinprogress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(141)))), ((int)(((byte)(150)))));
            this.btn_salesinprogress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salesinprogress.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salesinprogress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_salesinprogress.Location = new System.Drawing.Point(849, 0);
            this.btn_salesinprogress.Name = "btn_salesinprogress";
            this.btn_salesinprogress.Size = new System.Drawing.Size(194, 53);
            this.btn_salesinprogress.TabIndex = 0;
            this.btn_salesinprogress.Text = "Sales";
            this.btn_salesinprogress.UseVisualStyleBackColor = false;
            this.btn_salesinprogress.Click += new System.EventHandler(this.btn_salesinprogress_Click);
            // 
            // panel_fix
            // 
            this.panel_fix.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_fix.Location = new System.Drawing.Point(1043, 0);
            this.panel_fix.Name = "panel_fix";
            this.panel_fix.Size = new System.Drawing.Size(3, 53);
            this.panel_fix.TabIndex = 2;
            // 
            // panelHomeMain
            // 
            this.panelHomeMain.Controls.Add(this.dataGridView1);
            this.panelHomeMain.Controls.Add(this.dataGridView3);
            this.panelHomeMain.Controls.Add(this.dataGridView2);
            this.panelHomeMain.Controls.Add(this.panel_sales_edit);
            this.panelHomeMain.Controls.Add(this.panel_right_options);
            this.panelHomeMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHomeMain.Location = new System.Drawing.Point(0, 53);
            this.panelHomeMain.Name = "panelHomeMain";
            this.panelHomeMain.Size = new System.Drawing.Size(1046, 669);
            this.panelHomeMain.TabIndex = 5;
            // 
            // panel_sales_edit
            // 
            this.panel_sales_edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_sales_edit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_sales_edit.Location = new System.Drawing.Point(0, 169);
            this.panel_sales_edit.Name = "panel_sales_edit";
            this.panel_sales_edit.Size = new System.Drawing.Size(1046, 250);
            this.panel_sales_edit.TabIndex = 4;
            this.panel_sales_edit.Visible = false;
            // 
            // panel_right_options
            // 
            this.panel_right_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_right_options.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_right_options.Location = new System.Drawing.Point(0, 419);
            this.panel_right_options.Name = "panel_right_options";
            this.panel_right_options.Size = new System.Drawing.Size(1046, 250);
            this.panel_right_options.TabIndex = 3;
            this.panel_right_options.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScrapReason,
            this.Complete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(0, 100);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1046, 69);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.Visible = false;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView2_RowPrePaint);
            // 
            // ScrapReason
            // 
            this.ScrapReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ScrapReason.HeaderText = "Scrap Reason";
            this.ScrapReason.Name = "ScrapReason";
            this.ScrapReason.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ScrapReason.Width = 81;
            // 
            // Complete
            // 
            this.Complete.HeaderText = "Complete";
            this.Complete.Name = "Complete";
            this.Complete.Text = "Complete";
            this.Complete.UseColumnTextForButtonValue = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1046, 38);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView3.Location = new System.Drawing.Point(0, 38);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.Size = new System.Drawing.Size(1046, 62);
            this.dataGridView3.TabIndex = 7;
            this.dataGridView3.Visible = false;
            this.dataGridView3.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView3_CellMouseDoubleClick);
            this.dataGridView3.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView3_RowPrePaint);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 722);
            this.Controls.Add(this.panelHomeMain);
            this.Controls.Add(this.panel_home_nav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.panel_home_nav.ResumeLayout(false);
            this.panel_home_nav.PerformLayout();
            this.panelHomeMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_home_nav;
        private System.Windows.Forms.Button btn_workOrders;
        private System.Windows.Forms.Label lbl_grid_descr;
        private System.Windows.Forms.Button btn_purchaseinprogress;
        private System.Windows.Forms.Button btn_salesinprogress;
        private System.Windows.Forms.Panel panel_fix;
        private System.Windows.Forms.Panel panelHomeMain;
        private System.Windows.Forms.Button btn_SavedOrders;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewComboBoxColumn ScrapReason;
        private System.Windows.Forms.DataGridViewButtonColumn Complete;
        public System.Windows.Forms.Panel panel_sales_edit;
        private System.Windows.Forms.Panel panel_right_options;
        public System.Windows.Forms.DataGridView dataGridView3;
    }
}