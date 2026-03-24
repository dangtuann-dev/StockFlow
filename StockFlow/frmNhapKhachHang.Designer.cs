namespace StockFlow
{
    partial class frmNhapKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapKhachHang));
            this.pnlCustomerModule = new System.Windows.Forms.Panel();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.lblCustomerModule = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.btnUpdate2 = new System.Windows.Forms.Button();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.pnlCustomerModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCustomerModule
            // 
            this.pnlCustomerModule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(181)))), ((int)(((byte)(234)))));
            this.pnlCustomerModule.Controls.Add(this.btnDelete2);
            this.pnlCustomerModule.Controls.Add(this.lblCustomerModule);
            this.pnlCustomerModule.Location = new System.Drawing.Point(3, 1);
            this.pnlCustomerModule.Name = "pnlCustomerModule";
            this.pnlCustomerModule.Size = new System.Drawing.Size(1402, 121);
            this.pnlCustomerModule.TabIndex = 0;
            // 
            // btnDelete2
            // 
            this.btnDelete2.FlatAppearance.BorderSize = 0;
            this.btnDelete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete2.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete2.Image")));
            this.btnDelete2.Location = new System.Drawing.Point(1349, 3);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(50, 51);
            this.btnDelete2.TabIndex = 1;
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // lblCustomerModule
            // 
            this.lblCustomerModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerModule.Location = new System.Drawing.Point(37, 49);
            this.lblCustomerModule.Name = "lblCustomerModule";
            this.lblCustomerModule.Size = new System.Drawing.Size(365, 39);
            this.lblCustomerModule.TabIndex = 0;
            this.lblCustomerModule.Text = "CUSTOMER MODULE";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(104, 189);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(281, 47);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Customer Name :";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(205)))), ((int)(((byte)(244)))));
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(403, 186);
            this.txtCustomerName.Multiline = true;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(827, 50);
            this.txtCustomerName.TabIndex = 2;
            // 
            // btnSave2
            // 
            this.btnSave2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(185)))), ((int)(((byte)(245)))));
            this.btnSave2.FlatAppearance.BorderSize = 2;
            this.btnSave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSave2.Location = new System.Drawing.Point(403, 330);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(171, 53);
            this.btnSave2.TabIndex = 5;
            this.btnSave2.Text = "SAVE";
            this.btnSave2.UseVisualStyleBackColor = false;
            // 
            // btnUpdate2
            // 
            this.btnUpdate2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(133)))), ((int)(((byte)(232)))));
            this.btnUpdate2.FlatAppearance.BorderSize = 2;
            this.btnUpdate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnUpdate2.Location = new System.Drawing.Point(717, 330);
            this.btnUpdate2.Name = "btnUpdate2";
            this.btnUpdate2.Size = new System.Drawing.Size(171, 53);
            this.btnUpdate2.TabIndex = 6;
            this.btnUpdate2.Text = "UPDATE";
            this.btnUpdate2.UseVisualStyleBackColor = false;
            // 
            // btnClear2
            // 
            this.btnClear2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear2.FlatAppearance.BorderSize = 2;
            this.btnClear2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnClear2.Location = new System.Drawing.Point(1059, 330);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(171, 53);
            this.btnClear2.TabIndex = 7;
            this.btnClear2.Text = "CLEAR";
            this.btnClear2.UseVisualStyleBackColor = false;
            // 
            // frmNhapKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 629);
            this.Controls.Add(this.btnClear2);
            this.Controls.Add(this.btnUpdate2);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.pnlCustomerModule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNhapKhachHang";
            this.Text = "frmNhapDanhMuc";
            this.pnlCustomerModule.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCustomerModule;
        private System.Windows.Forms.Label lblCustomerModule;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.Button btnUpdate2;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnDelete2;
    }
}