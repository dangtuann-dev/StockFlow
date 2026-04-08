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
    public partial class frmDatHang : Form
    {
        OrderBLL orderBLL = new OrderBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        ProductBLL productBLL = new ProductBLL();

        List<CustomerDTO> customerList = new List<CustomerDTO>();
        List<ProductDTO> productList   = new List<ProductDTO>();

        // OrderDetailID đang chọn để Update (0 = chưa chọn)
        int selectedOrderDetailId = 0;

        public frmDatHang()
        {
            InitializeComponent();
            UIHelper.StandardizeForm(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void frmDatHang_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadProducts();
            LoadOrdersView();
            txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        // ─── LOAD DATA ───────────────────────────────────────────────

        private void LoadCustomers()
        {
            customerList = customerBLL.GetAllCustomers();
            dgvCustomer.DataSource = null;
            dgvCustomer.DataSource = customerList;
            if (dgvCustomer.Columns.Count > 0)
            {
                dgvCustomer.Columns["CustomerID"].HeaderText = "ID";
                dgvCustomer.Columns["Name"].HeaderText       = "Tên khách hàng";
            }
        }

        private void LoadProducts()
        {
            productList = productBLL.GetListProduct();
        }

        private void LoadOrdersView()
        {
            dgvOrder.DataSource = orderBLL.GetOrdersView();
        }

        // ─── SEARCH ──────────────────────────────────────────────────

        private void txtLeftSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtLeftSearch.Text.Trim().ToLower();
            dgvCustomer.DataSource = customerList
                .Where(c => c.Name.ToLower().Contains(kw) || c.CustomerID.ToString().Contains(kw))
                .ToList();
        }

        private void txtRightSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtRightSearch.Text.Trim().ToLower();
            var filtered = productList.Where(p => p.Name.ToLower().Contains(kw) || p.ProductID.ToString().Contains(kw)).ToList();
            // Hiển thị gợi ý vào txtProductId / txtProductName nếu chỉ còn 1 kết quả
            if (filtered.Count == 1)
            {
                txtProductId.Text   = filtered[0].ProductID.ToString();
                txtProductName.Text = filtered[0].Name;
            }
        }

        // ─── SELECT từ dgvCustomer ────────────────────────────────────
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                txtCustomerId.Text   = dgvCustomer.Rows[e.RowIndex].Cells["CustomerID"].Value?.ToString();
                txtCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells["Name"].Value?.ToString();
            }
            catch { }
        }

        // ─── ORDER INSERT ─────────────────────────────────────────────

        private void btnOrderInsert_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int custId) || custId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtProductId.Text, out int prodId) || prodId <= 0)
            {
                MessageBox.Show("Vui lòng nhập Product ID!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtTotal.Text, out decimal total) || total < 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newOrderId = orderBLL.PlaceOrder(custId, prodId, qty, total);
            if (newOrderId > 0)
            {
                MessageBox.Show($"Đặt hàng thành công! Order ID: {newOrderId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadOrdersView();
            }
            else
            {
                MessageBox.Show("Đặt hàng thất bại. Kiểm tra lại dữ liệu hoặc kết nối DB.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── ORDER UPDATE ─────────────────────────────────────────────

        private void btnOrderUpdate_Click(object sender, EventArgs e)
        {
            if (selectedOrderDetailId <= 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng đơn hàng để cập nhật!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtTotal.Text, out decimal total) || total < 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OrderDetailDTO detail = new OrderDetailDTO
            {
                OrderDetailID = selectedOrderDetailId,
                Qty   = qty,
                Total = total
            };

            if (orderBLL.UpdateDetail(detail))
            {
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadOrdersView();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── CLICK TRÊN dgvOrder để chọn dòng cần update ─────────────
        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = dgvOrder.Rows[e.RowIndex];
                txtCustomerId.Text   = row.Cells["CustomerID"].Value?.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value?.ToString();
                txtProductId.Text    = row.Cells["ProductID"].Value?.ToString();
                txtProductName.Text  = row.Cells["ProductName"].Value?.ToString();
                txtQty.Text          = row.Cells["Qty"].Value?.ToString();
                txtTotal.Text        = row.Cells["Total"].Value?.ToString();
                txtOrderDate.Text    = row.Cells["OrderDate"].Value?.ToString();

                // Lấy detail id nếu có (dùng cho Update)
                try
                {
                    string val = row.Cells["OrderDetailID"].Value?.ToString();
                    int.TryParse(val, out selectedOrderDetailId);
                }
                catch { selectedOrderDetailId = 0; }
            }
            catch { }
        }

        // ─── CLEAR ───────────────────────────────────────────────────

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCustomerId.Text   = "";
            txtCustomerName.Text = "";
            txtProductId.Text    = "";
            txtProductName.Text  = "";
            txtQty.Text          = "";
            txtTotal.Text        = "";
            txtOrderDate.Text    = DateTime.Now.ToString("yyyy-MM-dd");
            txtLeftSearch.Text   = "";
            txtRightSearch.Text  = "";
            selectedOrderDetailId = 0;
            LoadCustomers(); // reset filter
        }

        // ─── HOME ─────────────────────────────────────────────────────

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        // ─── CLOSE ────────────────────────────────────────────────────

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}
