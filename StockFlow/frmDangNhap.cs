using StockFlow.BLL;
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
    public partial class frmDangNhap : Form
    {
        UserBLL bll = new UserBLL();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged_2(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng
            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!");
                return;
            }

            // 2. Tạo object
            UserDTO user = new UserDTO()
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            // 3. Kiểm tra đăng nhập
            UserDTO result = bll.Login(user);
            if (result != null)
            {
                frmTrangChu f = new frmTrangChu(result);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            frmTrangTaoTaiKhoan f = new frmTrangTaoTaiKhoan();
            f.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
