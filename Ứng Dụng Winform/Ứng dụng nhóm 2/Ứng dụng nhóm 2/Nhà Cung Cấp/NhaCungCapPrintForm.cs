using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace Ứng_dụng_nhóm_2
{
    public partial class NhaCungCapPrintForm : Form
    {
        public NhaCungCapPrintForm()
        {
            InitializeComponent();
        }
        CungCap cungcap = new CungCap();
        private void NhaCungCapPrintForm_Load(object sender, EventArgs e)
        {
            string connect = "SELECT *FROM NHACUNGCAP_LoadPrint";
            LoadForm(connect);
        }

        public void LoadForm(string connect)
        {
            dataGridView1.RowTemplate.Height = 30;
            SqlCommand command = new SqlCommand(connect);
            System.Data.DataTable table = cungcap.getView(command);
            //Tinh chỉnh khung datagrid View      
            dataGridView1.DataSource = table;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string connect = "SELECT * FROM NHACUNGCAP_SearchPrint ('" + textBoxSearch.Text + "')";
            LoadForm(connect);
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string connect = "SELECT *FROM NHACUNGCAP_LoadPrint";
            LoadForm(connect);
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "Danh sach cua hang.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }
        }
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
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
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
                    headerRange.Text = "Danh Sách Cửa Hàng";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save image
                //for (r = 0; r <= RowCount - 1; r++)
                //{
                //    byte[] imgbyte = (byte[])DGV.Rows[r].Cells[2].Value;
                //    MemoryStream ms = new MemoryStream(imgbyte);
                //    Image finalPic = (Image)(new Bitmap(Image.FromStream(ms), new Size(70, 70)));
                //    Clipboard.SetDataObject(finalPic);
                //    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.Paste();  // ảnh +1
                //    oDoc.Application.Selection.Tables[1].Cell(r + 2, 3).Range.InsertParagraph();//ảnh +1
                //}
                oDoc.SaveAs(filename);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
