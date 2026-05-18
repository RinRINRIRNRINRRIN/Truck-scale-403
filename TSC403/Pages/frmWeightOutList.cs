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

namespace TSC403.Pages
{
    public partial class frmWeightOutList : Form
    {
        public frmWeightOutList()
        {
            InitializeComponent();
        }

        public int OrderId { get; set; }
        public int WeightIn { get; set; }
        void showCarProcess()
        {
            OrdersDb ordersDb = new OrdersDb();
            DataTable tbs = ordersDb.Selectstatus("Process");
            if (tbs == null)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูล: " + ordersDb.Err, "เกิดข้อผิดผลาด");
                return;
            }

            // show data to datagridview
            dgv.Rows.Clear();
            foreach (DataRow rw in tbs.Rows)
                dgv.Rows.Add(rw["Id"].ToString(),rw["LicensePlate"].ToString(), rw["Weight"].ToString(), rw["DateTime"].ToString(), rw["Customer"].ToString(), rw["Product"].ToString());
        }

        private void frmWeightOutList_Load(object sender, EventArgs e)
        {
            showCarProcess();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int orderid = int.Parse(dgv.Rows[e.RowIndex].Cells["cl_id"].Value.ToString());
                OrderId = orderid;
                WeightIn = int.Parse(dgv.Rows[e.RowIndex].Cells["cl_weighIn"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเลือกรายการชั่ง \nError: " + ex.Message, "เกิดข้อผิดผลาด");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (OrderId != 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการชั่งที่ต้องการ", "ไม่มีรายการชั่งที่ถูกเลือก", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
