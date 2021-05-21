using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ứng_dụng_nhóm_2
{
    public partial class XuatKhoForm : Form
    {
        public XuatKhoForm()
        {
            InitializeComponent();
        }
        KhoHang khohang = new KhoHang();
        My_db db = new My_db();
        private void XuatKhoForm_Load(object sender, EventArgs e)
        {
            XuatThongTin();
            buttonEdit.Enabled = true;
            buttonAdd.Enabled = false;
            textBoxId.Enabled = false;
            textBoxPhieu.Enabled = false;
        }
        bool verif() //kiem tra xem cac box Null?
        {
            if (textBoxId.Text.Trim() == ""
                || textBoxTen.Text.Trim() == ""
                || textBoxSoluong.Text.Trim() == ""
                || textBoxDongia.Text.Trim() == ""
                || textBoxPhieu.Text.Trim() == "")
                return false;
            else
                return true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                string id = textBoxId.Text;
                string ten = textBoxTen.Text;
                DateTime ngay = dateTimePicker1.Value;
                int soluong = Convert.ToInt32(textBoxSoluong.Text);
                string dongia = textBoxDongia.Text;
                string phieu = textBoxPhieu.Text;
                //Hình ảnh
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                if (!checkXuatkho(id))
                {
                    if (khohang.insertXuatKho(id, ten, ngay, soluong, dongia, phieu, stream))
                    {
                        MessageBox.Show("Laptop da duoc xuat kho", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XuatThongTin();
                    }
                    else
                        MessageBox.Show("Error", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("ID hay Mã Phiếu Xuất đã tồn tại \n Xin vui lòng thử lại");
            }
            else
                MessageBox.Show("Empty Fiels", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        public void gRid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = khohang.getKho(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textBoxId.Text;
                string phieu = textBoxPhieu.Text;
                if (MessageBox.Show("Ban co chac?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    if (khohang.deleteXuatKho(ma, phieu))
                    {
                        MessageBox.Show("Da xoa", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxId.Text = "";
                        textBoxTen.Text = "";
                        textBoxSoluong.Text = "";
                        textBoxDongia.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        textBoxPhieu.Text = "";
                        //Cap nhat lai data
                        XuatThongTin();
                    }
                    else
                        MessageBox.Show("Khong the xoa", "Loi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            { MessageBox.Show("Co the ban chua nhap malaptop hoac phieuxuat", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            textBoxId.Enabled = true;
      
            textBoxPhieu.Enabled = true;

        }
        public void XuatThongTin()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HienXuatKho");
            gRid(command);
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                DateTime ngay = dateTimePicker1.Value;
                int soluong = Convert.ToInt32(textBoxSoluong.Text);
                string dongia = textBoxDongia.Text;
                string phieu = textBoxPhieu.Text;

                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                try
                {
                    string id = textBoxId.Text;
                    string ten = textBoxTen.Text;
                    if (khohang.updateXuatKho(id, ten, ngay, soluong, dongia, phieu,stream))
                    {
                        MessageBox.Show("Du lieu da duoc sua", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XuatThongTin();
                    }
                    else
                        MessageBox.Show("Error", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Xuat Kho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Empty Fiels", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            textBoxId.Enabled = true;
            textBoxPhieu.Enabled = true;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("EXEC proc_searXuatkho '" + textBoxSearch.Text + "'");
            gRid(command);

        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif) | *.jpg; *.png; *.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
            textBoxSoluong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxDongia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
         
            textBoxPhieu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //Set up ảnh
            SqlCommand command = new SqlCommand("select *from LayHinhAnh('" + textBoxId.Text + "')");
            DataTable table = khohang.getKho(command);      //Lấy ảnh từ kho hàng 
            byte[] pic = (byte[])table.Rows[0]["HinhAnh"];
            MemoryStream picture = new MemoryStream(pic);
            pictureBox1.Image = Image.FromStream(picture);
            //Tùy chỉnh Zoom
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //Khong the go ky tu cac textbox sau:
            textBoxId.Enabled = false;
          
            textBoxPhieu.Enabled = false;
        }

        private void buttonHien_Click(object sender, EventArgs e)
        {
            buttonEdit.Enabled = false;
            buttonAdd.Enabled = true;
            textBoxId.Enabled = true;
            textBoxPhieu.Enabled = true;
        }

        private void buttonAn_Click(object sender, EventArgs e)
        {
            buttonEdit.Enabled = true;
            buttonAdd.Enabled = false;
            textBoxId.Enabled = false;
            textBoxPhieu.Enabled = false;
        }

        private void linkLabelShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XuatThongTin();
        }
        public bool checkXuatkho(string ma)
        {
            SqlCommand command = new SqlCommand
                ("EXEC proc_checkXuatkho @ma", db.getConnection);//@ma, @phieu
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
