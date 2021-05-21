using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Word = Microsoft.Office.Interop.Word;
using Word =Microsoft.Office.Interop.Word;
namespace Ứng_dụng_nhóm_2
{
    public partial class GiaoDienDanhMucHangHoa : Form
    {
        public GiaoDienDanhMucHangHoa()
        {
            InitializeComponent();
        }
        My_db db = new My_db();
        KhoHang khohang = new KhoHang();
        private void GiaoDienDanhMucHangHoa_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM danhmuchanghoa");
            xuatData(command);
            SqlCommand commandX = new SqlCommand("select * from XuatAll");
            comboXuatHien(commandX);

        }
        public void fillGridView(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 70;
            dataGridView1.DataSource = hanghoa.getHangHoa(command);
            dataGridView1.AllowUserToAddRows = false;
        }
        
        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }
        //dinh dang luu word
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {

            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
                // add row
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        try
                        {
                            if (c == 6 || c == 7)
                            {
                                DataArray[r, c] = ((DateTime)dataGridView1.Rows[r].Cells[c].Value).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                Document oDoc = new Document();
                oDoc.Application.Visible = true;

                oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";
                    }
                }
                oRange.Text = oTemp;
                object Separator = WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();


                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c < ColumnCount; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;


                foreach (Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                    headerRange.Text = "Danh Sách Hàng Hóa";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save image
                for (r = 0; r < RowCount - 1; r++)
                {
                    byte[] imgbyte = (byte[])DGV.Rows[r].Cells[2].Value;
                    MemoryStream ms = new MemoryStream(imgbyte);
                    Image finalPic = (Image)(new Bitmap(Image.FromStream(ms), new Size(70, 70)));
                    Clipboard.SetDataObject(finalPic);
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.Paste();  // ảnh +1
                    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.InsertParagraph();//ảnh +1
                }
                oDoc.SaveAs(filename);
            }
        }
        HangHoa hanghoa = new HangHoa();
 
        private void buttonPrint_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "ListHangHoa.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
           
            SqlCommand command = new SqlCommand("SELECT *FROM Search ('" + comboBoxSearch.SelectedValue.ToString() + "')");
            xuatData(command);
        }
        
        public void comboXuatHien(SqlCommand command)
        {
            //SqlCommand command = new SqlCommand("select *from XuatPhieuXuat");
            comboBoxSearch.DataSource = getPhieu(command);
            comboBoxSearch.DisplayMember = "MaLapTop";
            comboBoxSearch.ValueMember = "MaLapTop";

        }
        private void radioButtonAll_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM danhmuchanghoa");
            xuatData(command);
            SqlCommand commandX = new SqlCommand("select * from XuatAll");
            comboXuatHien(commandX);
        }

        private void radioButtonNhap_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from SearchNhapKho");
            xuatData(command);
            SqlCommand commandX = new SqlCommand("select * from XuatPhieuNhap");
            comboXuatHien(commandX);
        }

        private void radioButtonXuat_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from SearchXuatKho");
            xuatData(command);
            SqlCommand commandX = new SqlCommand("select * from XuatPhieuXuat");
            comboXuatHien(commandX);
        }
        public void xuatData(SqlCommand command)
        {
            dataGridView1.RowTemplate.Height = 50;
            //vào database
            dataGridView1.DataSource = getPhieu(command);
            //column 2 setup ảnh
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;  //tùy chỉnh kích thước ảnh
            dataGridView1.AllowUserToAddRows = false;
        }
        
        public System.Data.DataTable getPhieu(SqlCommand command)
        {
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);
            return table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
