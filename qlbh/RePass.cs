using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using qlbh.Control;

namespace qlbh
{
    public partial class RePass : Form
    {
        

        public RePass()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RePass_Load(object sender, EventArgs e)
        {
            control.Connect();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.Trim() == txtXacNhan.Text.Trim())
            {
                string sql = "UPDATE Login SET Password ='" + txtMatKhauMoi.Text.Trim() + "' where Username = N'" + txtTenDN.Text + "' and Password ='" + txtMatKhauCu.Text.Trim() + "'";
                control.RunSQL(sql);
                MessageBox.Show("Đổi Mật Khẩu Thành Công !!");
            }
            else
            {
                MessageBox.Show("Xác nhận mật khẩu mới thất bại !!");
            }
/*
            control.Connect();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from Login where Username = N'"+txtTenDN.Text+"' and Password = N'"+ txtmatkhaucu.Text +"'",control.Con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txtmatkhaumoi.Text == txtnhaplaimatkhau.Text)
                {
                    SqlDataAdapter dal = new SqlDataAdapter("update Login set Password = N'" + txtmatkhaumoi.Text + "' where Username = N'" + txtTenDN.Text + "' and Password = N'" + txtmatkhaucu.Text + "'", control.Con);
                    DataTable dt1= new DataTable();
                    da.Fill(dt1);
                    MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    errorProvider1.SetError(txtmatkhaumoi, "Bạn chưa điền mật khẩu!");
                    errorProvider1.SetError(txtnhaplaimatkhau, "Mật khẩu nhập lại chưa đúng!");
                }
            }
            else
            {
                errorProvider1.SetError(txtTenDN, "Tên người dùng không đúng !");
                errorProvider1.SetError(txtmatkhaucu, "Mật khẩu cũ chưa đúng!");
            }*/

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
