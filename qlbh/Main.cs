using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlbh.Control;

namespace qlbh
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            customDesing();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void customDesing()
        {
            panelMediaSubmenu.Visible = false;
            panelBCSubmenu.Visible = false;
            panelDMSubmenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if(panelMediaSubmenu.Visible = true)
               panelMediaSubmenu.Visible = false;
            if(panelBCSubmenu.Visible = true)
               panelBCSubmenu.Visible = false;
            if(panelDMSubmenu.Visible = true)
               panelDMSubmenu.Visible = false;
            //ẩn submenu
        }

        private void showSubmenu(Panel subMenu)
        {
            //hiện submenu
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        #region ChucNang
        private void btnChucNang_Click(object sender, EventArgs e)
        {
            showSubmenu(panelMediaSubmenu);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            openChildForm(new FormThongTin());
            //nút bấm submenu

            hideSubmenu();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new RePass());
            hideSubmenu();
            //nút bấm submenu
            hideSubmenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
    //        control.Disconnect();
            Close();
            //nút bấm submenu
            hideSubmenu();
        }
#endregion
        #region DanhMuc
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            showSubmenu(panelDMSubmenu);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new FormNCC());
            //nút bấm submenu
            hideSubmenu();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm( new FormKhachhang());
            //nút bấm submenu
            hideSubmenu();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm( new HangHoa());
            //nút bấm submenu
            hideSubmenu();

        }

        private void btnSub7_Click(object sender, EventArgs e)
        {
            openChildForm( new FormNhanVien());
            //nút bấm submenu
            hideSubmenu();

        }
#endregion
        #region Baocao
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            showSubmenu(panelBCSubmenu);
        }


        private void button17_Click(object sender, EventArgs e)
        {
            openChildForm(new FormBaoCao()); 
            //nút bấm submenu
            hideSubmenu();

        }
#endregion
        #region Timkiem
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            openChildForm( new TimKiemHD());
            hideSubmenu();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            openChildForm( new FormHoadon());
            //nút bấm submenu
            hideSubmenu();

        }
#endregion
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

    }
}
