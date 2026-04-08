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
    public partial class Form1 : Form
    {
        ProductBLL bll = new ProductBLL();

        public Form1()
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Không cần load - đây là form thêm/sửa sản phẩm
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        // SAVE – Thêm sản phẩm mới
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQty.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int catId = 1; // Mặc định CategoryID = 1 nếu không có dropdown
            if (!string.IsNullOrWhiteSpace(txtCategory.Text) &&
                int.TryParse(txtCategory.Text, out int parsedCat))
                catId = parsedCat;

            ProductDTO p = new ProductDTO
            {
                Name        = txtProductName.Text.Trim(),
                Quantity    = qty,
                Description = txtDesc.Text.Trim(),
                CategoryID  = catId
            };

            if (bll.Add(p))
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CLEAR
        private void ClearFields()
        {
            txtProductName.Clear();
            txtQty.Clear();
            txtDesc.Clear();
            txtCategory.Clear();
            txtProductName.Focus();
        }

        // btnX – Đóng form
        private void btnX_handler(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
