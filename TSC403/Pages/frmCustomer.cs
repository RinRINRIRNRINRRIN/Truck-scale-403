using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Db;
using TSC403.Models;

namespace TSC403.Pages
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        void clearForm()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            txtCode.Enabled = true;
            txtCode.Clear();
            txtName.Clear();
        }

        void showDataToGrid()
        {
            CustomerDb customerDb = new CustomerDb();
            List<CustomerModels> lists = customerDb.SelectAll();
            dataGridView1.Rows.Clear();

            if (lists != null && lists.Count > 0)
            {    
                foreach (CustomerModels item in lists)
                    dataGridView1.Rows.Add(item.CustomerCode, item.CustomerName);
            }
        }

        bool checkCodeDuplicate(string data)
        {
            foreach (DataGridViewRow rw in dataGridView1.Rows)
            {
                if (rw.Cells["cl_code"].Value.ToString() == data)
                    return true;
            }
            return false;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            showDataToGrid();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkCodeDuplicate(txtCode.Text))
            {
                MessageBox.Show("พบข้อมูลซ้ำกรุณาตรวจสอบใหม่อีกครั้ง", "ข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Define customer model
            CustomerModels model = new CustomerModels
            {
                CustomerCode = txtCode.Text.Trim(),
                CustomerName = txtName.Text.Trim(),
            };

            // save new data
            CustomerDb db = new CustomerDb();
            if (!db.AddNew(model))
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการบันทึกข้อมูล \nError : " + db.Err, "ข้อผิดผลาดในการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("เพิ่มรายการใหม่สำเร็จ", "เพิ่มรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearForm();
            showDataToGrid();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการลบข้อมูลบริษัทหรือไม่", "ลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CustomerDb db = new CustomerDb();
                if (!db.DeleteByCode(txtCode.Text))
                {
                    MessageBox.Show("เกิข้อผิดผลาดในการลบข้อมูลบริษัท", "ลบข้อมูลบริษัท", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("ลบข้อมูลสำเร็จ", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearForm();
                showDataToGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (checkCodeDuplicate(txtCode.Text))
            //{
            //    MessageBox.Show("พบข้อมูลซ้ำกรุณาตรวจสอบใหม่อีกครั้ง", "ข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Define customer model
            CustomerModels model = new CustomerModels
            {
                CustomerCode = txtCode.Text.Trim(),
                CustomerName = txtName.Text.Trim(),
            };

            // save new data
            CustomerDb db = new CustomerDb();
            if (!db.UpdateByCode(model))
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการแก้ไขข้อมูล \nError : " + db.Err, "ข้อผิดผลาดในการแก้ไข", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("แก้ไขรายการสำเร็จ", "แก้ไขรายการ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearForm();
            showDataToGrid();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string code = dataGridView1.Rows[e.RowIndex].Cells["cl_code"].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells["cl_name"].Value.ToString();

                txtCode.Text = code;
                txtName.Text = name;
                txtCode.Enabled = false;

                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;

            }
            catch
            {


            }
        }
    }
}
