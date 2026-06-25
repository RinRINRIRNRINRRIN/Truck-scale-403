using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Db;
using TSC403.Functions;
using TSC403.Models;
using TSC403.Reports;

namespace TSC403.Pages
{
    public partial class frmWeight : Form
    {
        public frmWeight()
        {
            InitializeComponent();

            // ตั้งค่า Timer สำหรับตรวจจับน้ำหนักนิ่ง
            stableTimer = new Timer();
            stableTimer.Interval = 1000; // ทำงานทุกๆ 1 วินาที
            stableTimer.Tick += StableTimer_Tick;

            // --- (เพิ่ม) ตั้งค่า Timer สำหรับเช็คสัญญาณขาดหาย 3 วินาที ---
            timeoutTimer = new Timer();
            timeoutTimer.Interval = 3000; // 3000 ms = 3 วินาที
            timeoutTimer.Tick += TimeoutTimer_Tick;
        }

        private string WeightState { get; set; } = "FIRST";
        private int OrderId { get; set; } = 0;

        private int WeightIn { get; set; } = 0;

        private int lastWeight = -1;       // ใช้เก็บน้ำหนักล่าสุดเพื่อเปรียบเทียบ
        private int stableTicks = 0;       // ใช้สำหรับนับรอบวินาทีที่น้ำหนักนิ่ง

        private Timer stableTimer;         // Timer สำหรับตรวจเช็คน้ำหนักบน UI Thread
        private Timer timeoutTimer;        // (เพิ่ม) ตัวใหม่สำหรับดักสัญญาณหาย 3 วินาที
        void clearForm()
        {
            foreach (ComboBox item in panel1.Controls.OfType<ComboBox>())
            {
                item.Items.Clear();
                item.Text = "";
            }

            txtLicensePlate.Clear();
            WeightState = "FIRST";
            txtLicensePlate.Enabled = true;
            OrderId = 0;
            WeightIn = 0;

            // --- เพิ่มตรงนี้เพื่อรีเซ็ตระบบน้ำหนักนิ่ง ---
            lastWeight = -1;
            stableTicks = 0;
            stableTimer.Stop();
            btnSave.Enabled = false; // ปิดปุ่มบันทึกไว้ก่อนเสมอจนกว่าจะนิ่ง

            addProductAndCustomerToCombobox();
        }


