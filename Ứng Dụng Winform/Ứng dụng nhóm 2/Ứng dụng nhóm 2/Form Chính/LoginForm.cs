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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        //user
        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "User Name")
                textBoxUser.Text = "";
        }
        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
                textBoxUser.Text = "User Name";
        }
        //pasword
        private void textBoxPassWord_Leave(object sender, EventArgs e)
        {
            if (textBoxPassWord.Text == "")
            {

                textBoxPassWord.Text = "PassWord";
            }
        }
        private void textBoxPassWord_Enter(object sender, EventArgs e)
        {
            if (textBoxPassWord.Text == "PassWord")
                textBoxPassWord.Text = "";
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        public bool verify()
        {
           
            if (textBoxUser.Text.Trim() == "" || textBoxPassWord.Text.Trim() == "")
            {
                return false;
            }
            else
                return true;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            My_db db = new My_db();
            if (radioButtonAdmin.Checked)
            {
                if (verify())
                {
                    DataTable table = new DataTable();
                    SqlCommand command = new SqlCommand("SELECT *FROM DangNhap (@usn,@pass)", db.getConnection);
                    command.Parameters.Add("@usn", SqlDbType.VarChar).Value = textBoxUser.Text;
                    command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBoxPassWord.Text;
                    //Xử lý dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if ((table.Rows.Count > 0))
                    {
                        MainForm frm1 = new MainForm();
                        frm1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButtonGuest.Checked)
            {
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("SELECT *FROM DangNhap_Guest (@usn,@pass)", db.getConnection);
                command.Parameters.Add("@usn", SqlDbType.VarChar).Value = textBoxUser.Text;
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBoxPassWord.Text;
                //Xử lý dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    GiaoDienDanhMucHangHoa frm1 = new GiaoDienDanhMucHangHoa();
                    frm1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
                MessageBox.Show("Please Check Again", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

      
    }
}
