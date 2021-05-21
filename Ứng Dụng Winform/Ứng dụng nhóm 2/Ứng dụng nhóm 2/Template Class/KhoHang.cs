using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ứng_dụng_nhóm_2
{
    class KhoHang
    {
        My_db mydb = new My_db();

        public DataTable getKho(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //XUAT KHO

        public bool insertXuatKho(string ma, string ten, DateTime ngay, int soluong, string dongia, string phieu,MemoryStream picture)
        {
            SqlCommand command = new SqlCommand
                ("exec proc_insXuatKho @ma, @ten, @ngay, @soluong, @dongia, @phieu,@picture", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = ten;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            command.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
            command.Parameters.Add("@dongia", SqlDbType.VarChar).Value = dongia;
            command.Parameters.Add("@phieu", SqlDbType.VarChar).Value = phieu;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();
            mydb.openConnection();
            //if (command.ExecuteNonQuery() == 1)
            if (command.ExecuteNonQuery() >= 1) //Do ket qua excute co so dong(row) >= 1
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool deleteXuatKho(string ma, string phieu)
        {
            SqlCommand command = new SqlCommand("EXEC proc_delXuatKho @ma, @phieu", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            command.Parameters.Add("@phieu", SqlDbType.VarChar).Value = phieu;
            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateXuatKho(string ma, string ten, DateTime ngay, int soluong, string dongia, string phieu,MemoryStream picture)
        {
            SqlCommand command = new SqlCommand
                ("exec proc_upXuatKho @ma, @ten, @ngay, @soluong, @dongia, @phieu,@picture", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = ten;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            command.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
            command.Parameters.Add("@dongia", SqlDbType.VarChar).Value = dongia;
            command.Parameters.Add("@phieu", SqlDbType.VarChar).Value = phieu;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

         
            mydb.openConnection();
            if (command.ExecuteNonQuery() >= 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        //NHAP KHO

        public bool insertNhapKho(string ma, string ten, DateTime ngay, int soluong, string dongia, string phieu,MemoryStream picture)
        {
            SqlCommand command = new SqlCommand
                ("exec proc_insNhapKho @ma, @ten, @ngay, @soluong, @dongia, @phieu,@picture", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = ten;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            command.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
            command.Parameters.Add("@dongia", SqlDbType.VarChar).Value = dongia;
            command.Parameters.Add("@phieu", SqlDbType.VarChar).Value = phieu;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            //if (command.ExecuteNonQuery() == 1)
            if (command.ExecuteNonQuery() >= 1) //Do ket qua excute co so dong(row) >= 1
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool deleteNhapKho(string ma, string phieu)
        {
            SqlCommand command = new SqlCommand("EXEC proc_delNhapKho @ma, @phieu", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            command.Parameters.Add("@phieu", SqlDbType.VarChar).Value = phieu;
            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateNhapKho(string ma, string ten, DateTime ngay, int soluong, string dongia, string phieu,MemoryStream picture)
        {
            SqlCommand command = new SqlCommand
                ("exec proc_upNhapKho @ma, @ten, @ngay, @soluong, @dongia, @phieu,@picture", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = ma;
            command.Parameters.Add("@ten", SqlDbType.VarChar).Value = ten;
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            command.Parameters.Add("@soluong", SqlDbType.Int).Value = soluong;
            command.Parameters.Add("@dongia", SqlDbType.VarChar).Value = dongia;
            command.Parameters.Add("@phieu", SqlDbType.VarChar).Value = phieu;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if (command.ExecuteNonQuery() >= 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