        void addProductAndCustomerToCombobox()
        {
            ProductDb productDb = new ProductDb();
            cbbProduct.Items.Clear();
            cbbCodeProduct.Items.Clear();

            // ดึงข้อมูลสินค้าทั้งหมดจากฐานข้อมูล
            List<ProductModels> products = productDb.SelectAll();
            if (products != null)
            {
                // แยกกล่องเก็บ AutoComplete ของชื่อสินค้า และ รหัสสินค้า
                AutoCompleteStringCollection productNames = new AutoCompleteStringCollection();
                AutoCompleteStringCollection productCodes = new AutoCompleteStringCollection();

                foreach (ProductModels product in products)
                {
                    // 1. เพิ่มเข้า Items (เพื่อให้กดเลือกจาก Dropdown ได้)
                    cbbProduct.Items.Add(product.ProductName);
                    cbbCodeProduct.Items.Add(product.ProductCode);

                    // 2. เพิ่มเข้ากล่อง AutoComplete
                    productNames.Add(product.ProductName);
                    productCodes.Add(product.ProductCode);
                }

                // กำหนดค่า AutoComplete ให้ฝั่งสินค้า
                cbbProduct.AutoCompleteCustomSource = productNames;
                cbbProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;

                cbbCodeProduct.AutoCompleteCustomSource = productCodes;
                cbbCodeProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbCodeProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            // -------------------------------------------------------------

            // ดึงข้อมูลบริษัทจากตาราง company มาแสดงใน combobox
            CustomerDb customerDb = new CustomerDb();
            cbbCustomer.Items.Clear();
            cbbCodeCustomer.Items.Clear();

            List<CustomerModels> customers = customerDb.SelectAll();
            if (customers != null)
            {
                // แยกกล่องเก็บ AutoComplete ของชื่อลูกค้า และ รหัสลูกค้า
                AutoCompleteStringCollection customerNames = new AutoCompleteStringCollection();
                AutoCompleteStringCollection customerCodes = new AutoCompleteStringCollection();

                foreach (CustomerModels customer in customers)
                {
                    // 1. เพิ่มเข้า Items
                    cbbCustomer.Items.Add(customer.CustomerName);
                    cbbCodeCustomer.Items.Add(customer.CustomerCode);

                    // 2. เพิ่มเข้ากล่อง AutoComplete
                    customerNames.Add(customer.CustomerName);
                    customerCodes.Add(customer.CustomerCode);
                }

                // กำหนดค่า AutoComplete ให้ฝั่งลูกค้า (เปลี่ยนจาก autoComplete เดิม เป็นตัวใหม่ที่แยกแล้ว)
                cbbCustomer.AutoCompleteCustomSource = customerNames;
                cbbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;

                cbbCodeCustomer.AutoCompleteCustomSource = customerCodes;
                cbbCodeCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbCodeCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

        }

        bool saveFirstWeight(int weight)
        {
            OrdersDb ordersDb = new OrdersDb();
            OrderModels orderModels = new OrderModels();
            try
            {
                // generate orderNumber
                string orderNumber = ordersDb.Generateorder_number();
                if (orderNumber == null)
                {
                    MessageBox.Show("เกิดข้อผิดผลาดในการ Generate เลขที่ชั่ง \nError : " + ordersDb.Err, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // กำหนดค่า order model
                orderModels = new OrderModels
                {
                    CustomerName = cbbCustomer.Text.Trim(),
                    CustomerCode = cbbCodeCustomer.Text.Trim(),
                    LicensePlate = txtLicensePlate.Text.Trim(),
                    OrderNumber = orderNumber,
                    ProductName = cbbProduct.Text.Trim(),
                    ProductCode = cbbCodeProduct.Text.Trim(),
                    Note = "",
                    Status = "Process",
                    NetWeight = 0
                };

                // บันทึกข้อมูล orders
                if (!ordersDb.AddNew(orderModels))
                {
                    MessageBox.Show("เกิดข้อผิดผลาดในการบันทึกข้อมูลหลัง orders \nError : " + ordersDb.Err, "ข้อผิดผลาดในการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // ดึงค่า id ของ orders ที่เพิ่มไปล่าสุดs
                orderModels = ordersDb.SelectByorder_number(orderNumber);

                // กำหนดค่าที่ order_detail_model
                OrderDetailModels orderDetailModels = new OrderDetailModels
                {
                    Datetimes = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")),
                    OrderId = orderModels.Id,
                    WeightType = WeightState,
                    Weight = weight
                };

                // บันทึกข้อมูลลอง order_detail
                OrderDetailDb orderDetailDb = new OrderDetailDb();
                if (!orderDetailDb.AddNew(orderDetailModels))
                {

                    MessageBox.Show("เกิดข้อผิดผลาดในการบันทึกข้อมูลรอง order_detail \nError :" + orderDetailDb.Err, "เกิดข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                clearForm();
            }
            catch (Exception ex)
            {
                // ลบข้อมูลหลัง
                ordersDb.DeleteById(orderModels.Id);
                MessageBox.Show("เกิดข้อผิดผลาดในการบันทึกข้อมูลหลัง  \nError : " + ex.Message, "ข้อผิดผลาดในการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        bool saveSecondWeight(int weight)
        {
            try
            {
                // กำหนดคา order_detail
                OrderDetailModels orderDetailModels = new OrderDetailModels
                {
                    OrderId = OrderId,
                    Weight = weight,
                    Datetimes = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")),
                    WeightType = WeightState,
                };

                // บันทึกข้อมูลไปที่ order_detail
                OrderDetailDb orderDetailDb = new OrderDetailDb();
                if (!orderDetailDb.AddNew(orderDetailModels))
                {
                    MessageBox.Show("เกิดข้อผิดผลาดในการบันทึกข้อมูลรอง order_detail \nError : " + orderDetailDb.Err, "ข้อผิดผลาดในการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // คำนวนน้ำหนักnet weight
                int netWeight = Math.Abs(WeightIn - weight);
                // กำหนดค่า orderModel สำหรับอัพเดทข้อมูล
                OrderModels orderModels = new OrderModels
                {
                    Id = OrderId,
                    LicensePlate = txtLicensePlate.Text,
                    CustomerCode = cbbCodeCustomer.Text.Trim(),
                    CustomerName = cbbCustomer.Text.Trim(),
                    ProductCode = cbbCodeProduct.Text.Trim(),
                    ProductName = cbbProduct.Text.Trim(),
                    NetWeight = netWeight,
                    Status = "Success"
                };
                // อัพเดทข้อมูลที่ orders 
                OrdersDb ordersDb = new OrdersDb();
                ordersDb.UpdateById(orderModels);

                // print ticket
                frmShowReport frmShowReport = new frmShowReport(OrderId, "TICKET", null);
                this.Hide();
                frmShowReport.ShowDialog();
                this.Show();

                clearForm();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        private void StableTimer_Tick(object sender, EventArgs e)
        {
            int currentWeight;
            if (int.TryParse(lblWeight.Text, out currentWeight))
            {
                // 1. ตรวจสอบว่า น้ำหนักปัจจุบัน เท่ากับ น้ำหนักในวินาทีที่แล้ว หรือไม่
                //if (currentWeight == lastWeight && currentWeight >= 1000)
                //{
                //    stableTicks++; // ถ้าเท่ากัน บวกรอบความนิ่งเพิ่มขึ้น 1 วิ
                //}
                //else
                //{
                //    stableTicks = 0; // ถ้าไม่เท่ากัน (น้ำหนักแกว่ง) ให้รีเซ็ตเริ่มนับ 0 ใหม่ทันที
                //    btnSave.Enabled = false; // ปิดปุ่มบันทึกซะถ้าน้ำหนักสวิงกลับมาแกว่งอีก
                //}
                if (currentWeight == lastWeight)
                {
                    stableTicks++; // ถ้าเท่ากัน บวกรอบความนิ่งเพิ่มขึ้น 1 วิ
                }
                else
                {
                    stableTicks = 0; // ถ้าไม่เท่ากัน (น้ำหนักแกว่ง) ให้รีเซ็ตเริ่มนับ 0 ใหม่ทันที
                    btnSave.Enabled = false; // ปิดปุ่มบันทึกซะถ้าน้ำหนักสวิงกลับมาแกว่งอีก
                }

                // 2. เก็บน้ำหนักรอบนี้ไว้เปรียบเทียบในวินาทีถัดไป
                lastWeight = currentWeight;

                // 3. ถ้านิ่งติดต่อกันครบ 4 วินาที (stableTicks = 4)
                if (stableTicks >= 4)
                {
                    btnSave.Enabled = true; // เปิดให้ปุ่มบันทึกกดได้!

                    // แถม: คุณสามารถย้อมสีป้ายlblWeight หรือเปลี่ยนสีปุ่มให้คนชั่งรู้ได้ด้วยนะ เช่น
                    // btnSave.BackColor = Color.Green; 
                }
            }
            else
            {
                // ถ้าดึงค่าน้ำหนักไม่ได้/เกิด Error ให้รีเซ็ตระบบ
                stableTicks = 0;
                btnSave.Enabled = false;
            }
        }


        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string weight = IndicatorScale.getWeight(sender);
                int weightInt;
                if (int.TryParse(weight, out weightInt))
                {
                    // เช็คว่าฟอร์มปิดไปแล้วหรือกำลังปิดอยู่หรือไม่ ถ้าใช่...ห้ามInvoke เด็ดขาด!
                    if (this.IsDisposed || this.Disposing) return;

                    // Update the label on the UI thread
                    this.Invoke(new Action(() =>
                    {
                        timeoutTimer.Stop();
                        timeoutTimer.Start();

                        lblWeight.Text = weightInt.ToString();
                        // ถ้าน้ำหนักมากกว่า 1000 Kg (ตามเงื่อนไขเดิมของคุณ) ให้เปิดระบบตรวจจับความนิ่ง
                        if (weightInt >= SystemModels.CapacityScale)
                        {
                            // ถ้ารถขับลงไปแล้ว หรือน้ำหนักน้อยกว่า 1000 ให้ปิดและเคลียร์ค่า
                            stableTimer.Stop();
                            stableTicks = 0;
                            lastWeight = -1;
                            btnSave.Enabled = false;

                        }
                        else
                        {
                            if (!stableTimer.Enabled)
                            {
                                stableTimer.Start(); // เริ่มให้ Timer ทำงานนับวิ
                            }
                        }

                    }));
                }
                else
                {
                    // show error message on the UI thread
                    return;
                }
            }
            catch
            {

            }

        }

        private void frmWeight_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = ConfigurationManager.AppSettings["SCALE_PORT"];
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการเปิดพอร์ตเครื่องชั่ง \nError : " + ex.Message, "ข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            addProductAndCustomerToCombobox();


            timeoutTimer.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ถ้าน้ำหนักขึ้น Error ห้ามบันทึก
            if (lblWeight.Text == "ERROR")
            {
                MessageBox.Show("ไม่พบน้ำหนักกรุณาตรวจสอบน้ำหนัก", "ไม่พบน้ำหนัก", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // เช็คข้อมูลที่กรอกเข้ามาห้ามว่างก่อนบันทึก
            if (txtLicensePlate.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลทะเบียนรถก่อนบันทึก", "ข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // snap น้ำหนักปัจจุบัน
            int weightInt;
            if (!int.TryParse(lblWeight.Text, out weightInt))
            {
                return;
            }

            //// เช็คน้ำหนกต้องมากกว่า 1000 Kg
            //if (weightInt < 1000)
            //{
            //    MessageBox.Show("น้ำหนักต้องมากกว่า 1000 Kg เป็นต้นไป", "น้ำหนักไม่ถึงตามที่กำหนด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // เช็คว่าเป็น first weight or second weight
            switch (WeightState)
            {
                case "FIRST":
                    if (!saveFirstWeight(weightInt))
                        return;
                    break;
                case "SECOND":
                    if (!saveSecondWeight(weightInt))
                        return;
                    break;
            }

            MessageBox.Show("บันทึกรายการชั่งสำเร็จ", "บันทึกสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearForm();
        }

        private void btnWeightOut_Click(object sender, EventArgs e)
        {
            // แสดงรายการค้างชั่ว
            frmWeightOutList frmWeightOutList = new frmWeightOutList();
            frmWeightOutList.ShowDialog();
            OrderId = frmWeightOutList.OrderId;
            WeightIn = frmWeightOutList.WeightIn;
            if (OrderId == 0)
            {
                MessageBox.Show("ไม่พบข้อมูลที่ต้องการชั่งออก", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // เอา order_id หาและกำหนดค่าที่ orderModel
            OrdersDb ordersDb = new OrdersDb();
            OrderModels orderModels = ordersDb.SelectById(frmWeightOutList.OrderId);
            if (orderModels != null)
            {
                // กำหนดค่า WeightState = SECOND
                WeightState = "SECOND";

                // ดึงค่า model มาแสดงที่หน้าจอ
                txtLicensePlate.Text = orderModels.LicensePlate;
                txtLicensePlate.Enabled = false;
                cbbCustomer.Text = orderModels.CustomerName;
                cbbProduct.Text = orderModels.ProductName;
                cbbCodeCustomer.Text = orderModels.CustomerCode;
                cbbCodeProduct.Text = orderModels.ProductCode;
            }
        }

        private void GetDetailOfCBB(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            ProductDb productDb = new ProductDb();
            CustomerDb customerDb = new CustomerDb();
            ProductModels productModels = new ProductModels();
            CustomerModels customerModels = new CustomerModels();
            switch (cbb.Tag)
            {
                case "PRD_CODE":
                    productModels = productDb.SelectByCode(cbb.Text);
                    cbbProduct.Text = productModels.ProductName;
                    break;
                case "PRD_NAME":
                    productModels = productDb.SelectByName(cbb.Text);
                    cbbCodeProduct.Text = productModels.ProductCode;
                    break;
                case "CUS_CODE":
                    customerModels = customerDb.SelectByCode(cbb.Text);
                    cbbCustomer.Text = customerModels.CustomerName;
                    break;
                case "CUS_NAME":
                    customerModels = customerDb.SelectByName(cbb.Text);
                    cbbCodeCustomer.Text = customerModels.CustomerCode;
                    break;
            }
        }

        private void frmWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            // สั่งหยุดทำงานและทำลายล้าง Timer ทั้งสองตัว
            if (stableTimer != null) { stableTimer.Stop(); stableTimer.Dispose(); }
            if (timeoutTimer != null) { timeoutTimer.Stop(); timeoutTimer.Dispose(); }
            // 1. ยกเลิกการผูก Event ทันที เพื่อไม่ให้มี DataReceived รอบใหม่ทำงานขึ้นมาอีก
            serialPort1.DataReceived -= serialPort1_DataReceived;

            // 2. ใช้ Task.Run สั่ง Close พอร์ตบน Thread อื่น เพื่อไม่ให้มาดึง UI Thread จนเกิด Deadlock
            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    if (serialPort1 != null && serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                        serialPort1.Dispose();
                    }
                }
                catch { /* ป้องกัน Error จังหวะตัดการเชื่อมต่อ */ }
            });
        }

        private void txtLicensePlate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // เอาทะเบียนรถไปหาใน car process ว่ามีรถค้างอยู่ไหม ถ้ามีให้แสดงรายการรถคันนั้น
                OrdersDb ordersDb = new OrdersDb();

                DataTable tb = ordersDb.CheckLicensePlateInProcess(txtLicensePlate.Text.Trim());
                if (tb.Rows.Count > 0)
                {
                    WeightState = "SECOND";
                    txtLicensePlate.Enabled = false;
                    btnWeightOut.Visible = false;
                    foreach (DataRow row in tb.Rows)
                    {
                        OrderId = int.Parse(row["Id"].ToString());
                        cbbCodeCustomer.Text = row["CustomerCode"].ToString();
                        cbbCustomer.Text = row["Customer"].ToString();
                        cbbCodeProduct.Text = row["ProductCode"].ToString();
                        cbbProduct.Text = row["Product"].ToString();
                        WeightIn = int.Parse(row["WeightIn"].ToString());
                    }
                }
            }
        }

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            // เนื่องจาก Timer ตัวนี้รันบน UI Thread อยู่แล้ว สามารถสั่งเปลี่ยนค่า Control ได้โดยตรงเลยครับ
            lblWeight.Text = "ERROR";
            lblWeight.ForeColor = Color.Red; // เปลี่ยนตัวหนังสือเป็นสีแดงเตือนผู้ใช้งาน

            // หยุดระบบตรวจจับความนิ่งทันที เพราะไม่มีข้อมูลมาให้เช็คแล้ว
            stableTimer.Stop();
            stableTicks = 0;
            lastWeight = -1;
        }
    }
}
