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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

        }

        // Chuyển trang 
        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyDanhMuc f = new frmQuanLyDanhMuc();
            f.ShowDialog();
            this.Show();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyKhachHang f = new frmQuanLyKhachHang();
            f.ShowDialog();
            this.Show();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
