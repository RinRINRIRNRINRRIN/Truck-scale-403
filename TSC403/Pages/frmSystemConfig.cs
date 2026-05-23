using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Functions;
using TSC403.Models;

namespace TSC403.Pages
{
    public partial class frmSystemConfig : Form
    {
        public frmSystemConfig()
        {
            InitializeComponent();

            // จัดหน้าจอ gbKey ให้อยู่ตรงกลางของหน้าจอ
            gbKey.Left = (this.ClientSize.Width - gbKey.Width) / 2;
            gbKey.Top = (this.ClientSize.Height - gbKey.Height) / 2;

            // จัดหน้าจอ gbInformation ให้อยู่ตรงกลางของหน้าจอ
            gbInformation.Left = (this.ClientSize.Width - gbInformation.Width) / 2;
            gbInformation.Top = (this.ClientSize.Height - gbInformation.Height) / 2;

            // กำหนดค่า scalename ที่ cbbScale
        }

        private void frmSystemConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmSystemConfig_Load(object sender, EventArgs e)
        {
            if (SystemModels.ProgramId != null && SystemModels.ProgramId != "")
            {
                txtProgramId.Text = SystemModels.ProgramId;
                txtProgramId.Enabled = false;
            }

            // นำข้อมูล SystemModel มาแสดง
            txtCapacity.Text = SystemModels.CapacityScale.ToString();
            txtStationName.Text = SystemModels.StationName;
            txtAddress.Text = SystemModels.TicketAddress;
            txtPhone.Text = SystemModels.TicketPhone;
            txtCompany.Text = SystemModels.TicketCompany;


            cbbScale.Items.Add(SystemModels.ScaleName);
            cbbScale.SelectedIndex = 0;
            if (SystemModels.DateExpire == "FOREVER")
            {
                lblDateSelect.Text = SystemModels.DateExpire;
                rdbLong.Checked = true;
            }
            else
            {
                rdbShort.Checked = true;
                try
                {
                    DateTime date = DateTime.Parse(SystemModels.DateExpire);
                    monthCalendar1.SelectionStart = date.AddYears(543);
                }
                catch
                {


                }

            }

        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            // เตรียมรหัสสำหรับเช็ค
            Md5._key_programNumber = txtProgramId.Text;
            Md5._key_type = "SETTING";
            string programIdToMd5 = Md5.GEN_MD5();
            Console.WriteLine(programIdToMd5);

            if (txtPassworkUnlock.Text == "" || txtProgramId.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // เช็คว่ารหัสที่กรอกเข้ามาถูกต้องหรือไม่ โดยเทียบจาก MD5
            if (txtPassworkUnlock.Text == programIdToMd5)
            {
                // ถ้ารหัสถูกต้อง ให้เปิดหน้าจอ เปิด gbInformation และซ่อน gbKey
                gbInformation.Visible = true;
                gbKey.Visible = false;

            }
            else
            {
                MessageBox.Show("รหัสไม่ถูกต้อง กรุณาตรวจสอบอีกครั้งหรือ ติดต่อผู้ดูแลระบบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProgramId_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = txtProgramId.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // เช็คค่าว่างก่อนว่ามีการกรอกข้อมูลครบถ้วนหรือไม่
            if (cbbScale.Text == "" || txtStationName.Text == "" || txtCapacity.Text == "0" || txtCapacity.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (TextBox txt in gbInformation.Controls.OfType<TextBox>())
            {
                if (txt.Text == "")
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // เช็คว่าให้เลือกวันที่หมดอายุหรือไม่
            if (rdbLong.Checked == false && rdbShort.Checked == false)
            {
                MessageBox.Show("กรุณาเลือกประเภทการหมดอายุ", "วันที่หมดอายุ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdbShort.Checked && lblDateSelect.Text == "....")
            {
                MessageBox.Show("กรุณาเลือกวันที่หมดอายุก่อน กดบันทึก", "วันที่หมดอายุ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // เช็ควันที่ห้ามหมดอายุย้อนหลังวันปัจจุบัน หรือ ห้ามหมดอายุวันนี้
            if (rdbShort.Checked)
            {
                DateTime dateTimeSelect = DateTime.Parse(lblDateSelect.Text);
                string dateStr = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
                DateTime dateConvertSelect = DateTime.Parse(dateStr);
                if (dateTimeSelect <= dateConvertSelect)
                {
                    MessageBox.Show("กรุณาตรวจสอบวันที่หมดอายุอีกคร้ัง", "วันหมดอายุ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }



            // กำหนดค่าไปที่ตัวแปร SystemModels เพื่อเตรียมส่งไปเก็บที่ Registry
            SystemModels.ProgramId = txtProgramId.Text;
            SystemModels.ScaleName = cbbScale.Text;
            SystemModels.StationName = txtStationName.Text;
            SystemModels.CapacityScale = int.Parse(txtCapacity.Text);
            SystemModels.DateCurrent = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
            SystemModels.DateExpire = lblDateSelect.Text;
            SystemModels.TicketAddress = txtAddress.Text;
            SystemModels.TicketCompany = txtCompany.Text;
            SystemModels.TicketPhone = txtPhone.Text;

            // ส่งค่าไปบันทึกที่ Registry
            Registryz registryz = new Registryz();
            if (registryz.setParameterRegistry())
            {
                MessageBox.Show("บันทึกข้อมูลสำเร็จ กรุณาเปิดโปรแกรมใหม่อีกครั้ง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล กรุณาลองใหม่อีกครั้งหรือ ติดต่อผู้ดูแลระบบ \nError : " + registryz.Err, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblDateSelect.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
        }

        private void rdbLong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLong.Checked)
            {
                lblDateSelect.Text = "FOREVER";
                monthCalendar1.Enabled = false;
            }
        }

        private void rdbShort_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbShort.Checked)
            {
                lblDateSelect.Text = "....";
                monthCalendar1.Enabled = true;
            }
        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ป้องกันการป้อนตัวอักษรที่ไม่ใช่ตัวเลข
            }
        }

        private void cbbScale_DropDown(object sender, EventArgs e)
        {
            cbbScale.Items.Clear();
            cbbScale.Items.Add("IQ-355");
            cbbScale.Items.Add("3590ET");
            cbbScale.Items.Add("X3");
            cbbScale.Items.Add("480");
            cbbScale.Items.Add("620");
        }
    }
}