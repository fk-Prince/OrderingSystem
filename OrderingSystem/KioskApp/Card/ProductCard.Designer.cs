namespace OrderingSystem.KioskApp.Card
{
    partial class ProductCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCard));
            this.quantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.name = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.max = new System.Windows.Forms.Label();
            this.maxlabel = new System.Windows.Forms.Label();
            this.vList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.desc = new System.Windows.Forms.Label();
            this.outStock = new Guna.UI2.WinForms.Guna2PictureBox();
            this.st = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outStock)).BeginInit();
            this.st.SuspendLayout();
            this.SuspendLayout();
            // 
            // quantity
            // 
            this.quantity.BackColor = System.Drawing.Color.Transparent;
            this.quantity.BorderRadius = 5;
            this.quantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.quantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quantity.Location = new System.Drawing.Point(173, 17);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(63, 32);
            this.quantity.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Price";
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(71, 33);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(53, 17);
            this.price.TabIndex = 2;
            this.price.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(50, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "₱";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2PictureBox1.BorderRadius = 10;
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(247, 107);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, -1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(247, 107);
            this.guna2Panel1.TabIndex = 5;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.name.Location = new System.Drawing.Point(0, 108);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(248, 38);
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
            this.guna2PictureBox2.Location = new System.Drawing.Point(140, 19);
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
            this.max.Location = new System.Drawing.Point(198, 0);
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
            this.maxlabel.Location = new System.Drawing.Point(168, 0);
            this.maxlabel.Name = "maxlabel";
            this.maxlabel.Size = new System.Drawing.Size(33, 15);
            this.maxlabel.TabIndex = 9;
            this.maxlabel.Text = "Max:";
            this.maxlabel.Visible = false;
            // 
            // vList
            // 
            this.vList.BackColor = System.Drawing.Color.Transparent;
            this.vList.BorderRadius = 5;
            this.vList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.vList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vList.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.vList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.vList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.vList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.vList.ItemHeight = 20;
            this.vList.Location = new System.Drawing.Point(9, 3);
            this.vList.Name = "vList";
            this.vList.Size = new System.Drawing.Size(114, 26);
            this.vList.TabIndex = 10;
            this.vList.SelectedIndexChanged += new System.EventHandler(this.VariantSelector);
            // 
            // desc
            // 
            this.desc.BackColor = System.Drawing.Color.Transparent;
            this.desc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.Location = new System.Drawing.Point(28, 153);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(187, 30);
            this.desc.TabIndex = 11;
            this.desc.Text = "label2";
            this.desc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // outStock
            // 
            this.outStock.BackColor = System.Drawing.Color.Transparent;
            this.outStock.BorderRadius = 50;
            this.outStock.FillColor = System.Drawing.Color.Transparent;
            this.outStock.Image = ((System.Drawing.Image)(resources.GetObject("outStock.Image")));
            this.outStock.ImageRotate = 0F;
            this.outStock.Location = new System.Drawing.Point(1, 1);
            this.outStock.Name = "outStock";
            this.outStock.Size = new System.Drawing.Size(250, 107);
            this.outStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outStock.TabIndex = 12;
            this.outStock.TabStop = false;
            this.outStock.UseTransparentBackground = true;
            // 
            // st
            // 
            this.st.BackColor = System.Drawing.Color.Transparent;
            this.st.Controls.Add(this.price);
            this.st.Controls.Add(this.vList);
            this.st.Controls.Add(this.maxlabel);
            this.st.Controls.Add(this.quantity);
            this.st.Controls.Add(this.guna2PictureBox2);
            this.st.Controls.Add(this.max);
            this.st.Controls.Add(this.label1);
            this.st.Controls.Add(this.label3);
            this.st.Location = new System.Drawing.Point(0, 197);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(244, 64);
            this.st.TabIndex = 12;
            // 
            // ProductCard
            // 
            this.ClientSize = new System.Drawing.Size(246, 262);
            this.Controls.Add(this.name);
            this.Controls.Add(this.st);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.outStock);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ProductCard";
            this.Text = "ProductCard";
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outStock)).EndInit();
            this.st.ResumeLayout(false);
            this.st.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2NumericUpDown quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label name;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label maxlabel;
        public System.Windows.Forms.Label max;
        private Guna.UI2.WinForms.Guna2ComboBox vList;
        private System.Windows.Forms.Label desc;
        private Guna.UI2.WinForms.Guna2PictureBox outStock;
        private Guna.UI2.WinForms.Guna2Panel st;
    }
}