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
    public partial class Pronduct : Form
    {
        ProductBLL bll = new ProductBLL();
        UserDTO currentUser;

        public Pronduct(UserDTO user)
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);
            currentUser = user;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var list = bll.GetListProduct();
            dgvProducts.Rows.Clear();
            int i = 1;
            foreach (var p in list)
            {
                dgvProducts.Rows.Add(i++, p.ProductID, p.Name, p.Quantity, p.Description);
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        // Nút Add → ProductForm (Form1)
        private void btnAdd_Click_handler(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
            LoadData(); // Reload sau khi thêm
        }

        // Sidebar navigation
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuanLyKhachHang f = new frmQuanLyKhachHang();
            if (f.ShowDialog() == DialogResult.Abort) {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            this.Show();
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

        private void button3_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox5_Click(object sender, EventArgs e) { }
        private void btnLogo_Click(object sender, EventArgs e) 
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        private void btnCategories_Click(object sender, EventArgs e) 
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
        private void btnUsers_Click(object sender, EventArgs e) 
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
        private void pictureBox1_Click(object sender, EventArgs e) 
        { 
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        private void btnProduct_Click(object sender, EventArgs e) { /* đang ở trang này rồi */ }
    }
}
