namespace TSC403.Pages
{
    partial class frmSystemConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemConfig));
            this.gbKey = new System.Windows.Forms.GroupBox();
            this.txtProgramId = new System.Windows.Forms.TextBox();
            this.txtPassworkUnlock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.rdbLong = new System.Windows.Forms.RadioButton();
            this.rdbShort = new System.Windows.Forms.RadioButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbScale = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblDateSelect = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.gbKey.SuspendLayout();
            this.gbInformation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbKey
            // 
            this.gbKey.Controls.Add(this.btnUnlock);
            this.gbKey.Controls.Add(this.label2);
            this.gbKey.Controls.Add(this.label1);
            this.gbKey.Controls.Add(this.txtPassworkUnlock);
            this.gbKey.Controls.Add(this.txtProgramId);
            this.gbKey.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbKey.Location = new System.Drawing.Point(72, 95);
            this.gbKey.Name = "gbKey";
            this.gbKey.Size = new System.Drawing.Size(414, 205);
            this.gbKey.TabIndex = 0;
            this.gbKey.TabStop = false;
            this.gbKey.Text = "โปรแกรมใส้ข้อมูล";
            // 
            // txtProgramId
            // 
            this.txtProgramId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramId.Location = new System.Drawing.Point(27, 68);
            this.txtProgramId.Name = "txtProgramId";
            this.txtProgramId.Size = new System.Drawing.Size(365, 29);
            this.txtProgramId.TabIndex = 0;
            this.txtProgramId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProgramId.TextChanged += new System.EventHandler(this.txtProgramId_TextChanged);
            // 
            // txtPassworkUnlock
            // 
            this.txtPassworkUnlock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassworkUnlock.Location = new System.Drawing.Point(27, 124);
            this.txtPassworkUnlock.Name = "txtPassworkUnlock";
            this.txtPassworkUnlock.Size = new System.Drawing.Size(365, 29);
            this.txtPassworkUnlock.TabIndex = 1;
            this.txtPassworkUnlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "เลขที่โปรแกรม";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "รหัสผ่าน";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BackColor = System.Drawing.Color.Green;
            this.btnUnlock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnlock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUnlock.Location = new System.Drawing.Point(130, 159);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(159, 41);
            this.btnUnlock.TabIndex = 4;
            this.btnUnlock.Text = "ปลดล็อคโปรแกรม";
            this.btnUnlock.UseVisualStyleBackColor = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // gbInformation
            // 
            this.gbInformation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbInformation.Controls.Add(this.label9);
            this.gbInformation.Controls.Add(this.txtStationName);
            this.gbInformation.Controls.Add(this.lblDateSelect);
            this.gbInformation.Controls.Add(this.groupBox2);
            this.gbInformation.Controls.Add(this.label5);
            this.gbInformation.Controls.Add(this.txtCapacity);
            this.gbInformation.Controls.Add(this.label4);
            this.gbInformation.Controls.Add(this.cbbScale);
            this.gbInformation.Controls.Add(this.label3);
            this.gbInformation.Controls.Add(this.monthCalendar1);
            this.gbInformation.Controls.Add(this.rdbShort);
            this.gbInformation.Controls.Add(this.rdbLong);
            this.gbInformation.Controls.Add(this.textBox3);
            this.gbInformation.Controls.Add(this.btnSave);
            this.gbInformation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInformation.Location = new System.Drawing.Point(507, 12);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(511, 570);
            this.gbInformation.TabIndex = 5;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "ข้อมูลโปรแกรม";
            this.gbInformation.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(346, 523);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(159, 41);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "บันทึกการตั้งค่า";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(22, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(218, 29);
            this.textBox3.TabIndex = 5;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdbLong
            // 
            this.rdbLong.AutoSize = true;
            this.rdbLong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLong.Location = new System.Drawing.Point(289, 15);
            this.rdbLong.Name = "rdbLong";
            this.rdbLong.Size = new System.Drawing.Size(98, 25);
            this.rdbLong.TabIndex = 6;
            this.rdbLong.TabStop = true;
            this.rdbLong.Text = "ต่ออายุถาวร";
            this.rdbLong.UseVisualStyleBackColor = true;
            this.rdbLong.CheckedChanged += new System.EventHandler(this.rdbLong_CheckedChanged);
            // 
            // rdbShort
            // 
            this.rdbShort.AutoSize = true;
            this.rdbShort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbShort.Location = new System.Drawing.Point(289, 46);
            this.rdbShort.Name = "rdbShort";
            this.rdbShort.Size = new System.Drawing.Size(115, 25);
            this.rdbShort.TabIndex = 7;
            this.rdbShort.TabStop = true;
            this.rdbShort.Text = "ต่ออายุชั่วคราว";
            this.rdbShort.UseVisualStyleBackColor = true;
            this.rdbShort.CheckedChanged += new System.EventHandler(this.rdbShort_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Enabled = false;
            this.monthCalendar1.Location = new System.Drawing.Point(284, 83);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "เลขที่โปรแกรม";
            // 
            // cbbScale
            // 
            this.cbbScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbScale.FormattingEnabled = true;
            this.cbbScale.Items.AddRange(new object[] {
            "IQ-355",
            "3590ET",
            "X3",
            "480",
            "620"});
            this.cbbScale.Location = new System.Drawing.Point(22, 117);
            this.cbbScale.Name = "cbbScale";
            this.cbbScale.Size = new System.Drawing.Size(218, 29);
            this.cbbScale.TabIndex = 10;
            this.cbbScale.DropDown += new System.EventHandler(this.cbbScale_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "ชื่อเครื่องชั่ง";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "น้ำหนักสูงสุดของเครื่องชั่ง (กก.)";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacity.Location = new System.Drawing.Point(25, 181);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(218, 29);
            this.txtCapacity.TabIndex = 12;
            this.txtCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapacity_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCompany);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 236);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลโปรแกรม";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 21);
            this.label8.TabIndex = 9;
            this.label8.Text = "ชื่อบริษัท";
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(13, 64);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(452, 29);
            this.txtCompany.TabIndex = 5;
            this.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "ที่อยู่บริษัท";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(13, 130);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(452, 29);
            this.txtAddress.TabIndex = 10;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "เบอร์ติดต่อ";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(13, 197);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(452, 29);
            this.txtPhone.TabIndex = 12;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDateSelect
            // 
            this.lblDateSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateSelect.Location = new System.Drawing.Point(280, 253);
            this.lblDateSelect.Name = "lblDateSelect";
            this.lblDateSelect.Size = new System.Drawing.Size(182, 21);
            this.lblDateSelect.TabIndex = 15;
            this.lblDateSelect.Text = "....";
            this.lblDateSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 21);
            this.label9.TabIndex = 17;
            this.label9.Text = "ชื่อสถานีชั่ง";
            // 
            // txtStationName
            // 
            this.txtStationName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStationName.Location = new System.Drawing.Point(25, 242);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(218, 29);
            this.txtStationName.TabIndex = 16;
            this.txtStationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmSystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 639);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.gbKey);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSystemConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "กำหนดค่าต่าง ๆ ของโปรแกรม";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSystemConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmSystemConfig_Load);
            this.gbKey.ResumeLayout(false);
            this.gbKey.PerformLayout();
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbKey;
        private System.Windows.Forms.TextBox txtProgramId;
        private System.Windows.Forms.TextBox txtPassworkUnlock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdbLong;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton rdbShort;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblDateSelect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStationName;
    }
}