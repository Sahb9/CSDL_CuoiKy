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
    public partial class DoanhThuCuaHangForm : Form
    {
        public DoanhThuCuaHangForm()
        {
            InitializeComponent();
        }
        CuaHang ch = new CuaHang();
        private void DoanhThuCuaHangForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT *FROM CuaHang_LoadChart ");
            comboBoxCuaHang.DataSource = ch.getView(command);
            comboBoxCuaHang.ValueMember = "MaCuaHang";
            comboBoxCuaHang.DisplayMember = "MaCuaHang";



        }

        private void comboBoxCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT *FROM CuaHang_Chart (@ma) ");
                command.Parameters.Add("@ma", SqlDbType.VarChar).Value = comboBoxCuaHang.Text;
                DataTable table = ch.getView(command);
                int doanhthu = 0;
                int thue = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    doanhthu += Convert.ToInt32(table.Rows[i]["ThanhTien"].ToString());
                    thue += Convert.ToInt32(table.Rows[i]["Thue"].ToString());
                }
                labelTenCH.Text = "Tên Cửa Hàng : " + table.Rows[0]["TenCuaHang"].ToString();
                chart1.Series["Tien$"].Points.Clear();
                //chart1.Series["gender"].Points.AddXY("Male", sv.totalMaleStudent());
                chart1.Series["Tien$"].Points.AddXY("Doanh Thu", doanhthu);
                chart1.Series["Tien$"].Points.AddXY("Thuế", thue);
            }
            catch
            {

            }
        }
    }
}
