using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Db;
using TSC403.Reports;

namespace TSC403.Pages
{
    public partial class frmDailyReport : Form
    {
        public frmDailyReport()
        {
            InitializeComponent();
        }

        private DataTable tb;

        void showReportToday()
        {
            OrdersDb ordersDb = new OrdersDb();
            string dateIn = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
            string dateOut = DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"));
            tb = ordersDb.SelectByQuery(dateIn, dateOut, "", "", "", "Success");
            dataGridView1.Rows.Clear();
            if(tb == null)
            {
                // alert message when error 
               MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูล กรุณาลองใหม่อีกครั้ง \n Error : " + ordersDb.Err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tb.Rows.Count > 0 || tb != null)
            {
                int totalWeight = 0;
                // loop แสดงข้อมูล
                foreach (DataRow rw in tb.Rows)
                {
                    dataGridView1.Rows.Add("", rw["Id"].ToString(), rw["OrderNumber"].ToString(), rw["LicensePlate"].ToString(), rw["DateIn"].ToString(), rw["WeightIn"].ToString(), rw["DateOut"].ToString(), rw["WeightOut"].ToString(), rw["NetWeight"].ToString(), rw["ProductName"].ToString(), rw["CustomerName"].ToString());
                    totalWeight += int.Parse(rw["NetWeight"].ToString());
                }

                // show total weight 
                label6.Text = totalWeight.ToString("#,###");
                // show total list
                label5.Text = tb.Rows.Count.ToString("#,###");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmDailyReport_Load(object sender, EventArgs e)
        {
            showReportToday();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string clName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (clName == "cl_print")
                {
                    int order_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["cl_id"].Value.ToString());
                    frmShowReport frmShowReport = new frmShowReport(order_id, "TICKET", null);
                    this.Hide();
                    frmShowReport.ShowDialog();
                    this.Show();
                }
            }
            catch
            {


            }
        }

        private void btnPrintDailyReport_Click(object sender, EventArgs e)
        {
            frmShowReport frmShowReport = new frmShowReport(0, "DAILY", tb);
            this.Hide();
            frmShowReport.ShowDialog();
            this.Show();
        }

        private void frmDailyReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                this.Close();
        }
    }
}
