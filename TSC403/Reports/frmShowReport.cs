using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Db;
using TSC403.Models;
using CDS = CrystalDecisions.Shared;
namespace TSC403.Reports
{
    public partial class frmShowReport : Form
    {
        public frmShowReport(int orderId, string reportType, DataTable tbForTotalReportOrCarProcess)
        {
            InitializeComponent();

            _orderId = orderId;
            _reportType = reportType;
            _tbForTotalReport = tbForTotalReportOrCarProcess;
        }

        private readonly int _orderId = 0;
        private readonly string _reportType;
        private readonly DataTable _tbForTotalReport;

        void defineParameterTicket()
        {
            // ดึงค่า orders มากำหนดค่า orderModel
            OrdersDb ordersDb = new OrdersDb();
            OrderModels orderModels = ordersDb.SelectById(_orderId);

            rptTicket rptTicket = new rptTicket();
            string path = $"{Application.StartupPath}\\Reports\\rptTicket.rpt";
            rptTicket.Load(path);

            PrintDocument pd = new PrintDocument();
            System.Drawing.Printing.PaperSize found = pd.PrinterSettings.PaperSizes
            .Cast<System.Drawing.Printing.PaperSize>()
            .FirstOrDefault(p =>
                p.PaperName.Equals("TSC", StringComparison.OrdinalIgnoreCase));

            rptTicket.PrintOptions.PaperSize = (CDS.PaperSize)found.Kind;
            // กำหนดค่า parameter
            rptTicket.SetParameterValue("rptCompanyName", "บริษัท เมซเสอร์ (ประเทศไทย) จำกัด");
            rptTicket.SetParameterValue("rptAddress", "44/4 หมู่ 4 ตำบลหนองชุมพล อำเภอเขาย้อย จังหวัดเพชรบุรี 76140");
            rptTicket.SetParameterValue("rptPhone", "โทร");
            rptTicket.SetParameterValue("rptLicensePlate", orderModels.LicensePlate);
            rptTicket.SetParameterValue("rptProduct", orderModels.ProductName);
            rptTicket.SetParameterValue("rptCustomer", orderModels.CustomerName);
            rptTicket.SetParameterValue("rptOrderNumber", orderModels.OrderNumber);
            rptTicket.SetParameterValue("rptNetWeight", orderModels.NetWeight);
            // กำหนดค่า parameter detail
            OrderDetailDb orderDetailDb = new OrderDetailDb();
            List<OrderDetailModels> lists = orderDetailDb.SelectByOrderId(_orderId);

            // สร้าง CultureInfo สำหรับประเทศไทย
            CultureInfo thaiCulture = new CultureInfo("th-TH");

            foreach (OrderDetailModels orderDetail in lists)
            {
                DateTime date = DateTime.Parse(orderDetail.Datetimes);
                string thaiDateFormat = $"{date.ToString("d MMMM yyyy", thaiCulture)}";
                if (orderDetail.WeightType == "FIRST")
                {
                    rptTicket.SetParameterValue("rptDateIn", thaiDateFormat);
                    rptTicket.SetParameterValue("rptTimeIn", date.ToString("HH:mm:ss"));
                    rptTicket.SetParameterValue("rptWeightIn", orderDetail.Weight.ToString("#,###"));
                }
                if (orderDetail.WeightType == "SECOND")
                {

                    rptTicket.SetParameterValue("rptDateOut", thaiDateFormat);
                    rptTicket.SetParameterValue("rptTimeOut", date.ToString("HH:mm:ss"));
                    rptTicket.SetParameterValue("rptWeightOut", orderDetail.Weight.ToString("#,###"));
                }
            }

            crystalReportViewer1.EnableRefresh = false;
            crystalReportViewer1.ReportSource = rptTicket;
            crystalReportViewer1.Zoom(150);
        }

