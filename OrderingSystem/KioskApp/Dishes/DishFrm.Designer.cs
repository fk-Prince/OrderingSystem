namespace OrderingSystem.KioskApp
{
    partial class DishFrm
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
            this.components = new System.ComponentModel.Container();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.spinner = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.flowCat = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.t = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowPanel
            // 
            this.flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Location = new System.Drawing.Point(0, 181);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(10);
            this.flowPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowPanel.MinimumSize = new System.Drawing.Size(796, 546);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanel.Size = new System.Drawing.Size(796, 546);
            this.flowPanel.TabIndex = 0;
            // 
            // spinner
            // 
            this.spinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinner.CircleSize = 3F;
            this.spinner.Location = new System.Drawing.Point(350, 321);
            this.spinner.MaximumSize = new System.Drawing.Size(91, 83);
            this.spinner.MinimumSize = new System.Drawing.Size(91, 83);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(91, 83);
            this.spinner.TabIndex = 1;
            // 
            // flowCat
            // 
            this.flowCat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowCat.AutoScroll = true;
            this.flowCat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowCat.Location = new System.Drawing.Point(0, 1);
            this.flowCat.MaximumSize = new System.Drawing.Size(1920, 81);
            this.flowCat.MinimumSize = new System.Drawing.Size(784, 81);
            this.flowCat.Name = "flowCat";
            this.flowCat.Size = new System.Drawing.Size(784, 81);
            this.flowCat.TabIndex = 2;
            this.flowCat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseClick);
            this.flowCat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseDown);
            this.flowCat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseMove);
            this.flowCat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseUp);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.Controls.Add(this.flowCat);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 116);
            this.guna2Panel1.MaximumSize = new System.Drawing.Size(1920, 65);
            this.guna2Panel1.MinimumSize = new System.Drawing.Size(784, 65);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(784, 65);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseClick);
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseDown);
            this.guna2Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseMove);
            this.guna2Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.flowCat_MouseUp);
            // 
            // search
            // 
            this.search.BorderRadius = 5;
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Location = new System.Drawing.Point(12, 75);
            this.search.Name = "search";
            this.search.PlaceholderText = "ex. Beef Steak";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(512, 36);
            this.search.TabIndex = 2;
            this.search.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // t
            // 
            this.t.Interval = 500;
            this.t.Tick += new System.EventHandler(this.t_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Menu";
            // 
            // DishFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(795, 727);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.spinner);
            this.Controls.Add(this.flowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(795, 727);
            this.Name = "DishFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.DishFrm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator spinner;
        private System.Windows.Forms.FlowLayoutPanel flowCat;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox search;
        private System.Windows.Forms.Timer t;
        private System.Windows.Forms.Label label1;
    }
}