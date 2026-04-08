using System.Drawing;
using System.Windows.Forms;
using System;

namespace StockFlow
{
    public static class UIHelper
    {
        public static void StandardizeForm(Form form)
        {
            // Các form chính đưa về kích thước 1100x700.
            int targetWidth = 1100;
            int targetHeight = 700;
            
            // Xử lý riêng biệt với các form nhỏ
            if (form.Name == "frmNhapKhachHang" || form.Name == "frmNhapDanhMuc" || form.Name == "UserModule" || form.Name == "Form1")
            {
                targetWidth = 800;
                targetHeight = 500;
            }

            if (form.Width != targetWidth || form.Height != targetHeight)
            {
                float scaleX = (float)targetWidth / form.Width;
                float scaleY = (float)targetHeight / form.Height;
                float minScale = Math.Min(scaleX, scaleY);

                form.Scale(new SizeF(scaleX, scaleY));
                ScaleControls(form, minScale);

                form.Width = targetWidth;
                form.Height = targetHeight;
            }
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        private static void ScaleControls(Control parent, float scale)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Font != null)
                {
                    c.Font = new Font(c.Font.FontFamily, c.Font.Size * (scale * 0.95f), c.Font.Style);
                }
                
                if (c is PictureBox pb)
                {
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                }
                
                if (c.HasChildren)
                {
                    ScaleControls(c, scale);
                }
            }
        }
    }
}
