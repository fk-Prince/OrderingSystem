namespace OrderingSystem.KioskApp.Card
{
    partial class AddsCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddsCard));
            this.image = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.add = new Guna.UI2.WinForms.Guna2PictureBox();
            this.qtyy = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyy)).BeginInit();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.Transparent;
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.Location = new System.Drawing.Point(4, 12);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(118, 98);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.name.Location = new System.Drawing.Point(128, 7);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(175, 31);
            this.name.TabIndex = 8;
            this.name.Text = "label1";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.price.Location = new System.Drawing.Point(206, 53);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(77, 20);
            this.price.TabIndex = 9;
            this.price.Text = "0.00";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Transparent;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.Image = global::OrderingSystem.Properties.Resources.add;
            this.add.ImageRotate = 0F;
            this.add.Location = new System.Drawing.Point(182, 82);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(42, 30);
            this.add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.add.TabIndex = 5;
            this.add.TabStop = false;
            this.add.Click += new System.EventHandler(this.QuantityButton);
            // 
            // qtyy
            // 
            this.qtyy.BackColor = System.Drawing.Color.Transparent;
            this.qtyy.BorderRadius = 5;
            this.qtyy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.qtyy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.qtyy.Location = new System.Drawing.Point(229, 78);
            this.qtyy.Name = "qtyy";
            this.qtyy.Size = new System.Drawing.Size(69, 36);
            this.qtyy.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(139, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Price  ₱";
            // 
            // AddsCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(311, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qtyy);
            this.Controls.Add(this.price);
            this.Controls.Add(this.name);
            this.Controls.Add(this.add);
            this.Controls.Add(this.image);
            this.Name = "AddsCard";
            this.Text = "AddsCard";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label price;
        private Guna.UI2.WinForms.Guna2PictureBox add;
        private Guna.UI2.WinForms.Guna2NumericUpDown qtyy;
        private System.Windows.Forms.Label label1;
    }
}