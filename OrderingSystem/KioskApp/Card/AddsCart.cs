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
        private Addon addon;

        public Addon Addon => addon;
        public AddsCart(Addon addon)
        {
            InitializeComponent();
            this.addon = addon;
            price.Text = addon.MenuPrice.ToString("N2");
            name.Text = addon.MenuName;
            qty.Text = addon.Purchase_Qty.ToString();
            totalQty.Text = addon.Purchase_Qty.ToString();
            total.Text = (addon.MenuPrice * addon.Purchase_Qty).ToString("N2");
        }

        private void RemoveAddonCart(object sender, EventArgs e)
        {
            RemoveAddson?.Invoke(this, EventArgs.Empty);
        }

        private void AddQuantity(object sender, EventArgs e)
        {
            AddQty?.Invoke(this, EventArgs.Empty);
        }

        private void ReduceQuantity(object sender, EventArgs e)
        {
            ReduceQty?.Invoke(this, EventArgs.Empty);
        }

        public void updateText()
        {
            price.Text = addon.MenuPrice.ToString("N2");
            name.Text = addon.MenuName;
            qty.Text = addon.Purchase_Qty.ToString();
            totalQty.Text = addon.Purchase_Qty.ToString();
            total.Text = (addon.MenuPrice * addon.Purchase_Qty).ToString("N2");
        }

    }
}
