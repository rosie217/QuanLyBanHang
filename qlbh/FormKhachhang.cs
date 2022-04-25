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
    public partial class FormKhachhang : Form
    {
        DataTable tblKH;////Chứa dữ liệu bảng khách hàng
        public FormKhachhang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void FormKhachhang_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            buttonLuu.Enabled = false;
            buttonBQ.Enabled = false;
        }
        #region load datagridview
        private void LoadDataGridView() {
            control.Connect();
            string sql;
            sql = "SELECT Makhach, Tenkhach, Diachi, Dienthoai FROM Khach";
            tblKH = control.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvKhachHang.DataSource = tblKH; //Nguồn dữ liệu            
            dgvKhachHang.Columns[0].HeaderText = " Mã Khách Hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = " Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 200;
            dgvKhachHang.Columns[2].Width = 200;
            dgvKhachHang.Columns[3].Width = 200;
            dgvKhachHang.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
 
        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region click vào datagridview để đưa dữ liệu lên
        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhachHang.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKhachHang.Text = dgvKhachHang.CurrentRow.Cells["Makhach"].Value.ToString();
            txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["Tenkhach"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtbDienThoai.Text = dgvKhachHang.CurrentRow.Cells["Dienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            buttonBQ.Enabled = true;
        }
        #endregion

        #region nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            buttonBQ.Enabled = true;
            buttonLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaKhachHang.Enabled = true; //cho phép nhập mới
            txtMaKhachHang.Focus();
        }
        private void ResetValue()
        {
            txtMaKhachHang.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            mtbDienThoai.Text = "";
        }
        #endregion

        #region nút lưu
        private void button4_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaKhachHang.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhachHang.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            sql = "Select Makhach From Khach where Makhach=N'" + txtMaKhachHang.Text.Trim() + "'";
            if (control.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhachHang.Focus();
                return;
            }
            txtDiaChi.Focus();
            mtbDienThoai.Focus();
            sql = "INSERT INTO Khach VALUES(N'" + txtMaKhachHang.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChi.Text + "',N'" + mtbDienThoai.Text + "');";
           // sql = "INSERT INTO Khach VALUES(N'KH16',NQUYETQQ',N'ĐÂSASĐA',N'099089876');";
            //sql = "INSERT INTO Khach VALUES(N'" + txtMaKhachHang.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChi.Text + "')";
            control.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            buttonBQ.Enabled = false;
            buttonLuu.Enabled = false;
            txtMaKhachHang.Enabled = false;
        }
        #endregion

        #region cấm nhập chữ
        private void mtbDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.checkNumber(sender, e);
        }

        private void checkNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region sửa đổi dữ liệu trừ trường mã KH
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhachHang.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE Khach SET Tenkhach=N'" + txtTenKH.Text.ToString() + "',Diachi=N'" +
                txtDiaChi.Text.Trim().ToString() + "',Dienthoai='" + mtbDienThoai.Text.ToString() + "' WHERE Makhach=N'" + txtMaKhachHang.Text + "'";
            control.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            buttonBQ.Enabled = false;
        }
        #endregion

        #region xóa dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Khach WHERE Makhach=N'" + txtMaKhachHang.Text + "'";
                control.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }
        #endregion

        #region bỏ qua 
        private void buttonBQ_Click(object sender, EventArgs e)
        {
            ResetValue();
            buttonBQ.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaKhach.Enabled = false;

        }
        #endregion

        #region đóng
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion close

        // phương thức dùng enter thay tab
        private void txtMaKhach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }


    }
}
