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
    public partial class frmNhapDanhMuc : Form
    {
        // Sửa lại chuỗi kết nối chuẩn (đảm bảo Server Name của bạn đúng)
        string conString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=StockFlowDb;Integrated Security=True";

        public frmNhapDanhMuc()
        {
            InitializeComponent();
        }

        // --- NÚT LƯU (SAVE) ---
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();

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
                    string sql = "INSERT INTO CATEGORIES (Name) VALUES (@name); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            txtCategoryId.Text = newId.ToString();
                            MessageBox.Show("Thêm thành công! ID: " + newId, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // --- NÚT CẬP NHẬT (UPDATE) ---
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                MessageBox.Show("Vui lòng nhập ID cần sửa!");
                return;
            }

            if (!int.TryParse(txtCategoryId.Text.Trim(), out int id))
            {
                MessageBox.Show("ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCategoryName.Text.Trim();
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
                    string sql = "UPDATE CATEGORIES SET Name = @name WHERE CategoryID = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0) MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Không tìm thấy ID này!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // --- NÚT XÓA TRẮNG (CLEAR) ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategoryId.Clear();
            txtCategoryName.Clear();
        }

        // --- NÚT X (THOÁT) ---
        private void btnX_Click(object sender, EventArgs e)
        {
          this.Close();
        } 
    }
}








