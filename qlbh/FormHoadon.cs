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
using COMExcel = Microsoft.Office.Interop.Excel;


namespace qlbh
{
    public partial class FormHoadon : Form
    {
        DataTable tblCTHDB; //Bảng chi tiết hoá đơn bán
        public FormHoadon()
        {
            control.Connect();
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHoadon_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnInHoaDon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtTenKhach.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaBan.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            control.FillCombo("SELECT Makhach, Tenkhach FROM Khach", cboMaKhach, "Makhach", "Makhach");
            cboMaKhach.SelectedIndex = -1;
            control.FillCombo("SELECT Manhanvien, Tennhanvien FROM Nhanvien", cboMaNhanVien, "Manhanvien", "Manhanvien");
            cboMaNhanVien.SelectedIndex = -1;
            control.FillCombo("SELECT Mahang, Tenhang FROM Hang", cboMaHang, "Mahang", "Mahang");
            cboMaHang.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadDataGridView();
        }
        //private void LoadDataGridView()

       //}
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.Mahang, b.Tenhang, a.Soluong, b.Dongiaban, a.Giamgia,a.Thanhtien FROM ChitietHDban AS a, Hang AS b WHERE a.MaHDban = N'" + txtMaHDBan.Text + "' AND a.Mahang=b.Mahang";
            tblCTHDB = control.GetDataToTable(sql);
            dgvHDBanHang.DataSource = tblCTHDB;
            dgvHDBanHang.Columns[0].HeaderText = "Mã hàng";
            dgvHDBanHang.Columns[1].HeaderText = "Tên hàng";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Giảm giá %";
            dgvHDBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvHDBanHang.Columns[0].Width = 150;
            dgvHDBanHang.Columns[1].Width = 250;
            dgvHDBanHang.Columns[2].Width = 120;
            dgvHDBanHang.Columns[3].Width = 190;
            dgvHDBanHang.Columns[4].Width = 190;
            dgvHDBanHang.Columns[5].Width = 200;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT Ngayban FROM HDBan WHERE MaHDban = N'" + txtMaHDBan.Text + "'";
            txtNgayBan.Text = control.GetFieldValues(str);
            str = "SELECT Manhanvien FROM HDBan WHERE MaHDban = N'" + txtMaHDBan.Text + "'";
            cboMaNhanVien.SelectedValue = control.GetFieldValues(str);
            str = "SELECT Makhach FROM HDBan WHERE MaHDban = N'" + txtMaHDBan.Text + "'";
            cboMaKhach.SelectedValue = control.GetFieldValues(str);
            str = "SELECT Tongtien FROM HDBan WHERE MaHDban = N'" + txtMaHDBan.Text + "'";
            txtTongTien.Text = control.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + control.ChuyenSoSangChuoi(Double.Parse(txtTongTien.Text));
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThem.Enabled = false;
            txtMaHDBan.ReadOnly = false;
            ResetValues();
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            txtNgayBan.Text = DateTime.Now.ToShortDateString();
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }


