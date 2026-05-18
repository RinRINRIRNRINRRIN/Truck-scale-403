using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Reports;

namespace TSC403.Pages
{
    public partial class frmHistory : Form
    {
        public frmHistory(DataTable dataTable)
        {
            InitializeComponent();
            _dataTable = dataTable;
        }

        private readonly DataTable _dataTable;


        void LoadData()
        {
            dgv.Rows.Clear();
            foreach (DataRow rw in _dataTable.Rows)
            {
                dgv.Rows.Add("", rw["ID"].ToString(), rw["OrderNumber"].ToString(), rw["LicensePlate"].ToString(), rw["DateIn"].ToString(), rw["WeightIn"].ToString(), rw["DateOut"].ToString(), rw["WeightOut"].ToString(), rw["NetWeight"].ToString(), rw["ProductName"].ToString(), rw["CustomerName"].ToString());
            }
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            frmShowReport frmShowReport = new frmShowReport(0, "TOTAL_REPORT", _dataTable);
            this.Hide();
            frmShowReport.ShowDialog();
            this.Show();
        }
    }
}
