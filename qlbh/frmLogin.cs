using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using qlbh.Control;
using System.Data.SqlClient;

namespace qlbh
{
    public partial class FormDangnhap : Form
    {
        public FormDangnhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Bo góc lại nhưng k bị thay đổi kích thước */
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            Frmpass.AutoSize = false;
        }
        private void FrmUser_Enter(object sender, EventArgs e)
        {   
            if (FrmUser.Text == "Username...") {
                FrmUser.Text = "";
                //placeholder username
                FrmUser.ForeColor = Color.Black;
            }
        }

        private void FrmUser_Leave(object sender, EventArgs e)
        {
            if (FrmUser.Text == "")
            {
                FrmUser.Text = "Username...";

                FrmUser.ForeColor = Color.LightGray;
            }
        }

        private void Frmpass_Enter(object sender, EventArgs e)
        {
            if (Frmpass.Text == "Password...")
            {
                Frmpass.Text = "";
                //placeholder password
                Frmpass.ForeColor = Color.Black;
            }
        }

        private void Frmpass_Leave(object sender, EventArgs e)
        {
            if (Frmpass.Text == "")
            {
                Frmpass.Text = "Password...";

                Frmpass.ForeColor = Color.LightGray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //thoast chuong trinh
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connect database
            control.Connect();
            string Username = FrmUser.Text;//check user
            string Password = Frmpass.Text;//check pass
            string sqlTextCommand = "select * from Login where user_name LIKE'" + Username + "' and pass LIKE'" + Password + "'";
            SqlCommand sqlcmd = new SqlCommand(sqlTextCommand, control.Con);
            SqlDataReader data = sqlcmd.ExecuteReader();
            //kiem tra roi hien thi
            if (data.Read() == true)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                Form Main = new Main();
                Main.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Sai MẬT KHẨU hoặc TÀI KHOẢN! Vui lòng thử lại.", "Đăng nhập không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frmpass_TextChanged(object sender, EventArgs e)
        {

        }

 
    }

}