        //lưu hóa đơn
        private void btnLuu_Click(object sender, EventArgs e)
         {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDban FROM HDBan WHERE MaHDban=N'" + txtMaHDBan.Text + "'";
            if (!control.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayBan.Focus();
                    return;
                }
                if (cboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (cboMaKhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString(txtNgayBan.Text.Trim());

                sql = "INSERT INTO HDBan(MaHDban, Ngayban, Manhanvien, Makhach, Tongtien) VALUES (N'" + txtMaHDBan.Text + "','" + sqlFormattedDate + "',N'" + cboMaNhanVien.SelectedValue + "',N'" +
                       cboMaKhach.SelectedValue + "'," + txtTongTien.Text + ")";

                try
                {
                    control.RunSQL(sql);
                }
                catch (Exception){
                    MessageBox.Show("Không thể thực hiện câu lệnh này !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            // Lưu thông tin của các mặt hàng
            if (cboMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            sql = "SELECT Mahang FROM ChitietHDban WHERE Mahang=N'" + cboMaHang.SelectedValue + "' AND MaHDban = N'" + txtMaHDBan.Text.Trim() + "'";
            if (control.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaHang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(control.GetFieldValues("SELECT Soluong FROM Hang WHERE Mahang = N'" + cboMaHang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO ChitietHDban(MaHDban,Mahang,Soluong,Dongia, Giamgia,Thanhtien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMaHang.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGiaBan.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            control.RunSQL(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
            sql = "UPDATE Hang SET Soluong =" + SLcon + " WHERE Mahang= N'" + cboMaHang.SelectedValue + "'";
            control.RunSQL(sql);

            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(control.GetFieldValues("SELECT Tongtien FROM HDBan WHERE MaHDban = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            sql = "UPDATE HDBan SET Tongtien =" + Tongmoi + " WHERE MaHDban = N'" + txtMaHDBan.Text + "'";
            control.RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();
            lblBangChu.Text = "Bằng chữ: " + control.ChuyenSoSangChuoi(Double.Parse(Tongmoi.ToString()));

            ResetValuesHang();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnInHoaDon.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNhanVien.Text == "")
                txtTenNhanVien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select Tennhanvien from Nhanvien where Manhanvien =N'" + cboMaNhanVien.SelectedValue + "'";
            txtTenNhanVien.Text = control.GetFieldValues(str);
        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaHang.Text == "")
            {
                txtTenHang.Text = "";
                txtDonGiaBan.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT Tenhang FROM Hang WHERE Mahang =N'" + cboMaHang.SelectedValue + "'";
            txtTenHang.Text = control.GetFieldValues(str);
            str = "SELECT Dongiaban FROM Hang WHERE Mahang =N'" + cboMaHang.SelectedValue + "'";
            txtDonGiaBan.Text = control.GetFieldValues(str);
        }

        private void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKhach.Text == "")
            {
                txtTenKhach.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select Tenkhach from Khach where Makhach = N'" + cboMaKhach.SelectedValue + "'";
            txtTenKhach.Text = control.GetFieldValues(str);
            str = "Select Diachi from Khach where Makhach = N'" + cboMaKhach.SelectedValue + "'";
            txtDiaChi.Text = control.GetFieldValues(str);
            str = "Select Dienthoai from Khach where Makhach= N'" + cboMaKhach.SelectedValue + "'";
            txtDienThoai.Text = control.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            control.FillCombo("SELECT MaHDban FROM HDBan", cboMaHDBan, "MaHDban", "MaHDban");
            cboMaHDBan.SelectedIndex = -1;
        }
        #region tìm kiếm
        private void button1_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }
        #endregion

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }
        #region in hóa đơn
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT Mahang,Soluong FROM ChitietHDban WHERE MaHDban = N'" + txtMaHDBan.Text + "'";
                DataTable tblHang = control.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(control.GetFieldValues("SELECT Soluong FROM Hang WHERE Mahang = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE Hang SET Soluong =" + slcon + " WHERE Mahang= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    control.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE ChitietHDban WHERE MaHDban=N'" + txtMaHDBan.Text + "'";
                control.RunSQL(sql);

                //Xóa hóa đơn
                sql = "DELETE HDBan WHERE MaHDban=N'" + txtMaHDBan.Text + "'";
                control.RunSQL(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
                btnInHoaDon.Enabled = false;
            }
        }
        #endregion
        #region double click clear
        private void dgvHDBanHang_DoubleClick(object sender, EventArgs e)
        {
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dgvHDBanHang.CurrentRow.Cells["Mahang"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["Soluong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["Thanhtien"].Value.ToString());
                sql = "DELETE ChitietHDban WHERE MaHDban=N'" + txtMaHDBan.Text + "' AND Mahang = N'" + MaHangxoa + "'";
                control.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(control.GetFieldValues("SELECT Soluong FROM Hang WHERE Mahang = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE Hang SET Soluong =" + slcon + " WHERE Mahang= N'" + MaHangxoa + "'";
                control.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(control.GetFieldValues("SELECT Tongtien FROM HDBan WHERE MaHDban = N'" + txtMaHDBan.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE HDBan SET Tongtien =" + tongmoi + " WHERE MaHDban = N'" + txtMaHDBan.Text + "'";
                control.RunSQL(sql);
                txtTongTien.Text = tongmoi.ToString();
                lblBangChu.Text = "Bằng chữ: " + control.ChuyenSoSangChuoi(Double.Parse(tongmoi.ToString()));
                LoadDataGridView();
            }
        }
        #endregion

    }
}
