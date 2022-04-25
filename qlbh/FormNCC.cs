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
    public partial class FormNCC : Form
    {
        DataTable tblNCC;
        public FormNCC()
        {
            InitializeComponent();
        }

        private void FormNCC_Load(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;
            buttonLuu.Enabled = false;
            buttonBQ.Enabled = false;
            LoadDataGridView();
        }
        #region load datagridview
        private void LoadDataGridView()
        {
            control.Connect();
            string sql;
            sql = "SELECT MaNCC, TenNCC FROM NhaCC";
            tblNCC = control.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvNCC.DataSource = tblNCC; //Nguồn dữ liệu            
            dgvNCC.Columns[0].HeaderText = " Mã Nhà Cung Cấp";
            dgvNCC.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvNCC.Columns[0].Width = 350;
            dgvNCC.Columns[1].Width = 350;
            dgvNCC.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        #endregion
        #region click vào datagridview để đưa dữ liệu lên
        private void dgvNCC_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (tblNCC.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNCC.Text = dgvNCC.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNCC.CurrentRow.Cells["TenNCC"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            buttonBQ.Enabled = true;
        }
        #endregion
        #region reset val
        private void ResetValues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
        }
        #endregion
        #region nút lưu
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaNCC.Text.Trim().Length == 0) //Nếu chưa nhập mã nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0) //Nếu chưa nhập tên nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
                return;
            }
            sql = "Select MaNCC From NhaCC where MaNCC=N'" + txtMaNCC.Text.Trim() + "'";
            if (control.CheckKey(sql))
            {
                MessageBox.Show("Mã NCC này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }


            sql = "INSERT INTO NhaCC VALUES(N'" + txtMaNCC.Text + "',N'" + txtTenNCC.Text + "');";
            // sql = "INSERT INTO Khach VALUES(N'KH16',NQUYETQQ',N'ĐÂSASĐA',N'099089876');";
            //sql = "INSERT INTO Khach VALUES(N'" + txtMaKhachHang.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChi.Text + "')";
            control.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            buttonBQ.Enabled = false;
            buttonLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }
        #endregion
        #region nút thêm
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            buttonBQ.Enabled = true;
            buttonLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues(); //Xoá trắng các textbox
            txtMaNCC.Enabled = true; //cho phép nhập mới
            txtTenNCC.Focus();
        }
        #endregion
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaNCC.Text.Trim().Length == 0) //Nếu chưa nhập mã nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0) //Nếu chưa nhập tên nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
                return;
            }
            sql = "Select MaNCC From tblNCC where MaNCC=N'" + txtMaNCC.Text.Trim() + "'";
            if (control.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }

            sql = "INSERT INTO NhaCC VALUES(N'" +
                txtMaNCC.Text + "',N'" + txtTenNCC.Text + "')";
            control.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            buttonBQ.Enabled = false;
            buttonLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }
        #region NÚT SỬA
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0) //nếu chưa nhập tên nhà cung cấp
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NhaCC SET TenNCC=N'" +
                txtTenNCC.Text.ToString() +
                "' WHERE MaNCC=N'" + txtMaNCC.Text + "'";
            control.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            buttonBQ.Enabled = false;
        }
        #endregion
        #region nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NhaCC WHERE MaNCC=N'" + txtMaNCC.Text + "'";
                control.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }
        #endregion
        #region bỏ qua
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            buttonBQ.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            buttonLuu.Enabled = false;
            txtMaNCC.Enabled = false;
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
