namespace TSC403.Pages
{
    partial class frmHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cl_print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_orderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_licensePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_weighIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_dateOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_weightOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_netWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(713, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 32);
            this.label6.TabIndex = 16;
            this.label6.Text = "0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(873, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "กิโลกรัม";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(574, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 32);
            this.label3.TabIndex = 15;
            this.label3.Text = "น้ำหนักรวม";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "เที่ยว";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "จำนวน";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(174, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 32);
            this.label5.TabIndex = 17;
            this.label5.Text = "0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_print,
            this.cl_id,
            this.cl_orderNumber,
            this.cl_licensePlate,
            this.cl_dateIn,
            this.cl_weighIn,
            this.cl_dateOut,
            this.cl_weightOut,
            this.cl_netWeight,
            this.cl_product,
            this.cl_customer});
            this.dgv.Location = new System.Drawing.Point(8, 120);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 30;
            this.dgv.Size = new System.Drawing.Size(1057, 411);
            this.dgv.TabIndex = 11;
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            // 
            // cl_print
            // 
            this.cl_print.HeaderText = "";
            this.cl_print.Name = "cl_print";
            this.cl_print.ReadOnly = true;
            this.cl_print.Text = "พิมพ์ตั๋ว";
            this.cl_print.UseColumnTextForButtonValue = true;
            // 
            // cl_id
            // 
            this.cl_id.HeaderText = "Id";
            this.cl_id.Name = "cl_id";
            this.cl_id.ReadOnly = true;
            this.cl_id.Visible = false;
            // 
            // cl_orderNumber
            // 
            this.cl_orderNumber.HeaderText = "ลำดับที่";
            this.cl_orderNumber.Name = "cl_orderNumber";
            this.cl_orderNumber.ReadOnly = true;
            // 
            // cl_licensePlate
            // 
            this.cl_licensePlate.HeaderText = "ทะเบียนรถ";
            this.cl_licensePlate.Name = "cl_licensePlate";
            this.cl_licensePlate.ReadOnly = true;
            // 
            // cl_dateIn
            // 
            this.cl_dateIn.HeaderText = "วันที่ชั่งเข้า";
            this.cl_dateIn.Name = "cl_dateIn";
            this.cl_dateIn.ReadOnly = true;
            // 
            // cl_weighIn
            // 
            this.cl_weighIn.HeaderText = "น้ำหนักชั่งเข้า";
            this.cl_weighIn.Name = "cl_weighIn";
            this.cl_weighIn.ReadOnly = true;
            // 
            // cl_dateOut
            // 
            this.cl_dateOut.HeaderText = "วันที่ชั่งออก";
            this.cl_dateOut.Name = "cl_dateOut";
            this.cl_dateOut.ReadOnly = true;
            // 
            // cl_weightOut
            // 
            this.cl_weightOut.HeaderText = "น้ำหนักชั่งออก";
            this.cl_weightOut.Name = "cl_weightOut";
            this.cl_weightOut.ReadOnly = true;
            // 
            // cl_netWeight
            // 
            this.cl_netWeight.HeaderText = "น้ำหนักสุทธิ";
            this.cl_netWeight.Name = "cl_netWeight";
            this.cl_netWeight.ReadOnly = true;
            // 
            // cl_product
            // 
            this.cl_product.HeaderText = "สินค้า";
            this.cl_product.Name = "cl_product";
            this.cl_product.ReadOnly = true;
            // 
            // cl_customer
            // 
            this.cl_customer.HeaderText = "บริษัท";
            this.cl_customer.Name = "cl_customer";
            this.cl_customer.ReadOnly = true;
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.mainMenuToolStripMenuItem.Text = "EXIT :F12";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1072, 29);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(863, 537);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(98, 32);
            this.btnExcel.TabIndex = 18;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(967, 537);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(98, 32);
            this.btnPrintReport.TabIndex = 18;
            this.btnPrintReport.Text = "พิมพ์รายงาน";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1072, 577);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายงาน";
            this.Load += new System.EventHandler(this.frmHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DataGridViewButtonColumn cl_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_orderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_licensePlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_dateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_weighIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_dateOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_weightOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_netWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_customer;
    }
}