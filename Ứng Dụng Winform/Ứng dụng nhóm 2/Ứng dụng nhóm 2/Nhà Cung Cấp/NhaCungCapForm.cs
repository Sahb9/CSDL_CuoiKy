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

namespace Ứng_dụng_nhóm_2
{
    public partial class NhaCungCapForm : Form
    {
        public NhaCungCapForm()
        {
            InitializeComponent();
        }

        CungCap ch = new CungCap();
        private void NhaCungCapForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        public void LoadForm()
        {
            string connect = "SELECT *FROM NHACUNGCAP_Load";
            SqlCommand command = new SqlCommand(connect);
            DataTable table = ch.getView(command);
            dataGridView1.DataSource = table;
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string Mact = textBoxMaCongTy.Text;
            string textBoxTenCtyy = textBoxTenCty.Text;
            string Sdt = textBoxSDT.Text;
            string dchi = textBoxDiaChi.Text;
            if (ch.UpdateNhaCungCap(Mact, textBoxTenCtyy, Sdt, dchi))
            {
                LoadForm();
                MessageBox.Show("New NhaCungCap update", "Edit NhaCungCap", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("NhaCungCap Not update", "Edit NhaCungCap", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string Macc = textBoxMaCongTy.Text;


                if ((MessageBox.Show("Are You Sure You Want To Delete Nhà Cung Cấp", "Xóa Mã Phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (ch.deleteManhacungcap(Macc))
                    {
                        MessageBox.Show("Xóa NhaCungCap", "Delete NhaCungCap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxMaCongTy.Text = "";
                        textBoxTenCty.Text = "";
                        textBoxSDT.Text = "";
                        textBoxDiaChi.Text = "";
                        LoadForm();
                    }
                    else
                    {
                        MessageBox.Show(" NhaCungCap Not Deleted", "Delete NhaCungCap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete NhaCungCap", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT *FROM  NHACUNGCAP_TimKiem ('"+textBoxSearch.Text+"')");
            fillGrid(command);
        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.DataSource = ch.getView(command);
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            textBoxMaCongTy.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxTenCty.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxSDT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxDiaChi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void linkLabelShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm();
        }
    }
}
