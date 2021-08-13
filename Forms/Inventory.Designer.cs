
namespace app3rework.Forms
{
    partial class Inventory
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
            this.panelInvOptions = new System.Windows.Forms.Panel();
            this.btn_inv_reorder = new System.Windows.Forms.Button();
            this.btn_inv_restock = new System.Windows.Forms.Button();
            this.btn_workOrder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_byLocID = new System.Windows.Forms.Button();
            this.btn_byProd = new System.Windows.Forms.Button();
            this.btn_purchaseList = new System.Windows.Forms.Button();
            this.panel_inv_dockdown = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filter = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_inv_filter_search = new System.Windows.Forms.Button();
            this.btn_inv_scan = new System.Windows.Forms.Button();
            this.btn_inv_showAll = new System.Windows.Forms.Button();
            this.panelInvMain = new System.Windows.Forms.Panel();
            this.gridInventory = new System.Windows.Forms.DataGridView();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelInvOptions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_inv_dockdown.SuspendLayout();
            this.panelInvMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInvOptions
            // 
            this.panelInvOptions.BackColor = System.Drawing.Color.White;
            this.panelInvOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInvOptions.Controls.Add(this.btn_inv_reorder);
            this.panelInvOptions.Controls.Add(this.btn_inv_restock);
            this.panelInvOptions.Controls.Add(this.btn_workOrder);
            this.panelInvOptions.Controls.Add(this.panel1);
            this.panelInvOptions.Controls.Add(this.btn_purchaseList);
            this.panelInvOptions.Controls.Add(this.panel_inv_dockdown);
            this.panelInvOptions.Controls.Add(this.btn_inv_filter_search);
            this.panelInvOptions.Controls.Add(this.btn_inv_scan);
            this.panelInvOptions.Controls.Add(this.btn_inv_showAll);
            this.panelInvOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInvOptions.Location = new System.Drawing.Point(843, 0);
            this.panelInvOptions.Name = "panelInvOptions";
            this.panelInvOptions.Size = new System.Drawing.Size(225, 761);
            this.panelInvOptions.TabIndex = 2;
            // 
            // btn_inv_reorder
            // 
            this.btn_inv_reorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inv_reorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_inv_reorder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_reorder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_inv_reorder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_reorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inv_reorder.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inv_reorder.Location = new System.Drawing.Point(0, 219);
            this.btn_inv_reorder.Name = "btn_inv_reorder";
            this.btn_inv_reorder.Size = new System.Drawing.Size(223, 36);
            this.btn_inv_reorder.TabIndex = 2;
            this.btn_inv_reorder.Text = "Reorder";
            this.btn_inv_reorder.UseVisualStyleBackColor = false;
            this.btn_inv_reorder.Click += new System.EventHandler(this.btn_inv_reorder_Click);
            // 
            // btn_inv_restock
            // 
            this.btn_inv_restock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inv_restock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_inv_restock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_restock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_inv_restock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_restock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inv_restock.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inv_restock.Location = new System.Drawing.Point(0, 183);
            this.btn_inv_restock.Name = "btn_inv_restock";
            this.btn_inv_restock.Size = new System.Drawing.Size(223, 36);
            this.btn_inv_restock.TabIndex = 3;
            this.btn_inv_restock.Text = "Restock";
            this.btn_inv_restock.UseVisualStyleBackColor = false;
            this.btn_inv_restock.Click += new System.EventHandler(this.btn_inv_restock_Click);
            // 
            // btn_workOrder
            // 
            this.btn_workOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_workOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_workOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_workOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_workOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_workOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_workOrder.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_workOrder.Location = new System.Drawing.Point(0, 147);
            this.btn_workOrder.Name = "btn_workOrder";
            this.btn_workOrder.Size = new System.Drawing.Size(223, 36);
            this.btn_workOrder.TabIndex = 11;
            this.btn_workOrder.Text = "Make Work Order";
            this.btn_workOrder.UseVisualStyleBackColor = false;
            this.btn_workOrder.Click += new System.EventHandler(this.btn_workOrder_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_byLocID);
            this.panel1.Controls.Add(this.btn_byProd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 75);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // btn_byLocID
            // 
            this.btn_byLocID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(131)))), ((int)(((byte)(140)))));
            this.btn_byLocID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_byLocID.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_byLocID.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_byLocID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_byLocID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_byLocID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_byLocID.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_byLocID.ForeColor = System.Drawing.Color.White;
            this.btn_byLocID.Location = new System.Drawing.Point(0, 36);
            this.btn_byLocID.Name = "btn_byLocID";
            this.btn_byLocID.Size = new System.Drawing.Size(223, 36);
            this.btn_byLocID.TabIndex = 13;
            this.btn_byLocID.Text = "by Location";
            this.btn_byLocID.UseVisualStyleBackColor = false;
            this.btn_byLocID.Click += new System.EventHandler(this.btn_byLocID_Click);
            // 
            // btn_byProd
            // 
            this.btn_byProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(131)))), ((int)(((byte)(140)))));
            this.btn_byProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_byProd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_byProd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_byProd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_byProd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_byProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_byProd.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_byProd.ForeColor = System.Drawing.Color.White;
            this.btn_byProd.Location = new System.Drawing.Point(0, 0);
            this.btn_byProd.Name = "btn_byProd";
            this.btn_byProd.Size = new System.Drawing.Size(223, 36);
            this.btn_byProd.TabIndex = 12;
            this.btn_byProd.Text = "by Product";
            this.btn_byProd.UseVisualStyleBackColor = false;
            this.btn_byProd.Click += new System.EventHandler(this.btn_byProd_Click);
            // 
            // btn_purchaseList
            // 
            this.btn_purchaseList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_purchaseList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_purchaseList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_purchaseList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_purchaseList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_purchaseList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_purchaseList.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_purchaseList.Location = new System.Drawing.Point(0, 592);
            this.btn_purchaseList.Name = "btn_purchaseList";
            this.btn_purchaseList.Size = new System.Drawing.Size(223, 36);
            this.btn_purchaseList.TabIndex = 10;
            this.btn_purchaseList.Text = "Open Purchase List";
            this.btn_purchaseList.UseVisualStyleBackColor = false;
            this.btn_purchaseList.Click += new System.EventHandler(this.btn_purchaseList_Click);
            // 
            // panel_inv_dockdown
            // 
            this.panel_inv_dockdown.Controls.Add(this.label1);
            this.panel_inv_dockdown.Controls.Add(this.txt_filter);
            this.panel_inv_dockdown.Controls.Add(this.comboBox1);
            this.panel_inv_dockdown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_inv_dockdown.Location = new System.Drawing.Point(0, 628);
            this.panel_inv_dockdown.Name = "panel_inv_dockdown";
            this.panel_inv_dockdown.Size = new System.Drawing.Size(223, 95);
            this.panel_inv_dockdown.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search Products by";
            // 
            // txt_filter
            // 
            this.txt_filter.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_filter.Location = new System.Drawing.Point(3, 63);
            this.txt_filter.Name = "txt_filter";
            this.txt_filter.Size = new System.Drawing.Size(207, 25);
            this.txt_filter.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "By Name",
            "By ProductID",
            "Quantity >=",
            "Quantity <=",
            "Location"});
            this.comboBox1.Location = new System.Drawing.Point(3, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 25);
            this.comboBox1.TabIndex = 6;
            // 
            // btn_inv_filter_search
            // 
            this.btn_inv_filter_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inv_filter_search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_inv_filter_search.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inv_filter_search.Location = new System.Drawing.Point(0, 723);
            this.btn_inv_filter_search.Name = "btn_inv_filter_search";
            this.btn_inv_filter_search.Size = new System.Drawing.Size(223, 36);
            this.btn_inv_filter_search.TabIndex = 5;
            this.btn_inv_filter_search.Text = "Search";
            this.btn_inv_filter_search.UseVisualStyleBackColor = true;
            this.btn_inv_filter_search.Click += new System.EventHandler(this.btn_inv_filter_search_Click);
            // 
            // btn_inv_scan
            // 
            this.btn_inv_scan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inv_scan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_inv_scan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_scan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_inv_scan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inv_scan.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inv_scan.Location = new System.Drawing.Point(0, 36);
            this.btn_inv_scan.Name = "btn_inv_scan";
            this.btn_inv_scan.Size = new System.Drawing.Size(223, 36);
            this.btn_inv_scan.TabIndex = 1;
            this.btn_inv_scan.Text = "Total Product Qty.";
            this.btn_inv_scan.UseVisualStyleBackColor = false;
            this.btn_inv_scan.Click += new System.EventHandler(this.btn_inv_scan_Click);
            // 
            // btn_inv_showAll
            // 
            this.btn_inv_showAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_inv_showAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_inv_showAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_showAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_inv_showAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_inv_showAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inv_showAll.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inv_showAll.Location = new System.Drawing.Point(0, 0);
            this.btn_inv_showAll.Name = "btn_inv_showAll";
            this.btn_inv_showAll.Size = new System.Drawing.Size(223, 36);
            this.btn_inv_showAll.TabIndex = 0;
            this.btn_inv_showAll.Text = "All Products / Refresh";
            this.btn_inv_showAll.UseVisualStyleBackColor = false;
            this.btn_inv_showAll.Click += new System.EventHandler(this.btn_inv_showAll_Click);
            // 
            // panelInvMain
            // 
            this.panelInvMain.Controls.Add(this.gridInventory);
            this.panelInvMain.Controls.Add(this.panelContainer);
            this.panelInvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvMain.Location = new System.Drawing.Point(0, 0);
            this.panelInvMain.Name = "panelInvMain";
            this.panelInvMain.Size = new System.Drawing.Size(843, 761);
            this.panelInvMain.TabIndex = 3;
            // 
            // gridInventory
            // 
            this.gridInventory.AllowUserToAddRows = false;
            this.gridInventory.AllowUserToDeleteRows = false;
            this.gridInventory.AllowUserToResizeColumns = false;
            this.gridInventory.AllowUserToResizeRows = false;
            this.gridInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInventory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.gridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInventory.Location = new System.Drawing.Point(0, 0);
            this.gridInventory.Name = "gridInventory";
            this.gridInventory.ReadOnly = true;
            this.gridInventory.Size = new System.Drawing.Size(305, 761);
            this.gridInventory.TabIndex = 1;
            this.gridInventory.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridInventory_CellMouseDoubleClick);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelContainer.Location = new System.Drawing.Point(305, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(538, 761);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Visible = false;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 761);
            this.Controls.Add(this.panelInvMain);
            this.Controls.Add(this.panelInvOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.panelInvOptions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_inv_dockdown.ResumeLayout(false);
            this.panel_inv_dockdown.PerformLayout();
            this.panelInvMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInvOptions;
        private System.Windows.Forms.Button btn_inv_reorder;
        private System.Windows.Forms.Button btn_inv_restock;
        private System.Windows.Forms.Button btn_workOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_byLocID;
        private System.Windows.Forms.Button btn_byProd;
        private System.Windows.Forms.Button btn_purchaseList;
        private System.Windows.Forms.Panel panel_inv_dockdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_inv_filter_search;
        private System.Windows.Forms.Button btn_inv_scan;
        private System.Windows.Forms.Button btn_inv_showAll;
        private System.Windows.Forms.Panel panelInvMain;
        private System.Windows.Forms.DataGridView gridInventory;
        private System.Windows.Forms.Panel panelContainer;
    }
}