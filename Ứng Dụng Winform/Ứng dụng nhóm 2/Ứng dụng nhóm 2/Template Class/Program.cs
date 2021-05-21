using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ứng_dụng_nhóm_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new GiaoDienDanhMucHangHoa());
            //Application.Run(new NhapKhoForm());
            //Application.Run(new XuatKhoForm());
            //Application.Run(new NhaCungCapForm());
            //Application.Run(new CuaHangForm());
            //Application.Run(new LoginForm());
            //Application.Run(new CuaHangPrintForm());
            //Application.Run(new DoanhThuCuaHangForm());
        }
    }
}
