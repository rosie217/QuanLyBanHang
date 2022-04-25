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
    public partial class TimKiemHD : Form
    {
        DataTable tblHDB;
        public TimKiemHD()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TimKiemHD_Load(object sender, EventArgs e)
        {
            control.Connect();
            ResetValues();
            dgvTKHoaDon.DataSource = null;

        }
        private void ResetValues()
        {
            foreach (TextBox Ctl in this.Controls.OfType<TextBox>())
            {
                Ctl.Text = "";
            }
            txtMaHDBan.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadDataGridView()
        {

            dgvTKHoaDon.Columns[0].HeaderText = "Mã HĐB";
            dgvTKHoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dgvTKHoaDon.Columns[2].HeaderText = "Ngày bán";
            dgvTKHoaDon.Columns[3].HeaderText = "Mã khách hàng";
            dgvTKHoaDon.Columns[4].HeaderText = "Tổng tiền";
            dgvTKHoaDon.Columns[0].Width = 150;
            dgvTKHoaDon.Columns[1].Width = 100;
            dgvTKHoaDon.Columns[2].Width = 100;
            dgvTKHoaDon.Columns[3].Width = 150;
            dgvTKHoaDon.Columns[4].Width = 200;
            dgvTKHoaDon.AllowUserToAddRows = false;
            dgvTKHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            string sql;
            if ((txtMaHDBan.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtMaNhanVien.Text == "") && (txtMaKhach.Text == "") &&
               (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HDBan WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND MaHDban Like N'%" + txtMaHDBan.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(Ngayban) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(Ngayban) =" + txtNam.Text;
            if (txtMaNhanVien.Text != "")
                sql = sql + " AND Manhanvien Like N'%" + txtMaNhanVien.Text + "%'";
            if (txtMaKhach.Text != "")
                sql = sql + " AND Makhach Like N'%" + txtMaKhach.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongTien.Text;
            tblHDB = control.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTKHoaDon.DataSource = tblHDB;
            LoadDataGridView();
        }
        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }
        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvTKHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvTKHoaDon.CurrentRow.Cells["MaHDban"].Value.ToString();
                FormHoadon frm = new FormHoadon();
                frm.txtMaHDBan.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }



    }
}
