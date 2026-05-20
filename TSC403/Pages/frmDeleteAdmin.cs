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

namespace TSC403.Pages
{
    public partial class frmDeleteAdmin : Form
    {
        public frmDeleteAdmin()
        {
            InitializeComponent();

            // define form size
            this.ClientSize = new Size(393, 476);

            // define groupbox password to center screen
            int x = (this.ClientSize.Width - gbPassword.Width) / 2;
            int y = (this.ClientSize.Height - gbPassword.Height) / 2;
            gbPassword.Location = new Point(x, y);

            // define groupbox information to center screen
            int x2 = (this.ClientSize.Width - gbInformation.Width) / 2;
            int y2 = (this.ClientSize.Height - gbInformation.Height) / 2;
            gbInformation.Location = new Point(x2, y2);

        }

        private void frmDeleteAdmin_Load(object sender, EventArgs e)
        {
            // define autocomplete to cbbLicensePlate
            OrdersDb ordersDb = new OrdersDb();
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            List<string> licensePlates = ordersDb.GetAllLicensePlate();
            if(licensePlates == null)
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการดึงข้อมูล  \nError : " + ordersDb.Err,"เกิดข้อผิดพลาด",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if(licensePlates.Count > 0)
            {
                // loop to add license plate to autocomplete
                foreach(string licensePlate in licensePlates)
                {
                    autoComplete.Add(licensePlate);
                }

                cbbLicensePlate.AutoCompleteCustomSource = autoComplete;
                cbbLicensePlate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbLicensePlate.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtPassword.Text == "8715")
                {
                    gbPassword.Visible = false;
                    gbInformation.Visible = true;
                }
                else
                {
                    MessageBox.Show("รหัสผ่านไม่ถูกต้องกรุณาลองใหม่อีกครั้ง","รหัสผ่านผิด",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtPassword.Clear();
                }
            }
        }

        private void deleteOrder(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender  as Button;
                OrdersDb ordersDb = new OrdersDb();
                switch (btn.Tag)
                {
                    case "LICENSE_PLATE":
                        if (rdbAllLicensePlate.Checked) // user want to delete all order with license plate
                        {
                            // create message box to confirm delete all order with license plate
                            DialogResult result = MessageBox.Show("คุณต้องการลบข้อมูลทั้งหมดที่มีทะเบียนรถทั้งหมดที่ค้างชั่งหรือไม่ ", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if(result == DialogResult.Yes)
                            {
                                // update status car is process
                                if (!ordersDb.UpdateCarProcesssToCancel())
                                {
                                    MessageBox.Show("เกิดข้อผิดผลาดในการลบข้อมูล  \nError : " + ordersDb.Err, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }                  
                            }
                        }

                        if (rdbLicenseKeyIn.Checked)
                        {
                            if(cbbLicensePlate.Text == "")
                            {
                                MessageBox.Show("กรุณาเลือกทะเบียนรถที่ต้องการลบข้อมูล", "กรุณาเลือกทะเบียนรถ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // create message box to confirm delete all order with license plate
                            DialogResult result = MessageBox.Show("คุณต้องการลบข้อมูลทั้งหมดที่มีทะเบียนรถ " + cbbLicensePlate.Text + " ที่ค้างชั่งหรือไม่ ", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if(result == DialogResult.Yes) {                                
                                // update status car is process by license plate
                                if (!ordersDb.UpdateCarProcesssToCancelByLicensePlate(cbbLicensePlate.Text))
                                {
                                    MessageBox.Show("เกิดข้อผิดผลาดในการลบข้อมูล  \nError : " + ordersDb.Err, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        MessageBox.Show("ลบข้อมูลสำเร็จ", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbbLicensePlate.Text = "";

                        break;
                    case "ORDERNUMBER":
                        if(txtOrderNumber.Text == "")
                        {
                            MessageBox.Show("กรุณาใส่หมายเลขคำสั่งซื้อที่ต้องการลบข้อมูล", "กรุณาใส่หมายเลขคำสั่งซื้อ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // create message box to confirm delete order by order number
                        DialogResult result2 = MessageBox.Show("คุณต้องการลบเลขที่ชั่ง " + txtOrderNumber.Text + " ที่ค้างชั่งหรือไม่ ", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(result2 == DialogResult.Yes)
                        {
                          
                            // try to check order number exist in database
                            OrderModels order = ordersDb.SelectByorder_number(txtOrderNumber.Text);
                            if (order != null)
                            {
                                // define new models
                                order.Status = "Cancel";

                                // exist in database and update status to Cancel
                                if (!ordersDb.UpdateById(order))
                                {
                                    MessageBox.Show("เกิดข้อผิดผลาดในการลบข้อมูล  \nError : " + ordersDb.Err, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                MessageBox.Show("ลบข้อมูลสำเร็จ", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtOrderNumber.Text = "";
                            }
                        }
                        break;
                    case "DATE":
                        // เอาวันที่เริ่มต้อน และ วันที่สินค้าไปหาในฐานข้อมูลก่อนว่ามีรถค้างชั่งหรือไม่
                        string dateStart = dtpDateStart.Value.ToString("yyyy-MM-dd",System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
                        string dateEnd = dtpDateStop.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
                        if (ordersDb.GetCarProcessByDateStartAndDateEnd(dateStart, dateEnd))
                        {
                            // exist car process in database and create message box to confirm delete order by date start and date end
                            DialogResult result = MessageBox.Show("คุณต้องการลบข้อมูลทั้งหมดที่มีวันที่เริ่มต้น " + dateStart + " และ วันที่สิ้นสุด " + dateEnd + " ที่ค้างชั่งหรือไม่ ", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if(result == DialogResult.Yes)
                            {
                                // update status to cancel by date start and date end
                                if (!ordersDb.UpdateCarProcessByDateStartAndDateEnd(dateStart, dateEnd))
                                {
                                    MessageBox.Show("เกิดข้อผิดผลาดในการลบข้อมูล  \nError : " + ordersDb.Err, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                MessageBox.Show("ลบข้อมูลสำเร็จ", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }else
                            MessageBox.Show("ไม่พบข้อมูลที่มีวันที่เริ่มต้น " + dateStart + " และ วันที่สิ้นสุด " + dateEnd + " ที่ค้างชั่ง", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        

                        break;
                }
            }
            catch
            {

                
            }
        }
    }
}
