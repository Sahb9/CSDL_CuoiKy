using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ứng_dụng_nhóm_2
{
    class CungCap
    {
        My_db dt = new My_db();
        // Hàm này để kết nối bảng với datagridview
        public DataTable getView(SqlCommand command)
        {
            command.Connection = dt.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        // Hàm xóa nhà cung cấp
        public bool deleteManhacungcap(string MAcc)
        {
            SqlCommand command = new SqlCommand("exec NHACUNGCAP_Xoa @mact", dt.getConnection);
            command.Parameters.Add("@mact", SqlDbType.VarChar).Value = MAcc;
            dt.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                dt.closeConnection(); return true;
            }
            else
            {
                dt.closeConnection(); return false;
            }
        }

        // Hàm edit nhà cung cấp
        public bool UpdateNhaCungCap(string MaCh, string tencty, string Sdt, string diachi)
        {
            SqlCommand command = new SqlCommand("exec NHACUNGCAP_Update @mch,@tct,@sdt,@dc", dt.getConnection);
            command.Parameters.Add("@mch", SqlDbType.VarChar).Value = MaCh;
            command.Parameters.Add("@tct", SqlDbType.VarChar).Value = tencty;
            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = Sdt;
            command.Parameters.Add("@dc", SqlDbType.VarChar).Value = diachi;

            dt.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                dt.closeConnection();
                return true;
            }
            else
            {
                dt.closeConnection();
                return false;
            }
        }
        
    }
}
