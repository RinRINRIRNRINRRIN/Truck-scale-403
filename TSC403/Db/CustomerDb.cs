using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC403.Models;

namespace TSC403.Db
{
    internal class CustomerDb
    {
        // สร้าง Property สำหรับเก็บค่า Error
        public string Err { get; set; }

        // เพิ่มข้อมูลใหม่
        public bool AddNew(CustomerModels customer)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO customers (customer_code, customer_name) 
                        VALUES (@CustomerCode, @CustomerName);
                    ";

                    command.Parameters.AddWithValue("@CustomerCode", customer.CustomerCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName ?? (object)DBNull.Value);

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

        // ดึงข้อมูลตาม Customer Code
        public CustomerModels SelectByCode(string customerCode)
        {
            CustomerModels customer = null;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT customer_code, customer_name FROM customers WHERE customer_code = @CustomerCode;";
                    command.Parameters.AddWithValue("@CustomerCode", customerCode);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new CustomerModels
                            {
                                CustomerCode = reader.IsDBNull(0) ? null : reader.GetString(0),
                                CustomerName = reader.IsDBNull(1) ? null : reader.GetString(1)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return customer;
        }

        public CustomerModels SelectByName(string customer_name)
        {
            CustomerModels customer = null;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT customer_code, customer_name FROM customers WHERE customer_name = @customer_name;";
                    command.Parameters.AddWithValue("@customer_name", customer_name);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new CustomerModels
                            {
                                CustomerCode = reader.IsDBNull(0) ? null : reader.GetString(0),
                                CustomerName = reader.IsDBNull(1) ? null : reader.GetString(1)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return customer;
        }

        // ดึงข้อมูลทั้งหมด
        public List<CustomerModels> SelectAll()
        {
            var customers = new List<CustomerModels>();
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT customer_code, customer_name FROM customers;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new CustomerModels
                            {
                                CustomerCode = reader.IsDBNull(0) ? null : reader.GetString(0),
                                CustomerName = reader.IsDBNull(1) ? null : reader.GetString(1)
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
            return customers;
        }

        // อัปเดตข้อมูลตาม Customer Code
        public bool UpdateByCode(CustomerModels customer)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE customers 
                        SET customer_name = @CustomerName 
                        WHERE customer_code = @CustomerCode;
                    ";

                    command.Parameters.AddWithValue("@CustomerCode", customer.CustomerCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName ?? (object)DBNull.Value);

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

        // ลบข้อมูลตาม Customer Code
        public bool DeleteByCode(string customerCode)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM customers WHERE customer_code = @CustomerCode;";
                    command.Parameters.AddWithValue("@CustomerCode", customerCode);

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
