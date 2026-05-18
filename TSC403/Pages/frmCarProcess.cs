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
    public partial class frmCarProcess : Form
    {
        public frmCarProcess()
        {
            InitializeComponent();
        }

        private DataTable dataTable;

        void showCarProcess()
        {
            OrdersDb ordersDb = new OrdersDb();
            DataTable tbs = ordersDb.Selectstatus("Process");
            dataTable = tbs; // Store the data in a class-level variable for later use

            if (tbs == null)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูล: " + ordersDb.Err, "เกิดข้อผิดผลาด");
                return;
            }

            // show data to datagridview
            dgv.Rows.Clear();
            foreach (DataRow rw in tbs.Rows)
                dgv.Rows.Add(rw["LicensePlate"].ToString(), rw["DateTime"].ToString(), rw["Weight"].ToString());
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCarProcess_Load(object sender, EventArgs e)
        {
            showCarProcess();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลให้พิมพ์", "ไม่มีข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowReport frmShowReport = new frmShowReport(0, "CAR_PROCESS", dataTable);
            this.Hide();
            frmShowReport.ShowDialog();
            this.Show();
        }
    }
}
