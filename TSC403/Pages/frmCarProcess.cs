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
    public partial class frmCarProcess : Form
    {
        public frmCarProcess()
        {
            InitializeComponent();
        }


        void showCarProcess()
        {
            OrdersDb ordersDb = new OrdersDb();
            DataTable tbs = ordersDb.SelectStatus("Process");
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
    }
}
