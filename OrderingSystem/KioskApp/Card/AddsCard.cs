using System;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Card
{
    public partial class AddsCard : Guna2Panel
    {
        private Addon x;
        private Dish m;
        public event EventHandler xxc;
        public AddsCard(Addon x, Dish m)
        {
            InitializeComponent();
            this.x = x;
            this.m = m;
            FillColor = Color.FromArgb(255, 255, 255);
            BackColor = Color.Transparent;
            BorderRadius = 5;
            //max.Text = x.CurrentlyMaxOrder.ToString();
            //qty.Text = 0.ToString();
            name.Text = x.MenuName;
            price.Text = "₱ " + x.MenuPrice.ToString();

            if (x.CurrentlyMaxOrder > 0)
            {
                qtyy.Minimum = 1;
                qtyy.Maximum = x.CurrentlyMaxOrder;
            }
            else
            {
                qtyy.Enabled = false;
            }
            max.Text = x.CurrentlyMaxOrder.ToString();
        }


        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            var existing = m.AddsOnPurchase.Find(a => a.Adds_id == x.Adds_id);
            int i = (int)qtyy.Value;
            int max = Math.Min(i, x.CurrentlyMaxOrder);

            if (existing != null)
            {
                existing.Purchase_Qty += max;
            }
            else
            {
                x.Purchase_Qty = max;
                m.AddOnPurchase(x);
            }
            x.CurrentlyMaxOrder -= max;

            if (x.CurrentlyMaxOrder > 0)
            {
                qtyy.Value = 1;
            }
            else
            {
                qtyy.Enabled = false;
            }
            this.max.Text = x.CurrentlyMaxOrder.ToString();

            //Control p1 = this.Parent;
            //Control p2 = p1.Parent;
            //Control p3 = p2?.Parent;
            //if (p3 != null && p2 != null)
            //{
            //    p3.Controls.Remove(p2);
            //}
            xxc?.Invoke(this, EventArgs.Empty);
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void max_Click(object sender, System.EventArgs e)
        {

        }
    }
}
