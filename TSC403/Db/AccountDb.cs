using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC403.Models;

namespace TSC403.Db
{
    internal class AccountDb
    {
        // 1. สร้าง Property สำหรับเก็บค่า Error
        public string Err { get; set; }

        // เพิ่มข้อมูลใหม่
        public bool AddNew(AccountModels account)
        {

            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO accounts (first_name, username, password) 
                        VALUES (@FirstName, @Username, @Password);
                    ";

                    command.Parameters.AddWithValue("@FirstName", account.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Username", account.Username ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Password", account.Password ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
                // 2. เก็บข้อความ Error เมื่อเกิดปัญหา
            }
            return true;
        }

        // ดึงข้อมูลตาม Id
        public AccountModels SelectById(int id)
        {

            AccountModels account = null;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, first_name, username, password FROM accounts WHERE id = @Id;";
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new AccountModels
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Username = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Password = reader.IsDBNull(3) ? null : reader.GetString(3)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return account;
        }

        // ดึงข้อมูลทั้งหมด
        public List<AccountModels> SelectAll()
        {

            var accounts = new List<AccountModels>();
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT id, first_name, username, password FROM accounts;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(new AccountModels
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Username = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Password = reader.IsDBNull(3) ? null : reader.GetString(3)
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
            return accounts;
        }

        // อัปเดตข้อมูลตาม Id
        public bool UpdateById(AccountModels account)
        {

            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE accounts 
                        SET first_name = @FirstName, 
                            username = @Username, 
                            password = @Password 
                        WHERE id = @Id;
                    ";

                    command.Parameters.AddWithValue("@Id", account.Id);
                    command.Parameters.AddWithValue("@FirstName", account.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Username", account.Username ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Password", account.Password ?? (object)DBNull.Value);

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
                    command.CommandText = "DELETE FROM accounts WHERE id = @Id;";
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


