using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            int totalWeight = 0, totalList = 0;
            foreach (DataRow rw in _dataTable.Rows)
            {
                dgv.Rows.Add("", rw["ID"].ToString(), rw["OrderNumber"].ToString(), rw["LicensePlate"].ToString(), rw["DateIn"].ToString(), rw["WeightIn"].ToString(), rw["DateOut"].ToString(), rw["WeightOut"].ToString(), rw["NetWeight"].ToString(), rw["ProductName"].ToString(), rw["CustomerName"].ToString());
                totalWeight += int.Parse(rw["NetWeight"].ToString());

            }

            // show total weight 
            label6.Text = totalWeight.ToString("#,###");
            // show total list
            label5.Text = _dataTable.Rows.Count.ToString("#,###");
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

        private void btnExcel_Click(object sender, EventArgs e)
        {

            // 2. เปิด SaveFileDialog ให้ผู้ใช้เลือกที่อยู่บันทึกไฟล์
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = $"รายงานประจำวัน_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                sfd.Title = "เลือกที่อยู่สำหรับบันทึกไฟล์ Excel";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("DailyReport");

                            // --- [ส่วนอื่น ๆ ของ Excel: ส่วนหัวรายงานตามภาพ] ---
                            // แถวที่ 1: หัวข้อรายงาน
                            string reportTitle = "รายงาน";

                            worksheet.Cell("A1").Value = reportTitle;
                            worksheet.Cell("A1").Style.Font.Bold = true;
                            worksheet.Cell("A1").Style.Font.FontSize = 16;
                            worksheet.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            worksheet.Range("A1:L1").Merge(); // ยุบรวมเซลล์แนวนอนเพื่อให้หัวข้ออยู่กึ่งกลางตาราง

                            // แถวที่ 3: หัวตาราง (สไตล์สีน้ำเงินเข้มตามภาพเดิม)
                            string[] headers = { "ลำดับ", "เลขที่", "ทะเบียนรถ", "วันที่", "เวลา", "นน.รวม", "นน.รถ", "นน.สุทธิ", "บริษัท", "สินค้า", "วันที่ออก", "เวลาออก" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                var cell = worksheet.Cell(3, i + 1);
                                cell.Value = headers[i];
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#2F5597"); // สีน้ำเงินเข้ม
                                cell.Style.Font.FontColor = XLColor.White;
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            }

                            // --- [ส่วนข้อมูลจาก DataTable: พื้นที่สีฟ้า] ---
                            int startRow = 4; // ข้อมูลจริงเริ่มแถวที่ 4 ต่อจากหัวตาราง
                            int rowCount = 1;

                            foreach (DataRow row in _dataTable.Rows)
                            {
                                worksheet.Cell(startRow, 1).Value = rowCount; // ลำดับที่
                                worksheet.Cell(startRow, 2).Value = row["OrderNumber"]?.ToString();
                                worksheet.Cell(startRow, 3).Value = row["LicensePlate"]?.ToString();

                                // จัดการวันที่และเวลาเข้า
                                if (row["DateIn"] != DBNull.Value && DateTime.TryParse(row["DateIn"].ToString(), out DateTime dtIn))
                                {
                                    worksheet.Cell(startRow, 4).Value = dtIn.ToString("dd/MM/yyyy");
                                    worksheet.Cell(startRow, 5).Value = dtIn.ToString("HH:mm:ss");
                                }

                                // ส่วนของตัวเลขน้ำหนัก (คอลัมน์ 6, 7, 8)
                                worksheet.Cell(startRow, 6).Value = Convert.ToDouble(row["WeightIn"] ?? 0);   // นน.รวม (น้ำหนักแรกเข้า)
                                worksheet.Cell(startRow, 7).Value = Convert.ToDouble(row["WeightOut"] ?? 0);  // นน.รถ (น้ำหนักตอนออก)
                                worksheet.Cell(startRow, 8).Value = Convert.ToDouble(row["NetWeight"] ?? 0);  // นน.สุทธิ (NetWeight)

                                worksheet.Cell(startRow, 9).Value = row["CustomerName"]?.ToString();  // บริษัท
                                worksheet.Cell(startRow, 10).Value = row["ProductName"]?.ToString();  // สินค้า

                                // จัดการวันที่และเวลาออก (ถ้ามี)
                                if (row["DateOut"] != DBNull.Value && DateTime.TryParse(row["DateOut"].ToString(), out DateTime dtOut))
                                {
                                    worksheet.Cell(startRow, 11).Value = dtOut.ToString("dd/MM/yyyy");
                                    worksheet.Cell(startRow, 12).Value = dtOut.ToString("HH:mm:ss");
                                }

                                // ย้อมสีฟ้าอ่อนและจัดฟอร์แมตตัวเลขในพื้นที่ข้อมูล
                                for (int col = 1; col <= 12; col++)
                                {
                                    var cell = worksheet.Cell(startRow, col);
                                    cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#DDEBF7"); // สีฟ้าอ่อนตามดีไซน์เดิม
                                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                    cell.Style.Border.OutsideBorderColor = XLColor.LightGray;

                                    // จัดชิดขวาและใส่คอมมาให้กลุ่มตัวเลขน้ำหนัก (คอลัมน์ 6, 7, 8)
                                    if (col >= 6 && col <= 8)
                                    {
                                        cell.Style.NumberFormat.Format = "#,##0";
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                                    }
                                    else if (col == 1 || col == 4 || col == 5 || col == 11 || col == 12)
                                    {
                                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    }
                                }

                                startRow++;
                                rowCount++;
                            }

                            // --- [ส่วนอื่น ๆ ของ Excel: ส่วนท้ายตาราง (Summary)] ---
                            int summaryRow = startRow; // แถวสรุปจะอยู่ต่อจากข้อมูลแถวสุดท้ายพอดี

                            // 1. ส่วนของ น้ำหนักรวมทั้งหมด (คิดจาก NetWeight คอลัมน์ H หรือคอลัมน์ที่ 8)
                            worksheet.Cell(summaryRow, 1).Value = "น้ำหนักรวม";
                            worksheet.Cell(summaryRow, 1).Style.Font.Bold = true;
                            worksheet.Cell(summaryRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                            var netWeightSumCell = worksheet.Cell(summaryRow, 8); // คอลัมน์ H (นน.สุทธิ)
                            netWeightSumCell.FormulaA1 = $"=SUM(H4:H{summaryRow - 1})"; // รวมตั้งแต่แถวที่ 4 ถึงแถวก่อนหน้า
                            netWeightSumCell.Style.Font.Bold = true;
                            netWeightSumCell.Style.NumberFormat.Format = "#,##0";
                            netWeightSumCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            worksheet.Cell(summaryRow, 9).Value = "กก.";
                            worksheet.Cell(summaryRow, 9).Style.Font.Bold = true;

                            // 2. ส่วนของ รวมรายการทั้งหมด (นับจำนวนแถวข้อมูลยิงตรงไปที่คอลัมน์ J)
                            worksheet.Cell(summaryRow, 10).Value = "รวมทั้งหมด";
                            worksheet.Cell(summaryRow, 10).Style.Font.Bold = true;
                            worksheet.Cell(summaryRow, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            var totalRowsCell = worksheet.Cell(summaryRow, 11); // แสดงจำนวนรายการในคอลัมน์ K
                            totalRowsCell.FormulaA1 = $"=COUNTA(A4:A{summaryRow - 1})"; // ใช้ COUNTA นับจำนวนลำดับที่
                            totalRowsCell.Style.Font.Bold = true;
                            totalRowsCell.Style.NumberFormat.Format = "#,##0";
                            totalRowsCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            worksheet.Cell(summaryRow, 12).Value = "รายการ";
                            worksheet.Cell(summaryRow, 12).Style.Font.Bold = true;

                            // ตกแต่งเส้นขอบปิดท้ายของแถวสรุปยอดรวม
                            for (int col = 1; col <= 12; col++)
                            {
                                var cell = worksheet.Cell(summaryRow, col);
                                cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                                cell.Style.Border.BottomBorder = XLBorderStyleValues.Double; // เส้นคู่แสดงผลรวมตามมาตรฐานบัญชี
                            }

                            // ปรับขนาดคอลัมน์ให้ขยายพอดีตัวอักษรอัตโนมัติ
                            worksheet.Columns().AdjustToContents();

                            // บันทึกไฟล์ไปที่โฟลเดอร์ที่ผู้ใช้เลือก
                            workbook.SaveAs(sfd.FileName);
                        }

                        // 4. บันทึกเสร็จเรียบร้อย สั่งเปิดไฟล์อัตโนมัติทันที
                        MessageBox.Show("ส่งออกรายงาน Excel เรียบร้อยแล้วครับ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาดขณะบันทึกหรือเปิดไฟล์: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string clName = dgv.Columns[e.ColumnIndex].Name;
                if (clName == "cl_print")
                {
                    int order_id = int.Parse(dgv.Rows[e.RowIndex].Cells["cl_id"].Value.ToString());
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

        private void frmHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                this.Close();
        }
    }
}

