using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbh
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
            Application.Run(new FormDangnhap());
            /*Docx
              EventArgs e là một tham số gọi là e chứa dữ liệu sự kiện, xem trang MSDN của EventArss để biết thêm thông tin.
              Object Sender là một tham số có tên Người gửi chứa tham chiếu đến điều khiển/đối tượng đã đưa ra sự kiện.
            */
        }
    }
}
