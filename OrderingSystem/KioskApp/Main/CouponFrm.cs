using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using OrderingSystem.Repositories.Kiosk;

namespace OrderingSystem.KioskApp.Main
{
    public partial class CouponFrm : Guna2Panel
    {
        private ICouponRepository couponRepository;
        public event EventHandler<Coupon> CouponSelected;
        private Coupon currentCoupon;
        private Guna2ProgressIndicator spinner = null;
        private Guna2Button b = null;
        private static CouponFrm instance;

        public CouponFrm(ICouponRepository couponRepository)
        {
            InitializeComponent();
            this.couponRepository = couponRepository;
            BackColor = Color.Transparent;
            BorderColor = Color.FromArgb(34, 34, 34);
            BorderThickness = 1;
            FillColor = Color.White;
            BorderRadius = 10;


            this.Focus();
        }

        public static CouponFrm CouponFrmFactory()
        {
            if (instance == null)
            {
                ICouponRepository couponRepository = new CouponRepository();
                return new CouponFrm(couponRepository);
            }
            else
            {
                return instance;
            }
        }

        private async void guna2Button1_Click(object sender, System.EventArgs e)
        {
            message.Visible = false;
            Guna2Button b = (Guna2Button)sender;
            Guna2ProgressIndicator spinner = new Guna2ProgressIndicator();
            spinner.Size = new Size(35, 37);
            spinner.Location = new Point(
                        (b.Width - spinner.Width) / 2,
                        (b.Height - spinner.Height) / 2
                    );
            b.Controls.Add(spinner);
            spinner.Start();
            t.Start();
            b.Enabled = false;
            b.Text = "";
            this.spinner = spinner;
            this.b = b;
            try
            {
                Coupon c = await couponRepository.GetCoupon(txtCoupon.Text);
                if (currentCoupon != null)
                {
                    message.Text = "You’ve already selected a coupon. If you want to change it, please click gift icon.";
                    message.ForeColor = Color.Red;
                    return;
                }

                if (c != null)
                {

                    if (c.ExpiryDate < DateTime.Now)
                    {
                        message.Text = "Sorry, this coupon has expired.";
                        message.ForeColor = Color.Red;
                    }
                    else
                    {
                        message.Text = "Success! Your coupon is applied.";
                        CouponSelected?.Invoke(this, c);
                        currentCoupon = c;
                        message.ForeColor = Color.Green;
                    }
                }
                else
                {
                    message.Text = "Uh-oh! That coupon code isn’t valid. Please try again.";
                    message.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2PictureBox2_Click(object sender, System.EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (spinner != null && b != null)
            {
                this.Focus();
                txtCoupon.Focus();

                t.Stop();
                message.Visible = true;
                spinner.Stop();
                b.Controls.Remove(spinner);
                spinner.Dispose();
                spinner = null;
                b.Enabled = true;
                b.Text = "Redeem";
                b = null;
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            currentCoupon = null;
            message.Visible = false;
            CouponSelected?.Invoke(this, null);
        }
    }
}
