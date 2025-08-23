using System;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Card
{
    public partial class AddsCard : Guna2Panel
    {
        private Addon addon;
        private Dish dish;
        public event EventHandler purchaseQuantityChanged;
        public AddsCard(Addon addon, Dish dish)
        {
            InitializeComponent();
            this.addon = addon;
            this.dish = dish;
            FillColor = Color.FromArgb(255, 255, 255);
            BackColor = Color.Transparent;
            BorderRadius = 5;

            name.Text = addon.MenuName;
            price.Text = "₱ " + addon.MenuPrice.ToString();
            image.Image = addon.Image;
            if (addon.CurrentlyMaxOrder > 0)
            {
                qtyy.Minimum = 1;
                qtyy.Maximum = addon.CurrentlyMaxOrder;
            }
            else
            {
                qtyy.Enabled = false;
            }
        }


        private void QuantityButton(object sender, EventArgs e)
        {
            var existing = dish.AddsOnPurchase.Find(a => a.Adds_id == addon.Adds_id);
            int i = (int)qtyy.Value;
            int max = Math.Min(i, addon.CurrentlyMaxOrder);

            if (existing != null)
            {
                existing.Purchase_Qty += max;
            }
            else
            {
                addon.Purchase_Qty = max;
                dish.AddOnPurchase(addon);
            }
            addon.CurrentlyMaxOrder -= max;

            if (addon.CurrentlyMaxOrder > 0)
            {
                qtyy.Value = 1;
            }
            else
            {
                qtyy.Enabled = false;
            }
            purchaseQuantityChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
