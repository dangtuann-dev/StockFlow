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
    public partial class frmTrangTaoTaiKhoan : Form
    {
        UserBLL bll = new UserBLL();
        public frmTrangTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassWord.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Không được để trống!");
                return;
            }

            UserDTO user = new UserDTO()
            {
                UserName = txtUserName.Text,
                Password = txtPassWord.Text,
                Phone = txtPhone.Text,
                Role = "staff"
            };

            if (bll.Register(user))
            {
                MessageBox.Show("Tạo tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO()
            {
                UserName = txtUserName.Text,
                Password = txtPassWord.Text,
                Phone = txtPhone.Text
            };

            if (bll.Update(user))
            {
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassWord.Clear();
            txtPhone.Clear();

            txtUserName.Focus();
        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = '*';
        }
    }
}
