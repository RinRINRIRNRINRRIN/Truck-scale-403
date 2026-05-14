using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using TSC403.Models;

namespace TSC403.Db
{
    internal class ProductDb
    {

        public string Err { get; set; }

        // เพิ่มข้อมูลสินค้าใหม่
        public bool AddNew(ProductModels product)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO products (product_code, product_name) 
                        VALUES (@ProductCode, @ProductName);
                    ";

                    command.Parameters.AddWithValue("@ProductCode", product.ProductCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName ?? (object)DBNull.Value);

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

        // ดึงข้อมูลตาม Product Code
        public ProductModels SelectByCode(string productCode)
        {
            ProductModels product = null;
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT product_code, product_name FROM products WHERE product_code = @ProductCode;";
                    command.Parameters.AddWithValue("@ProductCode", productCode);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new ProductModels
                            {
                                ProductCode = reader.IsDBNull(0) ? null : reader.GetString(0),
                                ProductName = reader.IsDBNull(1) ? null : reader.GetString(1)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
            return product;
        }

        // ดึงข้อมูลสินค้าทั้งหมด
        public List<ProductModels> SelectAll()
        {
            var products = new List<ProductModels>();
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT product_code, product_name FROM products;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new ProductModels
                            {
                                ProductCode = reader.IsDBNull(0) ? null : reader.GetString(0),
                                ProductName = reader.IsDBNull(1) ? null : reader.GetString(1)
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
            return products;
        }

        // อัปเดตข้อมูลสินค้า
        public bool UpdateByCode(ProductModels product)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE products 
                        SET product_name = @ProductName 
                        WHERE product_code = @ProductCode;
                    ";

                    command.Parameters.AddWithValue("@ProductCode", product.ProductCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName ?? (object)DBNull.Value);

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

        // ลบข้อมูลสินค้า
        public bool DeleteByCode(string productCode)
        {
            try
            {
                using (var connection = new SqliteConnection(DbContect.ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM products WHERE product_code = @ProductCode;";
                    command.Parameters.AddWithValue("@ProductCode", productCode);

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
