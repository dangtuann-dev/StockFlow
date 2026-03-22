namespace StockFlow
{
    partial class Pronduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pronduct));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn1 = new System.Windows.Forms.Button();
            this.lblManageProduct = new System.Windows.Forms.Label();
            this.btnX = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.picCustomer = new System.Windows.Forms.PictureBox();
            this.picUsers = new System.Windows.Forms.PictureBox();
            this.picOrders = new System.Windows.Forms.PictureBox();
            this.picCategories = new System.Windows.Forms.PictureBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(107, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(112, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "StockFlow";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, -3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 84);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.btn1);
            this.panel2.Controls.Add(this.lblManageProduct);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 470);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 40);
            this.panel2.TabIndex = 2;
            // 
            // btn1
            // 
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.BackColor = System.Drawing.Color.Aqua;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(755, 4);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(31, 33);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "+";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // lblManageProduct
            // 
            this.lblManageProduct.AutoSize = true;
            this.lblManageProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageProduct.Location = new System.Drawing.Point(12, 15);
            this.lblManageProduct.Name = "lblManageProduct";
            this.lblManageProduct.Size = new System.Drawing.Size(120, 16);
            this.lblManageProduct.TabIndex = 0;
            this.lblManageProduct.Text = "Manage Product";
            // 
            // btnX
            // 
            this.btnX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX.BackColor = System.Drawing.Color.Red;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(767, -3);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(23, 23);
            this.btnX.TabIndex = 3;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            // 
            // btnProduct
            // 
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProduct.Location = new System.Drawing.Point(325, 58);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(83, 23);
            this.btnProduct.TabIndex = 4;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.Location = new System.Drawing.Point(414, 58);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(83, 23);
            this.btnCustomer.TabIndex = 5;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.Location = new System.Drawing.Point(503, 58);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(83, 23);
            this.btnCategories.TabIndex = 6;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Location = new System.Drawing.Point(592, 58);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(83, 23);
            this.btnUsers.TabIndex = 7;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnOrders
            // 
            this.btnOrders.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Location = new System.Drawing.Point(681, 58);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(83, 23);
            this.btnOrders.TabIndex = 8;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            // 
            // picProduct
            // 
            this.picProduct.Image = ((System.Drawing.Image)(resources.GetObject("picProduct.Image")));
            this.picProduct.Location = new System.Drawing.Point(342, 12);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(53, 50);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProduct.TabIndex = 9;
            this.picProduct.TabStop = false;
            this.picProduct.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picCustomer
            // 
            this.picCustomer.Image = ((System.Drawing.Image)(resources.GetObject("picCustomer.Image")));
            this.picCustomer.Location = new System.Drawing.Point(428, 12);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.Size = new System.Drawing.Size(53, 50);
            this.picCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCustomer.TabIndex = 10;
            this.picCustomer.TabStop = false;
            // 
            // picUsers
            // 
            this.picUsers.Image = ((System.Drawing.Image)(resources.GetObject("picUsers.Image")));
            this.picUsers.Location = new System.Drawing.Point(604, 12);
            this.picUsers.Name = "picUsers";
            this.picUsers.Size = new System.Drawing.Size(53, 50);
            this.picUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUsers.TabIndex = 11;
            this.picUsers.TabStop = false;
            this.picUsers.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picOrders
            // 
            this.picOrders.Image = ((System.Drawing.Image)(resources.GetObject("picOrders.Image")));
            this.picOrders.Location = new System.Drawing.Point(695, 12);
            this.picOrders.Name = "picOrders";
            this.picOrders.Size = new System.Drawing.Size(53, 50);
            this.picOrders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOrders.TabIndex = 12;
            this.picOrders.TabStop = false;
            this.picOrders.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picCategories
            // 
            this.picCategories.Image = ((System.Drawing.Image)(resources.GetObject("picCategories.Image")));
            this.picCategories.Location = new System.Drawing.Point(517, 12);
            this.picCategories.Name = "picCategories";
            this.picCategories.Size = new System.Drawing.Size(53, 50);
            this.picCategories.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCategories.TabIndex = 13;
            this.picCategories.TabStop = false;
            this.picCategories.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colProductId,
            this.colName,
            this.colQuantity,
            this.colDescription});
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.Location = new System.Drawing.Point(1, 87);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(785, 382);
            this.dgvProducts.TabIndex = 14;
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // colNo
            // 
            this.colNo.HeaderText = "No.";
            this.colNo.MinimumWidth = 6;
            this.colNo.Name = "colNo";
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "Product ID";
            this.colProductId.MinimumWidth = 6;
            this.colProductId.Name = "colProductId";
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Description";
            this.colDescription.MinimumWidth = 6;
            this.colDescription.Name = "colDescription";
            // 
            // Pronduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 510);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.picCategories);
            this.Controls.Add(this.picOrders);
            this.Controls.Add(this.picUsers);
            this.Controls.Add(this.picCustomer);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pronduct";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lblManageProduct;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.PictureBox picCustomer;
        private System.Windows.Forms.PictureBox picUsers;
        private System.Windows.Forms.PictureBox picOrders;
        private System.Windows.Forms.PictureBox picCategories;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}