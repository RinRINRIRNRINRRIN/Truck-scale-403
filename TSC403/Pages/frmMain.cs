using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // 1. กำหนด Path ของไฟล์ฐานข้อมูล (สมมติว่าให้อยู่ในโฟลเดอร์ Data)
            string dbFilePath = Application.StartupPath + "\\TSC403.db";
            string connectionString = $"Data Source={dbFilePath};Mode=ReadWriteCreate;";

            // 2. ตรวจสอบว่ามีไฟล์ฐานข้อมูลอยู่แล้วหรือไม่
            bool isNewDatabase = !File.Exists(dbFilePath);

            // 3. ตรวจสอบและสร้างโฟลเดอร์ (ถ้าระบุ Path ไว้แล้วโฟลเดอร์ยังไม่มี)
            string directoryPath = Path.GetDirectoryName(dbFilePath);
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"สร้างโฟลเดอร์ใหม่ที่: {directoryPath}");
            }

            // 4. เริ่มการเชื่อมต่อ
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (isNewDatabase)
                    {
                        Console.WriteLine("ไม่พบไฟล์ฐานข้อมูล ระบบได้สร้างไฟล์ใหม่เรียบร้อยแล้ว!");

                        // ถ้านี่คือฐานข้อมูลใหม่ ให้รันคำสั่งสร้างตาราง
                        InitializeDatabase(connection);
                    }
                    else
                    {
                        Console.WriteLine("พบไฟล์ฐานข้อมูลเดิม เชื่อมต่อสำเร็จ!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: {ex.Message}");
                }
            }
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
    }
}
