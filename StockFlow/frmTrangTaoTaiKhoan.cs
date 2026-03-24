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
        public frmTrangTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTrangChu f = new frmTrangChu();
            f.ShowDialog();
            this.Show();
        }
    }
}
