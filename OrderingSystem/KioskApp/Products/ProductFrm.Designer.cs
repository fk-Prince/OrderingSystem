namespace OrderingSystem.KioskApp.Products
{
    partial class ProductFrm
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.flowCat = new System.Windows.Forms.FlowLayoutPanel();
            this.spinner = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.t = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.search);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.spinner);
            this.guna2Panel1.Controls.Add(this.flowPanel);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(795, 727);
            this.guna2Panel1.TabIndex = 0;
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
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Location = new System.Drawing.Point(12, 69);
            this.search.Name = "search";
            this.search.PlaceholderText = "";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(512, 36);
            this.search.TabIndex = 3;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.Controls.Add(this.flowCat);
            this.guna2Panel2.Location = new System.Drawing.Point(11, 111);
            this.guna2Panel2.MaximumSize = new System.Drawing.Size(1920, 65);
            this.guna2Panel2.MinimumSize = new System.Drawing.Size(784, 65);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(784, 65);
            this.guna2Panel2.TabIndex = 1;
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
            // 
            // spinner
            // 
            this.spinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinner.CircleSize = 3F;
            this.spinner.Location = new System.Drawing.Point(352, 322);
            this.spinner.MaximumSize = new System.Drawing.Size(91, 83);
            this.spinner.MinimumSize = new System.Drawing.Size(91, 83);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(91, 83);
            this.spinner.TabIndex = 2;
            // 
            // flowPanel
            // 
            this.flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Location = new System.Drawing.Point(0, 178);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(10);
            this.flowPanel.MinimumSize = new System.Drawing.Size(796, 546);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanel.Size = new System.Drawing.Size(796, 546);
            this.flowPanel.TabIndex = 1;
            // 
            // t
            // 
            this.t.Interval = 500;
            this.t.Tick += new System.EventHandler(this.t_Tick);
            // 
            // ProductFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(795, 727);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(795, 727);
            this.Name = "ProductFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductFrm";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator spinner;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.FlowLayoutPanel flowCat;
        private System.Windows.Forms.Timer t;
        private Guna.UI2.WinForms.Guna2TextBox search;
    }
}