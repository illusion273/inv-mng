
namespace app3rework.Forms
{
    partial class EditPurchase
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
            this.panel_right = new System.Windows.Forms.Panel();
            this.btn_complete_order = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Rejected = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Received = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.btn_complete_order);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(813, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(80, 204);
            this.panel_right.TabIndex = 2;
            // 
            // btn_complete_order
            // 
            this.btn_complete_order.BackColor = System.Drawing.Color.White;
            this.btn_complete_order.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_complete_order.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_complete_order.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_complete_order.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_complete_order.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btn_complete_order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_complete_order.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_complete_order.Location = new System.Drawing.Point(0, 165);
            this.btn_complete_order.Name = "btn_complete_order";
            this.btn_complete_order.Size = new System.Drawing.Size(80, 39);
            this.btn_complete_order.TabIndex = 0;
            this.btn_complete_order.Text = "End Order";
            this.btn_complete_order.UseVisualStyleBackColor = false;
            this.btn_complete_order.Click += new System.EventHandler(this.btn_complete_order_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rejected,
            this.Received});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(813, 204);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Rejected
            // 
            this.Rejected.HeaderText = "Rejected";
            this.Rejected.Name = "Rejected";
            this.Rejected.Text = "❌\t";
            this.Rejected.UseColumnTextForButtonValue = true;
            // 
            // Received
            // 
            this.Received.HeaderText = "Received";
            this.Received.Name = "Received";
            this.Received.Text = "✔";
            this.Received.UseColumnTextForButtonValue = true;
            // 
            // EditPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 204);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel_right);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditPurchase";
            this.Text = "EditPurchase";
            this.panel_right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Button btn_complete_order;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Rejected;
        private System.Windows.Forms.DataGridViewButtonColumn Received;
    }
}