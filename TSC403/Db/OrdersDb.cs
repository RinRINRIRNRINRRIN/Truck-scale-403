using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC403.Models;

namespace TSC403.Db
{
    internal class OrdersDb
    {
        public string Err { get; set; }
        public string Generateorder_number()
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    // ดึงเดือนและปีปัจจุบันในรูปแบบ YY/MM
                    string currentPrefix = DateTime.Now.ToString("yy/MM", System.Globalization.CultureInfo.CreateSpecificCulture("TH-th"));

                    // ค้นหาเลข Order ล่าสุดที่มี Prefix ตรงกับเดือนปัจจุบัน
                    command.CommandText = @"
                SELECT order_number 
                FROM orders 
                WHERE order_number LIKE @Prefix 
                ORDER BY order_number DESC 
                LIMIT 1;
            ";
                    command.Parameters.AddWithValue("@Prefix", currentPrefix + "/%");

                    var lastOrder = command.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(lastOrder))
                    {
                        // ถ้ายังไม่มีข้อมูลของเดือนนี้เลย ให้เริ่มที่ 0001
                        return $"{currentPrefix}/0001";
                    }
                    else
                    {
                        // ตัดเอาเลขส่วน SSSS (4 ตัวท้าย) มาเพื่อบวกเพิ่ม
                        string lastSeqStr = lastOrder.Substring(lastOrder.Length - 4);
                        if (int.TryParse(lastSeqStr, out int lastSeq))
                        {
                            int newSeq = lastSeq + 1;
                            // คืนค่ารูปแบบ YY/MM/SSSS โดยใช้ D4 เพื่อบังคับให้เป็นเลข 4 หลัก
                            return $"{currentPrefix}/{newSeq.ToString("D4")}";
                        }

                        return $"{currentPrefix}/0001";
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return null;
            }
        }

        public bool AddNew(OrderModels order)
        {
            try
            {
                using (SqliteConnection con = new SqliteConnection(DbContect.ConnectionString))
                {
                    con.Open();
                    string query = "INSERT INTO orders (license_plate, order_number, product_name, product_code, customer_name, customer_code,note, net_weight, status) " +
                        "VALUES (@license_plate, @order_number, @product_name,@product_code, @customer_name, @product_name,@note, @net_weight, @status)";
                    using (SqliteCommand cmd = new SqliteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@license_plate", order.LicensePlate);
                        cmd.Parameters.AddWithValue("@order_number", order.OrderNumber);
                        cmd.Parameters.AddWithValue("@product_name", order.ProductName);
                        cmd.Parameters.AddWithValue("@product_code", order.ProductCode);
                        cmd.Parameters.AddWithValue("@customer_name", order.CustomerName);
                        cmd.Parameters.AddWithValue("@customer_code", order.CustomerCode);
                        cmd.Parameters.AddWithValue("@note", order.Note);
                        cmd.Parameters.AddWithValue("@net_weight", order.NetWeight);
                        cmd.Parameters.AddWithValue("@status", order.Status);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
            return true;
        }

        // ดึงข้อมูลตาม Id
        public OrderModels SelectById(int id)
        {
            OrderModels order = null;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, license_plate, order_number, product_name, customer_name, note, net_weight, status, product_code,customer_code FROM orders WHERE id = @Id;";
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new OrderModels
                            {
                                Id = reader.GetInt32(0),
                                LicensePlate = reader.IsDBNull(1) ? null : reader.GetString(1),
                                OrderNumber = reader.IsDBNull(2) ? null : reader.GetString(2),
                                ProductName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                CustomerName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Note = reader.IsDBNull(5) ? null : reader.GetString(5),
                                NetWeight = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                Status = reader.IsDBNull(7) ? null : reader.GetString(7),
                                ProductCode = reader.IsDBNull(8) ? null : reader.GetString(8),
                                CustomerCode = reader.IsDBNull(9) ? null : reader.GetString(9),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return order;
        }

        // ดึงข้อมูลตาม order_number
        public OrderModels SelectByorder_number(string order_number)
        {
            OrderModels order = null;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, license_plate, order_number, product_name, customer_name, note, net_weight, status, product_code,customer_code FROM orders WHERE order_number = @order_number;";
                    command.Parameters.AddWithValue("@order_number", order_number);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new OrderModels
                            {
                                Id = reader.GetInt32(0),
                                LicensePlate = reader.IsDBNull(1) ? null : reader.GetString(1),
                                OrderNumber = reader.IsDBNull(2) ? null : reader.GetString(2),
                                ProductName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                CustomerName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Note = reader.IsDBNull(5) ? null : reader.GetString(5),
                                NetWeight = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                Status = reader.IsDBNull(7) ? null : reader.GetString(7),
                                ProductCode = reader.IsDBNull(8) ? null : reader.GetString(8),
                                CustomerCode = reader.IsDBNull(9) ? null : reader.GetString(9),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return order;
        }

        // ดึงข้อมูลทั้งหมด
        public List<OrderModels> SelectAll()
        {
            var orders = new List<OrderModels>();
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, license_plate, order_number, product_name, customer_name, note, net_weight, status, product_code,customer_code FORM orders;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new OrderModels
                            {
                                Id = reader.GetInt32(0),
                                LicensePlate = reader.IsDBNull(1) ? null : reader.GetString(1),
                                OrderNumber = reader.IsDBNull(2) ? null : reader.GetString(2),
                                ProductName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                CustomerName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Note = reader.IsDBNull(5) ? null : reader.GetString(5),
                                NetWeight = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                Status = reader.IsDBNull(7) ? null : reader.GetString(7),
                                ProductCode = reader.IsDBNull(8) ? null : reader.GetString(8),
                                CustomerCode = reader.IsDBNull(9) ? null : reader.GetString(9),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return null;
            }
            return orders;
        }

        // ดึงรายงานตาม query
        public DataTable SelectByQuery(string dateIn, string dateOut, string customer, string product, string license_plate, string status)
        {
            DataTable tb = new DataTable();
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    // 1. เขียน Query ยุบรวม และแก้ไขชื่อคอลัมน์ d_in ให้ถูกต้อง (d_in.datetimes)
                    string query = "SELECT " +
                                   "o.Id as 'Id', " +
                                   "o.order_number as 'OrderNumber', " +
                                   "o.license_plate as 'LicensePlate', " +
                                   "d_in.datetimes as 'DateIn', " +
                                   "d_in.weight as 'WeightIn', " +
                                   "d_out.datetimes as 'DateOut', " + // แก้ไขตัวสะกดจาก 'DateOu' เป็น 'DateOut'
                                   "d_out.weight as 'WeightOut', " +
                                   "o.net_weight as 'NetWeight', " +
                                   "o.product_name as 'ProductName', " +
                                   "o.customer_name as 'CustomerName' " +
                                   "FROM orders o " +
                                   "LEFT JOIN order_detail d_in ON o.id = d_in.order_id AND d_in.weight_type = 'FIRST' " +
                                   "LEFT JOIN order_detail d_out ON o.id = d_out.order_id AND d_out.weight_type = 'SECOND' " +
                                   "WHERE 1=1 ";

                    //if (!string.IsNullOrEmpty(dateOut) || !string.IsNullOrEmpty(dateIn) || !string.IsNullOrEmpty(customer) || !string.IsNullOrEmpty(product) || !string.IsNullOrEmpty(license_plate))
                    //{
                    //    query += "WHERE ";
                    //}

                    // 2. ตรวจสอบและต่อเงื่อนไข (เพิ่มเว้นวรรคด้านหน้าป้องกันคำสั่งติดกัน)
                    if (!string.IsNullOrEmpty(customer))
                        query += " AND o.customer_name LIKE @customer";

                    if (!string.IsNullOrEmpty(product))
                        query += " AND o.product_name LIKE @product";

                    if (!string.IsNullOrEmpty(license_plate))
                        query += " AND o.license_plate LIKE @license_plate";


                    if (!string.IsNullOrEmpty(dateIn) && !string.IsNullOrEmpty(dateOut))
                        query += "AND  d_in.datetimes BETWEEN @dateIn AND @dateOut "; // ใช้ Parameter และใส่ชื่อคอลัมน์ให้ถูกต้อง (แก้ไขจาก 'd_in.d_in' เป็น 'd_in.datetimes')";

                    // กำหนดค่าจริงของ query ให้กับ command Text
                    query += $" AND o.status = '{status}'";
                    query += " ORDER BY o.order_number DESC;";
                    command.CommandText = query;

                    // 3. ผูกค่า Parameters (ช่วยป้องกัน SQL Injection และจัดการเรื่อง Single Quote อัตโนมัติ)
                    if (!string.IsNullOrEmpty(customer))
                        command.Parameters.AddWithValue("@customer", $"%{customer}%"); // ใช้ LIKE กับ Wildcard
                    if (!string.IsNullOrEmpty(product))
                        command.Parameters.AddWithValue("@product", $"%{product}%"); // ใช้ LIKE กับ Wildcard
                    if (!string.IsNullOrEmpty(license_plate))
                        command.Parameters.AddWithValue("@license_plate", $"%{license_plate}%"); // ใช้ LIKE กับ Wildcard
                    if (!string.IsNullOrEmpty(dateIn) && !string.IsNullOrEmpty(dateOut))
                    {
                        command.Parameters.AddWithValue("@dateIn", $"{dateIn} 00:00:00");
                        command.Parameters.AddWithValue("@dateOut", $"{dateOut} 23:59:59");
                    }

                    // 4. ใช้ Reader ควบคู่กับ tb.Load เพื่อเทข้อมูลเข้า DataTable โดยตรง
                    using (var reader = command.ExecuteReader())
                    {
                        tb.Load(reader); // บรรทัดนี้จะดึงโครงสร้างคอลัมน์และข้อมูลทั้งหมดใส่ DataTable ให้ทันทีครับ
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message; // ตัวแปรเก็บ Error ส่วนกลางของคุณ
                return null;
            }

            return tb; // คืนค่ากลับไปเป็น DataTable พร้อมเอาไปผูกกับ DataGridView ได้ทันที
        }

        // ดึงรายการรถที่ยังเป็น  Process 
        public DataTable Selectstatus(string status)
        {
            DataTable orders;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = $"SELECT a.id, a.license_plate, b.datetimes , b.weight,a.customer_name,a.product_name,a.order_number  " +
                        $"FROM orders a " +
                        $"LEFT JOIN order_detail b " +
                        $"ON a.id = b.order_id " +
                        $"WHERE a.status = '{status}';";

                    orders = new DataTable();
                    orders.Columns.Add("Id");
                    orders.Columns.Add("LicensePlate");
                    orders.Columns.Add("DateTime");
                    orders.Columns.Add("Weight");
                    orders.Columns.Add("Customer");
                    orders.Columns.Add("Product");
                    orders.Columns.Add("OrderNumber");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Rows.Add(
                                reader.IsDBNull(0) ? null : reader.GetString(0),
                                reader.IsDBNull(1) ? null : reader.GetString(1),
                                reader.IsDBNull(2) ? null : reader.GetString(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3),
                                reader.IsDBNull(4) ? null : reader.GetString(4),
                                reader.IsDBNull(5) ? null : reader.GetString(5),
                                reader.IsDBNull(6) ? null : reader.GetString(6)
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return null;
            }
            return orders;
        }

        // อัปเดตข้อมูลตาม Id
        public bool UpdateById(OrderModels order)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE orders 
                        SET license_plate = @license_plate, 
                            product_name = @product_name, 
                            customer_name = @customer_name, 
                            product_code = @product_code, 
                            customer_code = @customer_code, 
                            note = @note, 
                            net_weight = @net_weight, 
                            status = @status 
                        WHERE id = @Id;
                    ";

                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@license_plate", order.LicensePlate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@product_name", order.ProductName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@customer_name", order.CustomerName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@product_code", order.ProductCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@customer_code", order.CustomerCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@note", order.Note ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@net_weight", order.NetWeight);
                    command.Parameters.AddWithValue("@status", order.Status ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
            return true;
        }

        // ลบข้อมูลตาม Id
        public bool DeleteById(int id)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM orders WHERE id = @Id;";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
            return true;
        }

        // เช็คว่ามีทะเบียนรถที่กำลัง Process อยู่หรือไม่ โดยค้นหาจากทะเบียนรถ
        public DataTable CheckLicensePlateInProcess(string license_plate)
        {
            DataTable orders;
            try
            {
                orders = new DataTable();
                orders.Columns.Add("Id");
                orders.Columns.Add("LicensePlate");
                orders.Columns.Add("DateTime");
                orders.Columns.Add("WeightIn");
                orders.Columns.Add("Customer");
                orders.Columns.Add("Product");
                orders.Columns.Add("OrderNumber");
                orders.Columns.Add("ProductCode");
                orders.Columns.Add("CustomerCode");


                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = $"SELECT a.id, " +
                        $"a.license_plate, " +
                        $"b.datetimes , " +
                        $"b.weight, " +
                        $"a.customer_name, " +
                        $"a.product_name, " +
                        $"a.order_number, " +
                        $"a.product_code, " +
                        $"a.customer_code " +
                       $"FROM orders a " +
                       $"LEFT JOIN order_detail b " +
                       $"ON a.id = b.order_id " +
                       $"WHERE a.status = 'Process' and a.license_plate = @license_plate;";
                    command.Parameters.AddWithValue("@license_plate", license_plate);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Rows.Add(
                                reader.IsDBNull(0) ? null : reader.GetString(0),
                                reader.IsDBNull(1) ? null : reader.GetString(1),
                                reader.IsDBNull(2) ? null : reader.GetString(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3),
                                reader.IsDBNull(4) ? null : reader.GetString(4),
                                reader.IsDBNull(5) ? null : reader.GetString(5),
                                reader.IsDBNull(6) ? null : reader.GetString(6),
                                reader.IsDBNull(7) ? null : reader.GetString(7),
                                reader.IsDBNull(8) ? null : reader.GetString(8)


                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return null; // ในกรณีเกิดข้อผิดพลาด ให้ถือว่าไม่มีทะเบียนรถที่กำลัง Process อยู่
            }
            return orders;

        }
    }

}