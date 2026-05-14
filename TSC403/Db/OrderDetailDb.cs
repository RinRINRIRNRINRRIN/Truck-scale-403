using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC403.Models;

namespace TSC403.Db
{
    internal class OrderDetailDb
    {
        public string Err { get; set; }

        // เพิ่มข้อมูลรายละเอียด Order ใหม่
        public bool AddNew(OrderDetailModels detail)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO order_detail (order_id, weight_type, weight, datetimes) 
                        VALUES (@OrderId, @WeightType, @Weight, @Datetimes);
                    ";

                    command.Parameters.AddWithValue("@OrderId", detail.OrderId);
                    command.Parameters.AddWithValue("@WeightType", detail.WeightType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Weight", detail.Weight);
                    command.Parameters.AddWithValue("@Datetimes", detail.Datetimes ?? (object)DBNull.Value);

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

        // ดึงข้อมูลตาม Id
        public OrderDetailModels SelectById(int id)
        {
            OrderDetailModels detail = null;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, order_id, weight_type, weight, datetimes FROM order_detail WHERE id = @Id;";
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            detail = new OrderDetailModels
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
                                WeightType = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Weight = reader.GetInt32(3),
                                Datetimes = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return detail;
        }

        // ดึงข้อมูลทั้งหมด
        public List<OrderDetailModels> SelectAll()
        {
            var details = new List<OrderDetailModels>();
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, order_id, weight_type, weight, datetimes FROM order_detail;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            details.Add(new OrderDetailModels
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
                                WeightType = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Weight = reader.GetInt32(3),
                                Datetimes = reader.IsDBNull(4) ? null : reader.GetString(4)
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
            return details;
        }

        // อัปเดตข้อมูลตาม Id
        public bool UpdateById(OrderDetailModels detail)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE order_detail 
                        SET order_id = @OrderId, 
                            weight_type = @WeightType, 
                            weight = @Weight, 
                            datetimes = @Datetimes 
                        WHERE id = @Id;
                    ";

                    command.Parameters.AddWithValue("@Id", detail.Id);
                    command.Parameters.AddWithValue("@OrderId", detail.OrderId);
                    command.Parameters.AddWithValue("@WeightType", detail.WeightType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Weight", detail.Weight);
                    command.Parameters.AddWithValue("@Datetimes", detail.Datetimes ?? (object)DBNull.Value);

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
                    command.CommandText = "DELETE FROM order_detail WHERE id = @Id;";
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
    }
}
