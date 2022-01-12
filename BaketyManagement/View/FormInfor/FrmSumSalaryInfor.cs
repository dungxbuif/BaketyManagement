using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp13212.Models;

namespace BaketyManagement.View.FormInfor
{
    public partial class FrmSumSalaryInfor : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        public static Int32 timeKeepedMonth;
        public static Int32 timeKeepedYear; 
        Int32 row = 0;
        public FrmSumSalaryInfor()
        {
            InitializeComponent();

            var data = from st in db.staff
                       join sl in db.Salaries on st.IdStaff equals sl.IdStaff
                       where sl.TimeKeeped.Month == timeKeepedMonth && sl.TimeKeeped.Year == timeKeepedYear
                       group new { st, sl } by new { st.IdStaff, st.NameStaff } into staffSl
                       select staffSl;

            var query = data
                    .Select(stf => new
                    {
                        idStaff = stf.Key.IdStaff,
                        nameStaff = stf.Key.NameStaff,
                        workingTime = stf.Sum(c => c.sl.WorkingTime),
                        hourOverTime = stf.Sum(c => c.sl.HoursOverTime),
                    });

            foreach (var m in query)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells[0].Value = m.idStaff.ToString();
                dataGridView1.Rows[row].Cells[1].Value = m.nameStaff.ToString();
                dataGridView1.Rows[row].Cells[2].Value = m.workingTime * 25000 + m.hourOverTime * 35000;
                row++;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrintSalary_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể in dữ liệu." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\Arial.ttf", BaseFont.IDENTITY_H, true);
                        iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                        iTextSharp.text.Font fontChuVua = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontChuTo = new iTextSharp.text.Font(bf, 22, iTextSharp.text.Font.BOLD);
                        iTextSharp.text.Font fontChuNhoDam = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<h1>TIEM BANH CAU DIEN</h1>");
                            sb.Append("<div>455 Cau Dien,<br /> Bac Tu Liem, Ha Noi</div>");
                            sb.Append("<div>(+84) 698-888-888</div>");
                            sb.Append("<div>Ngay in: " + DateTime.Now.ToString("dd/MM/yyyy") + "</div>");
                            sb.Append("<div>Noi dung: Bang luong  </div>");
                            sb.Append("<div><br></div>");
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach(DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, f));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Index < dataGridView1.Rows.Count - 1)
                                {
                                    PdfPCell cell1 = new PdfPCell(new Phrase(row.Cells[0].Value.ToString(), f));
                                    pdfTable.AddCell(cell1);
                                    string cell2 = row.Cells[1].Value.ToString();
                                    pdfTable.AddCell(cell2);
                                    string cell3 = row.Cells[2].Value.ToString();
                                    pdfTable.AddCell(cell3);
                                }
                                else
                                {
                                    string cell1 = "";
                                    pdfTable.AddCell(cell1);
                                    string cell2 = "";
                                    pdfTable.AddCell(cell2);
                                    string cell3 = "";
                                    pdfTable.AddCell(cell3);
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                StringReader sr = new StringReader(sb.ToString());
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                htmlparser.Parse(sr);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Xuất dữ liệu thành công !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}
