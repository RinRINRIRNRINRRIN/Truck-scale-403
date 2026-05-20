using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Db;
using TSC403.Functions;
using TSC403.Models;
using TSC403.Pages;
using TSC403.Reports;

namespace TSC403
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ดึงคาจาก Registry มาเพื่อเช็คข้อมูลของระบบ
            Registryz registryz = new Registryz();
            if (!registryz.checkRegistryFile())
            {
                // เปิดหน้าเพื่อให้ admin กำหนดค่าต่าง ๆของระบบ
                frmSystemConfig frmSystemConfig = new frmSystemConfig();
                frmSystemConfig.ShowDialog();
                return;
            }

            // เช็คว่าโปรแกรมหมดอายุหรือยัง
            DateTime dateCurrent = DateTime.ParseExact(SystemModels.DateCurrent, "yyyy-MM-dd", null);
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
            DateTime currentConvert = DateTime.Parse(currentDate);
            DateTime lastDateInSystem = DateTime.Parse(SystemModels.DateCurrent);

            if (SystemModels.DateExpire != "FOREVER")
            {
            DateTime dateExpire = DateTime.ParseExact(SystemModels.DateExpire, "yyyy-MM-dd", null);
                if (currentConvert > dateExpire)
                {
                    MessageBox.Show("โปรแกรมหมดอายุการใช้งานแล้ว กรุณาติดต่อผู้ดูแลระบบ! \nError : " + DbContect.Err, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    frmSystemConfig frmSystemConfig = new frmSystemConfig();
                    frmSystemConfig.ShowDialog();
                    return;
                }
            }


            // เช็คว่าผู้ใช้มีการเปลี่ยนวันที่คอมพิวเตอร์หรือไม่ โดยเช็คจาก SystemModels.DateCurrent

            if (currentConvert < lastDateInSystem)
            {
                MessageBox.Show("พบการเปลี่ยนวันที่คอมพิวเตอร์");
                frmSystemConfig frmSystemConfig = new frmSystemConfig();
                frmSystemConfig.ShowDialog();
                return;
            }




            // หากไม่มีปัญหาให้อัพเดทวันที่ปัจจุบันใน Registry เพื่อใช้ในการเช็คครั้งถัดไป
            registryz.updateDateCurrent();


            // เช็คการเชื่อมต่อฐานข้อมูลและสร้างตารางถ้าจำเป็น
            if (!DbContect.TestConnection())
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ กรุณาตรวจสอบการตั้งค่าและลองใหม่อีกครั้ง! \nError : " + DbContect.Err, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }


            lblProgramIdAndCompany.Text = $"{SystemModels.ProgramId} - {SystemModels.TicketCompany}";
        }

        static void InitializeDatabase(SqliteConnection connection)
        {
            var command = connection.CreateCommand();

            // โค้ดสร้างตาราง
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Employees (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EmpCode TEXT UNIQUE NOT NULL,
                    FullName TEXT NOT NULL
                );       
            ";

            command.ExecuteNonQuery();
            Console.WriteLine("สร้างโครงสร้างตารางเริ่มต้นสำเร็จ!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmWeight frmWeight = new frmWeight();
            this.Hide();
            frmWeight.ShowDialog();
            this.Show();
        }

        private void ขอมลบรษทToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            this.Hide();
            frmCustomer.ShowDialog();
            this.Show();
        }

        private void ขอมลสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct frmProduct = new frmProduct();
            this.Hide();
            frmProduct.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDailyReport frmDailyReport = new frmDailyReport();
            this.Hide();
            frmDailyReport.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch();
            this.Hide();
            frmSearch.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCarProcess frmCarProcess = new frmCarProcess();
            this.Hide();
            frmCarProcess.ShowDialog();
            this.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.F9)
            {
                frmDeleteAdmin frmDeleteAdmin = new frmDeleteAdmin();
                this.Hide();
                frmDeleteAdmin.ShowDialog(); 
                this.Show();
                return;
            }

            if (e.KeyCode == Keys.F9)
            {
                frmSystemConfig frmSystemConfig = new frmSystemConfig();
                this.Hide();
                frmSystemConfig.ShowDialog(); ;
                this.Show();
                return;
            }
            
        }

        private void รายงานวนนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void รายงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void ขอมลรToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void รถคางชงToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5.PerformClick();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.ShowDialog();  
        }
    }
}
