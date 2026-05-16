namespace TSC403.Pages
{
    partial class frmWeightOutList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeightOutList));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_licensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_weighIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_id,
            this.cl_licensePlate,
            this.cl_weighIn,
            this.cl_dateIn,
            this.cl_customer,
            this.cl_product});
            this.dgv.Location = new System.Drawing.Point(6, 65);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(555, 287);
            this.dgv.TabIndex = 6;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(410, 358);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(151, 37);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "เลือกรถชั่ง";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(200, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "เลือกรายการรถชั่งออก";
            // 
            // cl_id
            // 
            this.cl_id.HeaderText = "order_id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ReadOnly = true;
            this.cl_id.Visible = false;
            // 
            // cl_licensePlate
            // 
            this.cl_licensePlate.HeaderText = "ทะเบียนรถ";
            this.cl_licensePlate.Name = "cl_licensePlate";
            this.cl_licensePlate.ReadOnly = true;
            // 
            // cl_weighIn
            // 
            this.cl_weighIn.HeaderText = "น้ำหนัก";
            this.cl_weighIn.Name = "cl_weighIn";
            this.cl_weighIn.ReadOnly = true;
            // 
            // cl_dateIn
            // 
            this.cl_dateIn.HeaderText = "วันที่ชั่งเข้า";
            this.cl_dateIn.Name = "cl_dateIn";
            this.cl_dateIn.ReadOnly = true;
            // 
            // cl_customer
            // 
            this.cl_customer.HeaderText = "บริษัท";
            this.cl_customer.Name = "cl_customer";
            this.cl_customer.ReadOnly = true;
            // 
            // cl_product
            // 
            this.cl_product.HeaderText = "สินค้า";
            this.cl_product.Name = "cl_product";
            this.cl_product.ReadOnly = true;
            // 
            // frmWeightOutList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(568, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWeightOutList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ชั่งออก";
            this.Load += new System.EventHandler(this.frmWeightOutList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_licensePlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_weighIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_dateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_product;
    }
}