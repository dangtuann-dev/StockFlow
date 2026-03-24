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
    public partial class frmQuanLyDanhMuc : Form
    {
        ProductBLL bll = new ProductBLL();
        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

       
        private void frmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            dgvDanhMuc.DataSource = bll.GetListProduct();

            // Tùy chỉnh tiêu đề cột
            dgvDanhMuc.Columns["ProductID"].HeaderText = "Mã SP";
            dgvDanhMuc.Columns["Name"].HeaderText = "Tên Sản Phẩm";
            dgvDanhMuc.Columns["Quantity"].HeaderText = "Số lượng";
            dgvDanhMuc.Columns["Description"].HeaderText = "Mô tả";
            dgvDanhMuc.Columns["CategoryID"].HeaderText = "ID hàng";

        }

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhapDanhMuc f = new frmNhapDanhMuc();
            f.ShowDialog();
            this.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyDanhMuc f = new frmQuanLyDanhMuc();
            f.ShowDialog();
            this.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyKhachHang f = new frmQuanLyKhachHang();
            f.ShowDialog();
            this.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTrangChu f = new frmTrangChu();
            f.ShowDialog();
            this.Show();
        }
    }
}
