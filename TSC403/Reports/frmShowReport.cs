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
        public frmShowReport(int orderId, string reportType)
        {
            InitializeComponent();

            _orderId = orderId;
            _reportType = reportType;
        }

        private readonly int _orderId = 0;
        private readonly string _reportType;

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

        private void frmShowReport_Load(object sender, EventArgs e)
        {
            // เช็คว่าผู้ใช้ต้องการแสดง report แบบไหน
            switch (_reportType)
            {
                case "TICKET": // ตั๋วชั่ง
                    defineParameterTicket();
                    break;
                case "DALY": // รายงานประจำวัน
                    break;
                case "TOTAL_REPORT": // รายงานรวม
                    break;
            }
        }
    }
}
