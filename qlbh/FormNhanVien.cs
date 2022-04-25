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
    public partial class FormNhanVien : Form
    {
        DataTable tblNV; //Lưu dữ liệu bảng nhân viên
        public FormNhanVien()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }
        #region load datagridview 
        private void LoadDataGridView()
        {
            control.Connect();
            string sql;
            sql = "SELECT Manhanvien, Tennhanvien, Gioitinh, Diachi, Dienthoai, Ngaysinh FROM Nhanvien";//lấy dữ liệu từ bảng
            tblNV = control.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvNhanVien.DataSource = tblNV; //Nguồn dữ liệu            
            dgvNhanVien.Columns[0].HeaderText = " Mã Nhân Viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvNhanVien.Columns[3].HeaderText = "Địa Chỉ";
            dgvNhanVien.Columns[4].HeaderText = "Điện Thoại";
            dgvNhanVien.Columns[5].HeaderText = "Ngày Sinh";
            dgvNhanVien.Columns[0].Width = 100;
            dgvNhanVien.Columns[1].Width = 200;
            dgvNhanVien.Columns[2].Width = 200;
            dgvNhanVien.Columns[3].Width = 200;
            dgvNhanVien.Columns[4].Width = 200;
            dgvNhanVien.Columns[5].Width = 200;

            dgvNhanVien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        #endregion
        #region lấy dgv từ bảng
        //phương thức dgvNhanVien_click để lấy dữ liệu từ bảng
        private void dgvNhanVien_Click_1(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["Manhanvien"].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells["Tennhanvien"].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam") chkGioiTinh.Checked = true;
            else chkGioiTinh.Checked = false;
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["Diachi"].Value.ToString();
            mtbDienThoai.Text = dgvNhanVien.CurrentRow.Cells["Dienthoai"].Value.ToString();
            mskNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["Ngaysinh"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }
        #endregion
        #region nút thêm dữ liệu vào bảng

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMaNhanVien.Enabled = true;
            txtMaNhanVien.Focus();
        }
        #endregion
        #region reset giá trị
        private void ResetValue()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            chkGioiTinh.Checked = false;
            txtDiaChi.Text = "";
            mtbDienThoai.Text = "";
            mskNgaySinh.Text = "";
        }
#endregion
        #region btn lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            //KIỂM tra mã nhân viên tồn tại
            sql = "SELECT Manhanvien FROM Nhanvien WHERE Manhanvien=N'" + txtMaNhanVien.Text.Trim() + "'";
            if (control.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                txtMaNhanVien.Text = "";
                return;
            }
            sql = "INSERT INTO Nhanvien(Manhanvien, Tennhanvien, Gioitinh, Diachi, Dienthoai, Ngaysinh) VALUES (N'" + txtMaNhanVien.Text.Trim() + "',N'" + txtTenNhanVien.Text.Trim() + "',N'" + gt + "',N'" + txtDiaChi.Text.Trim() + "','" + mtbDienThoai.Text + "','" + control.ConvertDateTime(mskNgaySinh.Text) + "')";
            control.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNhanVien.Enabled = false;
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
        #region sửa dữ liệu
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            //cập nhật dữ liệu
            sql = "UPDATE Nhanvien SET  Tennhanvien=N'" + txtTenNhanVien.Text.Trim().ToString() +
                    "',Diachi=N'" + txtDiaChi.Text.Trim().ToString() +
                    "',Dienthoai='" + mtbDienThoai.Text.ToString() + "',Gioitinh=N'" + gt +
                    "',Ngaysinh='" + control.ConvertDateTime(mskNgaySinh.Text) +
                    "' WHERE Manhanvien=N'" + txtMaNhanVien.Text + "'";//phải có where để tránh cập nhật tất cả bản ghi với gt giống nhhau
            control.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
        }
        #endregion
        #region xóa dữ liệu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Nhanvien WHERE Manhanvien=N'" + txtMaNhanVien.Text + "'";
                control.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }
        #endregion
        #region bỏ qua
        private void btnBoQua_Click(object sender, EventArgs e)
        {

            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNhanVien.Enabled = false;

        }
        #endregion
        #region đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



    }
}
