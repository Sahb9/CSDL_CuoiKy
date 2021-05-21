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
    public partial class CuaHangForm : Form
    {
        public CuaHangForm()
        {
            InitializeComponent();
        }
        CuaHang ch = new CuaHang();

        private void CuaHangForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        public void LoadForm()
        {
            string connect = "SELECT *FROM CUAHANG_Load";
            SqlCommand command = new SqlCommand(connect);
            DataTable table = ch.getView(command);
            //Tinh chỉnh khung datagrid View
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = table;
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string MaCuaH = textBoxMaCuaHang.Text;
                if ((MessageBox.Show("Are You Sure You Want To Delete Cửa Hàng", "Xóa Cửa Hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (ch.deleteMaCuaHang(MaCuaH))
                    {
                        MessageBox.Show("Xóa Cửa Hàng", "Delete Xóa Cửa Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadForm();

                        textBoxMaCuaHang.Text = "";
                        textBoxDiaChi.Text = "";
                        textBoxSDT.Text = "";
                        textBoxTenCuaHang.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("CuaHang Not Deleted", "Delete CuaHang", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception E)
            {
                MessageBox.Show(E.ToString());
                MessageBox.Show("Please Enter A Valid ID", "Delete CuaHang", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string Mach = textBoxMaCuaHang.Text;
            string dc = textBoxDiaChi.Text;
            int Sdt = Convert.ToInt32(textBoxSDT.Text);       //
            string tch = textBoxTenCuaHang.Text;
            if (ch.UpdateCuaHang(Mach, dc, Sdt, tch))
            {
                LoadForm();
                MessageBox.Show("New CuaHang update", "Edit CuaHang", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("CuaHang Not update", "Edit CuaHang", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

   
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = ch.getView(command);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select *from CUAHANG_TimKiem  ('" + textBoxSearch.Text + "')");
            fillGrid(command);
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            textBoxMaCuaHang.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxDiaChi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxSDT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxTenCuaHang.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void linkLabelShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm();
            textBoxSearch.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
