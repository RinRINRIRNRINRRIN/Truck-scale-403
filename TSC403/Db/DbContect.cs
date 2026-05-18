using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSC403.Db
{
    internal class DbContect
    {
        // กำหนดที่อยู่ของไฟล์ฐานข้อมูลตรงนี้ครับ (สามารถเปลี่ยน Path ได้)
        public static string ConnectionString { get; set; } = $"Data Source={Application.StartupPath}\\TSC403.db;Mode=ReadWriteCreate;";

        public static string Err;
        // Method สำหรับทดสอบการเชื่อมต่อ
        public static bool TestConnection()
        {
            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("เชื่อมต่อฐานข้อมูลสำเร็จ!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
        }
    }
}
