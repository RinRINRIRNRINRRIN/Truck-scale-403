namespace TSC403.Pages
{
    partial class frmDeleteAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteAdmin));
            this.gbPassword = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDateStop = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteDate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteOrderNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteLicensePlate = new System.Windows.Forms.Button();
            this.cbbLicensePlate = new System.Windows.Forms.ComboBox();
            this.rdbAllLicensePlate = new System.Windows.Forms.RadioButton();
            this.rdbLicenseKeyIn = new System.Windows.Forms.RadioButton();
            this.gbPassword.SuspendLayout();
            this.gbInformation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPassword
            // 
            this.gbPassword.Controls.Add(this.txtPassword);
            this.gbPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPassword.Location = new System.Drawing.Point(136, 74);
            this.gbPassword.Name = "gbPassword";
            this.gbPassword.Size = new System.Drawing.Size(200, 79);
            this.gbPassword.TabIndex = 0;
            this.gbPassword.TabStop = false;
            this.gbPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 37);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(188, 29);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.groupBox1);
            this.gbInformation.Controls.Add(this.groupBox3);
            this.gbInformation.Controls.Add(this.groupBox2);
            this.gbInformation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInformation.Location = new System.Drawing.Point(355, 1);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(362, 424);
            this.gbInformation.TabIndex = 1;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "ข้อมูลรถบรรทุก";
            this.gbInformation.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.dtpDateStop);
            this.groupBox1.Controls.Add(this.dtpDateStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDeleteDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 140);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ลบข้อมูลรายงานจากวันที่";
            // 
            // dtpDateStop
            // 
            this.dtpDateStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateStop.Location = new System.Drawing.Point(96, 63);
            this.dtpDateStop.Name = "dtpDateStop";
            this.dtpDateStop.Size = new System.Drawing.Size(200, 29);
            this.dtpDateStop.TabIndex = 6;
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateStart.Location = new System.Drawing.Point(96, 28);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(200, 29);
            this.dtpDateStart.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "วันที่สิ้นสุด";
            // 
            // btnDeleteDate
            // 
            this.btnDeleteDate.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDate.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDate.Location = new System.Drawing.Point(14, 104);
            this.btnDeleteDate.Name = "btnDeleteDate";
            this.btnDeleteDate.Size = new System.Drawing.Size(322, 30);
            this.btnDeleteDate.TabIndex = 4;
            this.btnDeleteDate.Tag = "DATE";
            this.btnDeleteDate.Text = "ลบข้อมูล";
            this.btnDeleteDate.UseVisualStyleBackColor = false;
            this.btnDeleteDate.Click += new System.EventHandler(this.deleteOrder);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "วันที่เริ่มต้น";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.btnDeleteOrderNumber);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtOrderNumber);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 107);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ลบข้อมูลจากเลขที่การชั่ง";
            // 
            // btnDeleteOrderNumber
            // 
            this.btnDeleteOrderNumber.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteOrderNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrderNumber.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOrderNumber.Location = new System.Drawing.Point(14, 71);
            this.btnDeleteOrderNumber.Name = "btnDeleteOrderNumber";
            this.btnDeleteOrderNumber.Size = new System.Drawing.Size(322, 30);
            this.btnDeleteOrderNumber.TabIndex = 4;
            this.btnDeleteOrderNumber.Tag = "ORDERNUMBER";
            this.btnDeleteOrderNumber.Text = "ลบข้อมูล";
            this.btnDeleteOrderNumber.UseVisualStyleBackColor = false;
            this.btnDeleteOrderNumber.Click += new System.EventHandler(this.deleteOrder);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "เลขที่";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(62, 25);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(274, 29);
            this.txtOrderNumber.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.btnDeleteLicensePlate);
            this.groupBox2.Controls.Add(this.cbbLicensePlate);
            this.groupBox2.Controls.Add(this.rdbAllLicensePlate);
            this.groupBox2.Controls.Add(this.rdbLicenseKeyIn);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 131);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รถค้างชั่ง";
            // 
            // btnDeleteLicensePlate
            // 
            this.btnDeleteLicensePlate.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteLicensePlate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLicensePlate.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLicensePlate.Location = new System.Drawing.Point(14, 90);
            this.btnDeleteLicensePlate.Name = "btnDeleteLicensePlate";
            this.btnDeleteLicensePlate.Size = new System.Drawing.Size(322, 30);
            this.btnDeleteLicensePlate.TabIndex = 3;
            this.btnDeleteLicensePlate.Tag = "LICENSE_PLATE";
            this.btnDeleteLicensePlate.Text = "ลบข้อมูล";
            this.btnDeleteLicensePlate.UseVisualStyleBackColor = false;
            this.btnDeleteLicensePlate.Click += new System.EventHandler(this.deleteOrder);
            // 
            // cbbLicensePlate
            // 
            this.cbbLicensePlate.Enabled = false;
            this.cbbLicensePlate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLicensePlate.FormattingEnabled = true;
            this.cbbLicensePlate.Location = new System.Drawing.Point(185, 27);
            this.cbbLicensePlate.Name = "cbbLicensePlate";
            this.cbbLicensePlate.Size = new System.Drawing.Size(151, 29);
            this.cbbLicensePlate.TabIndex = 2;
            // 
            // rdbAllLicensePlate
            // 
            this.rdbAllLicensePlate.AutoSize = true;
            this.rdbAllLicensePlate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAllLicensePlate.Location = new System.Drawing.Point(15, 59);
            this.rdbAllLicensePlate.Name = "rdbAllLicensePlate";
            this.rdbAllLicensePlate.Size = new System.Drawing.Size(88, 25);
            this.rdbAllLicensePlate.TabIndex = 1;
            this.rdbAllLicensePlate.TabStop = true;
            this.rdbAllLicensePlate.Text = "ลบทั้งหมด";
            this.rdbAllLicensePlate.UseVisualStyleBackColor = true;
            this.rdbAllLicensePlate.CheckedChanged += new System.EventHandler(this.rdbAllLicensePlate_CheckedChanged);
            // 
            // rdbLicenseKeyIn
            // 
            this.rdbLicenseKeyIn.AutoSize = true;
            this.rdbLicenseKeyIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLicenseKeyIn.Location = new System.Drawing.Point(15, 28);
            this.rdbLicenseKeyIn.Name = "rdbLicenseKeyIn";
            this.rdbLicenseKeyIn.Size = new System.Drawing.Size(137, 25);
            this.rdbLicenseKeyIn.TabIndex = 0;
            this.rdbLicenseKeyIn.TabStop = true;
            this.rdbLicenseKeyIn.Text = "เลขตามทะเบียนรถ";
            this.rdbLicenseKeyIn.UseVisualStyleBackColor = true;
            this.rdbLicenseKeyIn.CheckedChanged += new System.EventHandler(this.rdbLicenseKeyIn_CheckedChanged);
            // 
            // frmDeleteAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(201)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(755, 437);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.gbPassword);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeleteAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSW";
            this.Load += new System.EventHandler(this.frmDeleteAdmin_Load);
            this.gbPassword.ResumeLayout(false);
            this.gbPassword.PerformLayout();
            this.gbInformation.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbLicenseKeyIn;
        private System.Windows.Forms.RadioButton rdbAllLicensePlate;
        private System.Windows.Forms.ComboBox cbbLicensePlate;
        private System.Windows.Forms.Button btnDeleteLicensePlate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Button btnDeleteOrderNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateStop;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.Label label3;
    }
}