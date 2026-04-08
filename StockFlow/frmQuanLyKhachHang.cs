using StockFlow.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockFlow
{
    public partial class frmQuanLyKhachHang : Form
    {
        UserBLL userBLL = new UserBLL();
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);
        }
        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = userBLL.GetUserDTOs();

            // Tùy chỉnh tiêu đề cột
            dgvKhachHang.Columns["UserID"].HeaderText = "ID Khach hang";
            dgvKhachHang.Columns["UserName"].HeaderText = "Tên Khach hang";
            dgvKhachHang.Columns["FullName"].HeaderText = "Tên đầy đủ";

            dgvKhachHang.Columns["Password"].Visible = false;
            // Hiển thị cột đã mã hóa
            dgvKhachHang.Columns["DisplayPassword"].HeaderText = "Mật khẩu";
            dgvKhachHang.Columns["DisplayPassword"].DisplayIndex = 3;

            dgvKhachHang.Columns["Phone"].HeaderText = "SĐT";
            dgvKhachHang.Columns["Role"].HeaderText = "Quyền";
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhapKhachHang f = new frmNhapKhachHang();
            f.ShowDialog();
            this.Show();
        }

        private void btnProduct2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pronduct f = new Pronduct(null);
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
        }

        private void btnUsers2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users f = new Users(null);
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
        }

        private void btnHome2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        private void picBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        private void btnCategories2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyDanhMuc f = new frmQuanLyDanhMuc();
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
        }
        private void btnOrders2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDatHang f = new frmDatHang();
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
        }
    }
}
