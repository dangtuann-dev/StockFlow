using StockFlow.DTO;
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
        UserDTO currentUser;
        public frmTrangChu(UserDTO user)
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);
            currentUser = user;
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            PhanQuyen(currentUser);
        }

        void PhanQuyen(UserDTO user)
        {
            if (user == null || string.IsNullOrEmpty(user.Role))
            {
                MessageBox.Show("Không xác định quyền!");
                return;
            }

            string role = user.Role.Trim().ToLower();

            switch (role)
            {
                case "admin":
                    break;

                case "manager":
                    btnUsers.Visible = false;
                    break;

                case "staff":
                    btnProduct.Visible = false;
                    btnCategories.Visible = false;
                    btnUsers.Visible = false;
                    break;

                case "warehouse":
                    btnCustomer.Visible = false;
                    btnUsers.Visible = false;
                    break;

                default:
                    MessageBox.Show("Không xác định quyền!");
                    break;
            }
        }

        // Pronduct – Quản lý sản phẩm
        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pronduct f = new Pronduct(currentUser);
            f.ShowDialog();
            this.Show();
        }

        // frmQuanLyDanhMuc – Quản lý danh mục
        private void btnCategories_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyDanhMuc f = new frmQuanLyDanhMuc();
            f.ShowDialog();
            this.Show();
        }

        // frmQuanLyKhachHang – Quản lý khách hàng
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyKhachHang f = new frmQuanLyKhachHang();
            f.ShowDialog();
            this.Show();
        }

        // Users – Quản lý tài khoản
        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users f = new Users(currentUser);
            f.ShowDialog();
            this.Show();
        }

        // frmDatHang – Đặt hàng
        private void btnOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDatHang f = new frmDatHang();
            f.ShowDialog();
            this.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmTrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
