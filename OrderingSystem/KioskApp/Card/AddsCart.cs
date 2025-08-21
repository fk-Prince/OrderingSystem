using System;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Card
{
    public partial class AddsCart : Guna2Panel
    {
        public event EventHandler RemoveAddson;
        public event EventHandler ReduceQty;
        public event EventHandler AddQty;
        private Addon a;

        public Addon Addon => a;
        public AddsCart(Addon a)
        {
            InitializeComponent();
            this.a = a;
            price.Text = a.MenuPrice.ToString("N2");
            name.Text = a.MenuName;
            qty.Text = a.Purchase_Qty.ToString();
            xx.Text = a.Purchase_Qty.ToString();
            total.Text = (a.MenuPrice * a.Purchase_Qty).ToString("N2");

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            RemoveAddson?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddQty?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ReduceQty?.Invoke(this, EventArgs.Empty);
        }

        public void updateText()
        {
            price.Text = a.MenuPrice.ToString("N2");
            name.Text = a.MenuName;
            qty.Text = a.Purchase_Qty.ToString();
            xx.Text = a.Purchase_Qty.ToString();
            total.Text = (a.MenuPrice * a.Purchase_Qty).ToString("N2");
        }

        private void img_Click(object sender, EventArgs e)
        {

        }
    }
}
