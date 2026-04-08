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
    public partial class Users : Form
    {
        UserBLL bll = new UserBLL();
        UserDTO currentUser;

        public Users(UserDTO user)
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);
            currentUser = user;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = bll.GetUserDTOs();
            dgvUsers.Rows.Clear();
            int i = 1;
            foreach (var u in list)
            {
                dgvUsers.Rows.Add(i++, u.UserName, u.FullName);
            }
        }

        // Nút Add → UserModule
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModule f = new UserModule();
            f.ShowDialog();
            LoadData();
        }

        // Nút X → đóng
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sidebar navigation
        private void button1_Click_1(object sender, EventArgs e)
        {
            // btnProduct → Pronduct
            this.Hide();
            Pronduct f = new Pronduct(currentUser);
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // btnCustomer → frmQuanLyKhachHang
            this.Hide();
            frmQuanLyKhachHang f = new frmQuanLyKhachHang();
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            // Categories
            this.Hide();
            frmQuanLyDanhMuc f = new frmQuanLyDanhMuc();
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // btnUsers – đang ở đây
        }

        private void btnOrders_Click(object sender, EventArgs e)
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

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void btnLogo_Click(object sender, EventArgs e) 
        { 
            this.DialogResult = DialogResult.Abort;
            this.Close(); 
        }
        private void picLogo_Click(object sender, EventArgs e) 
        { 
            this.DialogResult = DialogResult.Abort;
            this.Close(); 
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void picLogo_Click_1(object sender, EventArgs e) 
        { 
            this.DialogResult = DialogResult.Abort;
            this.Close(); 
        }
        private void btnProduct_Click(object sender, EventArgs e) { }
        private void pictureBox4_Click(object sender, EventArgs e) { }
    }
}