        void defineParameterDailyReport()
        {

            try
            {
                rptDailyReport rptDailyReport = new rptDailyReport();
                string path = $"{Application.StartupPath}\\Reports\\rptDailyReport.rpt";
                rptDailyReport.Load(path);

                int totalWeight = 0, totalList = 0;

                // กำหนดค่า data table ไปที่ data set สำหรับออกรายงาน
                DataSet1 dataSet1 = new DataSet1();
                // กำหนดค่า field ใน data set
                foreach (DataRow rw in _tbForTotalReport.Rows)
                {
                    string orderNumber = rw["OrderNumber"].ToString();
                    string licensePlate = rw["LicensePlate"].ToString();
                    DateTime datetimes = DateTime.Parse(rw["DateIn"].ToString());
                    int weightIn = int.Parse(rw["WeightIn"].ToString());
                    int weightOut = int.Parse(rw["WeightOut"].ToString());
                    int netWeight = int.Parse(rw["NetWeight"].ToString());
                    string customerName = rw["CustomerName"].ToString();
                    string productName = rw["ProductName"].ToString();

                    string dates = datetimes.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
                    string times = datetimes.ToString("HH:mm:ss");

                    dataSet1.Tables["DailyList"].Rows.Add(orderNumber, licensePlate, dates, times, netWeight.ToString("#,###"), weightIn.ToString("#,###"), weightOut.ToString("#,###"), customerName, productName);
                    totalList++;
                    totalWeight += netWeight;
                }

                // กำหนดค่า report paremter

                rptDailyReport.SetDataSource(dataSet1.Tables["DailyList"]);
                rptDailyReport.SetParameterValue("rptTotalWeight", totalWeight);
                rptDailyReport.SetParameterValue("rptTotalList", totalList);

                crystalReportViewer1.EnableRefresh = false;
                crystalReportViewer1.ReportSource = rptDailyReport;
                crystalReportViewer1.Zoom(150);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการกำหนดค่ารายงาน \nError : " + ex.Message, "ข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        void defineParameterTotalReport()
        {
            // ดึงรายการมาแสดงในรายงานรวม 
            try
            {
                rptTotalReport rptDailyReport = new rptTotalReport();
                string path = $"{Application.StartupPath}\\Reports\\rptTotalReport.rpt";
                rptDailyReport.Load(path);

                int totalWeight = 0, totalList = 0;

                // กำหนดค่า data table ไปที่ data set สำหรับออกรายงาน
                DataSet1 dataSet1 = new DataSet1();
                // กำหนดค่า field ใน data set
                foreach (DataRow rw in _tbForTotalReport.Rows)
                {
                    string orderNumber = rw["OrderNumber"].ToString();
                    string licensePlate = rw["LicensePlate"].ToString();
                    DateTime datetimes = DateTime.Parse(rw["DateIn"].ToString());
                    int weightIn = int.Parse(rw["WeightIn"].ToString());
                    int weightOut = int.Parse(rw["WeightOut"].ToString());
                    int netWeight = int.Parse(rw["NetWeight"].ToString());
                    string customerName = rw["CustomerName"].ToString();
                    string productName = rw["ProductName"].ToString();

                    string dates = datetimes.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
                    string times = datetimes.ToString("HH:mm:ss");

                    dataSet1.Tables["DailyList"].Rows.Add(orderNumber, licensePlate, dates, times, netWeight.ToString("#,###"), weightIn.ToString("#,###"), weightOut.ToString("#,###"), customerName, productName);
                    totalList++;
                    totalWeight += netWeight;
                }

                // กำหนดค่า report paremter

                rptDailyReport.SetDataSource(dataSet1.Tables["DailyList"]);
                rptDailyReport.SetParameterValue("rptTotalWeight", totalWeight);
                rptDailyReport.SetParameterValue("rptTotalList", totalList);

                crystalReportViewer1.EnableRefresh = false;
                crystalReportViewer1.ReportSource = rptDailyReport;
                crystalReportViewer1.Zoom(150);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการกำหนดค่ารายงาน \nError : " + ex.Message, "ข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }


        void defineCarProcess()
        {
            // ดึงรายการมาแสดงในรายงานรวม 
            try
            {
                rptCarProcess rptDailyReport = new rptCarProcess();
                string path = $"{Application.StartupPath}\\Reports\\rptCarProcess.rpt";
                rptDailyReport.Load(path);

                DataSet1 dataSet1 = new DataSet1();
                foreach (DataRow rw in _tbForTotalReport.Rows)
                {

                    string licensePlate = rw["LicensePlate"].ToString();
                    DateTime dateTime = DateTime.Parse(rw["DateTime"].ToString());
                    string product = rw["Product"].ToString();
                    string customer = rw["Customer"].ToString();
                    string weight = rw["Weight"].ToString();

                    string date = dateTime.ToString("yyyy-MM-dd");
                    string time = dateTime.ToString("HH:mm:ss", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));

                    dataSet1.Tables["CarProcess"].Rows.Add(licensePlate, date, time, product, customer, weight);
                }


                rptDailyReport.SetDataSource(dataSet1.Tables["CarProcess"]);


                crystalReportViewer1.EnableRefresh = false;
                crystalReportViewer1.ReportSource = rptDailyReport;
                crystalReportViewer1.Zoom(150);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการกำหนดค่ารายงาน \nError : " + ex.Message, "ข้อผิดผลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void frmShowReport_Load(object sender, EventArgs e)
        {
            // เช็คว่าผู้ใช้ต้องการแสดง report แบบไหน
            switch (_reportType)
            {
                case "TICKET": // ตั๋วชั่ง
                    defineParameterTicket();
                    break;
                case "DAILY": // รายงานประจำวัน
                    defineParameterDailyReport();
                    break;
                case "TOTAL_REPORT": // รายงานรวม
                    defineParameterTotalReport();
                    break;
                case "CAR_PROCESS": // รถค้างชั่ง
                    defineCarProcess();
                    break;
            }
        }
    }
}
