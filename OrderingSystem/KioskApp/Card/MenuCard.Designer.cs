namespace OrderingSystem.KioskApp.Card
{
    partial class MenuCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCard));
            this.quantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.outStock = new Guna.UI2.WinForms.Guna2PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.max = new System.Windows.Forms.Label();
            this.maxlabel = new System.Windows.Forms.Label();
            this.desc = new System.Windows.Forms.Label();
            this.st = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.st.SuspendLayout();
            this.SuspendLayout();
            // 
            // quantity
            // 
            this.quantity.BackColor = System.Drawing.Color.Transparent;
            this.quantity.BorderRadius = 5;
            this.quantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quantity.Location = new System.Drawing.Point(172, 17);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(63, 32);
            this.quantity.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Price";
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(65, 25);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(66, 17);
            this.price.TabIndex = 2;
            this.price.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "₱";
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.Transparent;
            this.image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.image.BorderRadius = 10;
            this.image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(0, 0);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(250, 105);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 4;
            this.image.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.outStock);
            this.guna2Panel1.Controls.Add(this.image);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(250, 105);
            this.guna2Panel1.TabIndex = 5;
            // 
            // outStock
            // 
            this.outStock.BackColor = System.Drawing.Color.Transparent;
            this.outStock.BorderRadius = 50;
            this.outStock.FillColor = System.Drawing.Color.Transparent;
            this.outStock.Image = ((System.Drawing.Image)(resources.GetObject("outStock.Image")));
            this.outStock.ImageRotate = 0F;
            this.outStock.Location = new System.Drawing.Point(-3, 3);
            this.outStock.MinimumSize = new System.Drawing.Size(184, 56);
            this.outStock.Name = "outStock";
            this.outStock.Size = new System.Drawing.Size(250, 107);
            this.outStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outStock.TabIndex = 13;
            this.outStock.TabStop = false;
            this.outStock.UseTransparentBackground = true;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(0, 105);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(248, 52);
            this.name.TabIndex = 6;
            this.name.Text = "label4\r\nvasd\r\n";
            this.name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::OrderingSystem.Properties.Resources.add;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(139, 18);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(28, 28);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 7;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.Click += new System.EventHandler(this.AddItem);
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.BackColor = System.Drawing.Color.Transparent;
            this.max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max.Location = new System.Drawing.Point(203, 1);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(38, 15);
            this.max.TabIndex = 8;
            this.max.Text = "label2";
            this.max.Visible = false;
            // 
            // maxlabel
            // 
            this.maxlabel.AutoSize = true;
            this.maxlabel.BackColor = System.Drawing.Color.Transparent;
            this.maxlabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxlabel.Location = new System.Drawing.Point(173, 1);
            this.maxlabel.Name = "maxlabel";
            this.maxlabel.Size = new System.Drawing.Size(33, 15);
            this.maxlabel.TabIndex = 9;
            this.maxlabel.Text = "Max:";
            this.maxlabel.Visible = false;
            // 
            // desc
            // 
            this.desc.BackColor = System.Drawing.Color.Transparent;
            this.desc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.desc.Location = new System.Drawing.Point(22, 153);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(200, 46);
            this.desc.TabIndex = 10;
            this.desc.Text = "asd\r\nasd\r\nasd";
            this.desc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // st
            // 
            this.st.BackColor = System.Drawing.Color.Transparent;
            this.st.Controls.Add(this.price);
            this.st.Controls.Add(this.quantity);
            this.st.Controls.Add(this.label1);
            this.st.Controls.Add(this.label3);
            this.st.Controls.Add(this.max);
            this.st.Controls.Add(this.guna2PictureBox2);
            this.st.Controls.Add(this.maxlabel);
            this.st.Location = new System.Drawing.Point(0, 201);
            this.st.MaximumSize = new System.Drawing.Size(247, 59);
            this.st.MinimumSize = new System.Drawing.Size(247, 59);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(247, 59);
            this.st.TabIndex = 5;
            // 
            // MenuCard
            // 
            this.ClientSize = new System.Drawing.Size(246, 262);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.st);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.name);
            this.Name = "MenuCard";
            this.Text = "MenuCard";
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.st.ResumeLayout(false);
            this.st.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2NumericUpDown quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label name;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label maxlabel;
        public System.Windows.Forms.Label max;
        private System.Windows.Forms.Label desc;
        private Guna.UI2.WinForms.Guna2Panel st;
        private Guna.UI2.WinForms.Guna2PictureBox outStock;
    }
}