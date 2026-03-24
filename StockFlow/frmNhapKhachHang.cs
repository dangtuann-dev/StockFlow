using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockFlow
{
    public partial class frmNhapKhachHang : Form
    {
        string conString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=StockFlowDb;Integrated Security=True";
        public frmNhapKhachHang()
        {
            InitializeComponent();

        }
        private void btnSave2_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();
                    string sql = "INSERT INTO CUSTOMERS (Name) VALUES (@name); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                        object result = cmd.ExecuteScalar();
                         if (result != null && int.TryParse(result.ToString(), out int newName))
                        {
                           
                            MessageBox.Show("Thêm thành công! Name: " + newName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            

            string name = txtCustomerName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();
                   
                    MessageBox.Show("Chức năng Cập nhật yêu cầu CustomerName. Vui lòng chọn bản ghi để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // --- NÚT XÓA TRẮNG (CLEAR) ---
        private void btnClear2_Click(object sender, EventArgs e)
        { 
            txtCustomerName.Clear();
        }
        private void btnX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
