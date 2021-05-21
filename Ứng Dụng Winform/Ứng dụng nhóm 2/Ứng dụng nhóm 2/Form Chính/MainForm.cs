using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ứng_dụng_nhóm_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

 

        private void danhMụcHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiaoDienDanhMucHangHoa frm = new GiaoDienDanhMucHangHoa();
            frm.Show();
        }

  

        private void hàngXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XuatKhoForm frm = new XuatKhoForm();
            frm.Show();
        }

        private void hàngNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapKhoForm frm = new NhapKhoForm();
            frm.Show();
        }

        private void thôngTinCửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuaHangForm frm = new CuaHangForm();
            frm.Show();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungCapForm frm = new NhaCungCapForm();
            frm.Show();
        }

        private void inThôngTinCửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuaHangPrintForm frm = new CuaHangPrintForm();
            frm.Show();
        }

        private void inThôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungCapPrintForm frm = new NhaCungCapPrintForm();
            frm.Show();
        }
        private void doanhThuCuaHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanhThuCuaHangForm FRM = new DoanhThuCuaHangForm();
            FRM.Show();
        }

        private void doanhThuNhaCungCapToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DoanhThuNhaCungCapForm frm = new DoanhThuNhaCungCapForm();
            frm.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
