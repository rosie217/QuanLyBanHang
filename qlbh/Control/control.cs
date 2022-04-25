using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbh.Control
{
    class control
    {
        //kết nối
        public static SqlConnection Con;//tạo phương thức connect
        public static void Connect()
        {
            string Strconn = @"Data Source=ROSIE;Initial Catalog=QLBH;Integrated Security=True";
            Con = new SqlConnection(Strconn);   //Khởi tạo đối tượng
            //Con.ConnectionString =  @".\SQLEXPRESS;AttachDbFileName=" + 

            //ket nối khi cài máy khác 
            //project > qlbh properties >setting > đặt tên qlbh >QLBHconnectionStrinh > kieru connection string > value chọn  MSQL DATABASE fILE > CHỌN NƠI CHỨA> OK
            // gọi ra Con.ConnectionString = Properties.Settings.Default.QLBHconnectiontoSring;
            

           // Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\qlbh\qlbh\Data.mdf;Integrated Security=True;Connect Timeout=30
        //    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login");
            Con.Open();
        }

        //đóng kết nối
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();   	//Đóng kết nối
                Con.Dispose(); 	//Giải phóng tài nguyên
                Con = null;
            }
        }
        //Phương thức thực thi câu lệnh select lấy dữ liệu 
        public static DataTable GetDataToTable(string sql) {
            DataTable table = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            dap.Fill(table);
            return table;
        }

        //runbtn PHƯƠNG THỨC THỰC THI CÂU LỆNH INSERT UPDATE
        public static void RunSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand();//ĐỐI TƯỢNG LỚP SQLCOMMAND
            cmd.Connection = Con;// gán kết nối
            cmd.CommandText = sql;//gán sql
            try
            {
                cmd.ExecuteNonQuery();//thực hiện câu lệnh sql
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//giải phóng bộ nhớ
            cmd = null;
        }
        //Hàm kiểm tra khoá trùng
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)//nếu có hàng dữ liệu
                return true;
            else return false;
        }
        // hàm kiểm tra biếng dạng ngày tháng
        public static bool IsDate(string date)
        {
            string[] elements = date.Split('/');
            if ((Convert.ToInt32(elements[0]) >= 1) && (Convert.ToInt32(elements[0]) <= 31) && (Convert.ToInt32(elements[1]) >= 1) && (Convert.ToInt32(elements[1]) <= 12) && (Convert.ToInt32(elements[2]) >= 1900))
                return true;
            else return false;
        }

        // hàm convert thành định dạng ngày
        public static string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;
        }
        //hàm lấy dữ liệu từ một câu lệnh SQL đổ vào một ComboBox.
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }

        // hàm lấy dữ liệu từ một câu lệnh SQL.
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }

        // chuyển đổi từ số sang chữ


        //123 => một trăm hai ba đồng
        //1,123,000=>một triệu một trăm hai ba nghìn đồng
        //1,123,345,000 => một tỉ một trăm hai ba triệu ba trăm bốn lăm ngàn đồng
        static string [] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        //Viết hàm chuyển số hàng chục, giá trị truyền vào là số cần chuyển và một biến đọc phần lẻ hay không ví dụ 101 => một trăm lẻ một
        private static string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so%10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc>1) {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi==1) {
                    chuoi += " mốt";
                }
            } else if (chuc==1) {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi==1) {
                    chuoi += " một";
                }
            } else if (daydu && donvi>0) {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                    chuoi = " lẻ";
            }
            if (donvi==5 && chuc>=1) {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            } else if (donvi>1||(donvi==1&&chuc==0)) {
                chuoi += " " + mNumText[ donvi ];
            }
            return chuoi;
        }
        private static string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so/100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so%100;
            if (daydu || tram>0) {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so,true);
            } else {
                chuoi = DocHangChuc(so,false);
            }
            return chuoi;
        }
        private static string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so/1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so%1000000;
            if (trieu>0) {
                chuoi = DocHangTram(trieu,daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so%1000;
            if (nghin>0) {
                chuoi += DocHangTram(nghin,daydu) + " nghìn";
                daydu = true;
            }
            if (so>0) {
                chuoi += DocHangTram(so,daydu);
            }
            return chuoi;
       }
        public static string ChuyenSoSangChuoi(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }  
        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        

    }
}
