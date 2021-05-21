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
    public partial class DoanhThuNhaCungCapForm : Form
    {
        public DoanhThuNhaCungCapForm()
        {
            InitializeComponent();
        }
        CungCap cungcap = new CungCap();
      

        private void DoanhThuNhaCungCapForm_Load(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand ("SELECT *FROM NhaCungCap_LoadChart "); 
            comboBoxNhaCungCap.DataSource = cungcap.getView(command);
            comboBoxNhaCungCap.ValueMember = "MaNhaCungCap";
            comboBoxNhaCungCap.DisplayMember = "MaNhaCungCap";
        }

        private void comboBoxNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT *FROM NhaCungCap_Chart(@ma) ");
                command.Parameters.Add("@ma", SqlDbType.VarChar).Value = comboBoxNhaCungCap.Text;
                DataTable table = cungcap.getView(command);
                int doanhthu = 0;
                int thue = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    doanhthu += Convert.ToInt32(table.Rows[i]["ThanhTien"].ToString());
                    thue += Convert.ToInt32(table.Rows[i]["Thue"].ToString());
                }
                //MessageBox.Show(table.Rows.Count.ToString());
                labelTenCty.Text = "Tên Công Ty : " + table.Rows[0]["TenCongTy"].ToString();
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
