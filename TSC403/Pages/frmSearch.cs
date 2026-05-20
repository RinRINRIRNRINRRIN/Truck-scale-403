using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Db;
using TSC403.Models;
using TSC403.Reports;

namespace TSC403.Pages
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void SelectQuery(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                switch (checkBox.Tag)
                {
                    case "LICENSE_PLATE":
                        if (checkBox.Checked)
                            gbLicensePlate.Enabled = true;
                        else
                            gbLicensePlate.Enabled = false;
                        break;
                    case "DATE":
                        if (checkBox.Checked)
                            gbDate.Enabled = true;
                        else
                            gbDate.Enabled = false;
                        break;
                    case "CUSTOMER":
                        if (checkBox.Checked)
                            gbCustomer.Enabled = true;
                        else
                            gbCustomer.Enabled = false;
                        break;
                    case "PRODUCT":
                        if (checkBox.Checked)
                            gbProduct.Enabled = true;
                        else
                            gbProduct.Enabled = false;
                        break;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 1. ดึงค่าและเช็คเงื่อนไขตามการติ๊ก Checkbox (ถ้าไม่ติ๊กให้เป็น null)
            string license_plate = cbLicensePlate.Checked ? txtLicensePlate.Text.Trim() : null;
            string customer = cbCompany.Checked ? txtCustomer.Text.Trim() : null;
            string product = cbProduct.Checked ? txtProduct.Text.Trim() : null;

            // สำหรับวันที่ ถ้าไม่ติ๊กค้นหาด้วยวันที่ ก็ส่งเป็น null ไปทั้งคู่
            string dateIn = null;
            string dateOut = null;
            if (cbDate.Checked)
            {
                // แปลงฟอร์แมตวันที่ให้เข้ากับ SQLite (แนะนำฟอร์แมต yyyy-MM-dd)
                dateIn = dtpStart.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
                dateOut = dtpEnd.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
            }

            // 2. ส่งค่าทั้งหมดไปที่ฟังก์ชัน (โครงสร้างเดิม ไม่ต้องแก้ไข Class)
            OrdersDb orders = new OrdersDb();
            DataTable dtResult = orders.SelectByQuery(dateIn, dateOut, customer, product, license_plate, "Success");

            // 3. นำผลลัพธ์ไปแสดงผลต่อ
            if (dtResult != null)
            {
                // เช็คว่ามีข้อมูลหรือไม่ ถ้าไม่มีให้แจ้งเตือน
                if (dtResult.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ค้นหา", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // ส่งค่า data table ไปที่หน้า frmHistory เพื่อแสดงผล
                frmHistory historyForm = new frmHistory(dtResult);
                this.Hide();
                historyForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + orders.Err);
            }

        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            // กำหนดค่า autocomplete ให้กับ Combobox ต่าง ๆ เพื่อความสะดวกในการค้นหา
            AutoCompleteStringCollection productName = new AutoCompleteStringCollection();
            ProductDb productDb = new ProductDb();
            List<ProductModels> products = productDb.SelectAll();
            if (products != null)
            {
                foreach (ProductModels item in products)
                {
                    // กำหนดค่าให้กับ autocomplete 
                    productName.Add(item.ProductName);
                }

                txtProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtProduct.AutoCompleteCustomSource = productName;
                txtProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


                // loop เช็คข้อมูลใน collection productName ว่ามีข้อมูลหรือไม่ ถ้าไม่มีให้แจ้งเตือน
                foreach (string item in productName)
                {
                    Console.WriteLine(item);
                }
            }

            // กำหนดค่า autocomplete ให้กับ Combobox ลูกค้า
            AutoCompleteStringCollection customerName = new AutoCompleteStringCollection();
            CustomerDb customerDb = new CustomerDb();
            List<CustomerModels> customers = customerDb.SelectAll();
            if (customers != null)
            {
                foreach (var item in customers)
                {
                    // กำหนดค่าให้กับ autocomplete 
                    customerName.Add(item.CustomerName);
                }
                txtCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomer.AutoCompleteCustomSource = customerName;
            }

            // กำหนดค่า autocomplete ให้กับ Combobox ป้ายทะเบียน 
            AutoCompleteStringCollection licensePlates = new AutoCompleteStringCollection();
            OrdersDb ordersDb = new OrdersDb();
            List<string> plates = ordersDb.GetAllLicensePlate();
            if(plates != null)
            {
                foreach (var item in plates)
                {
                    // กำหนดค่าให้กับ autocomplete 
                    licensePlates.Add(item);
                }
                txtLicensePlate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtLicensePlate.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtLicensePlate.AutoCompleteCustomSource = licensePlates;
            }
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                this.Close();
        }
    }
}
