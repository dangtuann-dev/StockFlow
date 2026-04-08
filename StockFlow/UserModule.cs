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
    public partial class UserModule : Form
    {
        UserBLL bll = new UserBLL();

        public UserModule()
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDTO user = new UserDTO
            {
                UserName = txtUserName.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Password = txtPassWord.Text.Trim(),
                Phone    = txtPhone.Text.Trim(),
                Role     = "staff"
            };

            if (bll.Register(user))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Username đã tồn tại hoặc có lỗi xảy ra!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng nhập Username cần cập nhật!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDTO user = new UserDTO
            {
                UserName = txtUserName.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Password = txtPassWord.Text.Trim(),
                Phone    = txtPhone.Text.Trim()
            };

            if (bll.Update(user))
            {
                MessageBox.Show("Cập nhật thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại! Kiểm tra lại Username.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPassWord.Clear();
            txtPhone.Clear();
            txtUserName.Focus();
        }
    }
}
