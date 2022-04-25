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
    public partial class HangHoa : Form
    {
        DataTable tblHangHoa;
        public HangHoa()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        #region load hanghoa
        private void HangHoa_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from NhaCC";
            LoadDataGridView();
            txtHang.Enabled = false;
            buttonLuu.Enabled = false;
            buttonBQ.Enabled = false;
            LoadDataGridView();
            control.FillCombo(sql, cboMaNCC, "MaNCC", "TenNCC");
            cboMaNCC.SelectedIndex = -1;
            ResetValues();
        }
        #endregion
        #region resetvalues
        private void ResetValues()
        {
            txtHang.Text = "";
            txtTenHang.Text = "";
            cboMaNCC.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Text = "";
            ptAnh.Image = null;
            txtGhiChu.Text = "";
        }
        #endregion
        //load datagridview

        #region load datagridview
        private void LoadDataGridView()
        {
            control.Connect();
            string sql;
            sql = "SELECT * FROM Hang";
            tblHangHoa = control.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvHangHoa.DataSource = tblHangHoa; //Nguồn dữ liệu            
            dgvHangHoa.Columns[0].HeaderText = " Mã Hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên Hàng";
            dgvHangHoa.Columns[2].HeaderText = "Mã NCC";
            dgvHangHoa.Columns[3].HeaderText = "Số Lượng";
            dgvHangHoa.Columns[4].HeaderText = "Đơn Gía Nhập";
            dgvHangHoa.Columns[5].HeaderText = "Đơn Gía Bán";
            dgvHangHoa.Columns[6].HeaderText = "Ảnh";
            dgvHangHoa.Columns[7].HeaderText = "Ghi Chú";
            dgvHangHoa.Columns[0].Width = 100;
            dgvHangHoa.Columns[1].Width = 200;
            dgvHangHoa.Columns[2].Width = 200;
            dgvHangHoa.Columns[3].Width = 200;
            dgvHangHoa.Columns[4].Width = 200;
            dgvHangHoa.Columns[5].Width = 200;
            dgvHangHoa.Columns[6].Width = 200;
            dgvHangHoa.Columns[7].Width = 200;
            dgvHangHoa.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        #endregion
        #region click vào datagridview để đưa dữ liệu lên + thêm mới
        private void dgvHangHoa_Click(object sender, EventArgs e)
        {
            string MaNCC;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHang.Focus();
                return;
            }
            if (tblHangHoa.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtHang.Text = dgvHangHoa.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenHang.Text = dgvHangHoa.CurrentRow.Cells["Tenhang"].Value.ToString();
            //cboMaNCC.Text = dgvHangHoa.CurrentRow.Cells["MaNCC"].Value.ToString();

            MaNCC = dgvHangHoa.CurrentRow.Cells["MaNCC"].Value.ToString();
            sql = "SELECT TenNCC FROM NhaCC WHERE MaNCC=N'" + MaNCC + "'";  
            cboMaNCC.Text = control.GetFieldValues(sql);

            txtSoLuong.Text = dgvHangHoa.CurrentRow.Cells["Soluong"].Value.ToString();
            txtDonGiaNhap.Text = dgvHangHoa.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtDonGiaBan.Text = dgvHangHoa.CurrentRow.Cells["Dongiaban"].Value.ToString();
            sql = "SELECT Anh FROM Hang WHERE Mahang=N'" + txtHang.Text + "'";
            txtAnh.Text = control.GetFieldValues(sql);
            ptAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT Ghichu FROM Hang WHERE MaHang = N'" + txtHang.Text + "'";
            txtGhiChu.Text = control.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            buttonBQ.Enabled = true;
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
            txtHang.Enabled = true; //cho phép nhập mới
            txtHang.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
        }
        #endregion
        #region nút lưu
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã nhà CC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMoAnh.Focus();
                return;
            }
            sql = "SELECT Mahang FROM Hang WHERE MaHang=N'" + txtHang.Text.Trim() + "'";
            if (control.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHang.Focus();
                return;
            }

            sql = "INSERT INTO Hang VALUES(N'" + txtHang.Text.Trim() + "',N'" + txtTenHang.Text.Trim() + "',N'" + cboMaNCC.SelectedValue.ToString() + "',N'" + txtSoLuong.Text + "','" + txtDonGiaNhap.Text + "','" + txtDonGiaBan.Text + "',N'" + txtAnh.Text + "',N'" + txtGhiChu.Text + "');";
            // sql = "INSERT INTO Khach VALUES(N'KH16',NQUYETQQ',N'ĐÂSASĐA',N'099089876');";
            //sql = "INSERT INTO Khach VALUES(N'" + txtMaKhachHang.Text + "',N'" + txtTenKH.Text + "',N'" + txtDiaChi.Text + "')";
            control.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            buttonBQ.Enabled = false;
            buttonLuu.Enabled = false;
            txtHang.Enabled = false;
        }
        #endregion
        #region nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Hang WHERE Mahang=N'" + txtHang.Text + "'";
                control.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }
        #endregion
        #region nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHang.Focus();
                return;
            }
            if (txtTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHang.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà CC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE Hang SET Tenhang=N'" + txtTenHang.Text.Trim().ToString() +
                "',MaNCC=N'" + cboMaNCC.SelectedValue.ToString() +
                "',Soluong=" + txtSoLuong.Text +
                ",Anh='" + txtAnh.Text + "',Ghichu=N'" + txtGhiChu.Text + "' WHERE Mahang=N'" + txtHang.Text + "'";
            control.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            buttonBQ.Enabled = false;
        }
#endregion
        #region chọn ảnh từu file
        private void btnMoAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();//tạo dialog
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";//thiết lập điều kiện lọc
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)//nếu ok thì node ảnh lên
            {
                ptAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;//nạp vào txxt ảnh
            }
        }
        #endregion

        #region bỏ qua sự kiện
        private void buttonBQ_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            buttonBQ.Enabled = false;
            buttonLuu.Enabled = false;
            txtHang.Enabled = false;
        }
#endregion

        #region nút  tìm kiếm hàng hóa
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string sql;
            if ((txtHang.Text == "") && (txtTenHang.Text == "") && (cboMaNCC.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from Hang WHERE 1=1";
            if (txtHang.Text != "")
                sql += " AND Mahang LIKE N'%" + txtHang.Text + "%'";
            if (txtTenHang.Text != "")
                sql += " AND Tenhang LIKE N'%" + txtTenHang.Text + "%'";
            if (cboMaNCC.Text != "")
                sql += " AND MaNCC LIKE N'%" + cboMaNCC.SelectedValue + "%'";
            tblHangHoa = control.GetDataToTable(sql);
            if (tblHangHoa.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblHangHoa.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHangHoa.DataSource = tblHangHoa;
            ResetValues();
        }
        #endregion

        #region hiển thị lại
        private void btnHienThi_Click_1(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM Hang";
            tblHangHoa = control.GetDataToTable(sql);
            dgvHangHoa.DataSource = tblHangHoa;
        }
        #endregion

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAnh_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
