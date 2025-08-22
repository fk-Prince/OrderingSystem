using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using Dish = OrderingSystem.Model.Dish;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApp.Card
{
    public partial class CartCard : Guna2Panel
    {

        public Menu Item => item;
        private Panel panel;
        public event EventHandler NoQuantity;
        public event EventHandler QuantityChanged;
        public event EventHandler TotalChanged;
        private Menu item;
        private int baseHeight;
        private List<Menu> cartList;
        private bool isVisible = true;

        public CartCard(Panel panel, Menu item, List<Menu> cartList)
        {
            InitializeComponent();
            this.item = item;
            this.cartList = cartList;
            this.baseHeight = this.Height;
            this.panel = panel;


            BorderRadius = 10;
            BorderColor = Color.LightGray;
            FillColor = Color.FromArgb(228, 228, 228);
            BackColor = Color.Transparent;
            BorderThickness = 1;

            if (item is Dish d)
            {
                drop.Visible = true;
                addonButton.Visible = true;
            }
            else
            {
                addonButton.Visible = false;
                drop.Visible = false;
            }
            displayDetails(item);

        }
        private void showAddonButton(object sender, EventArgs e)
        {
            if (item is Dish d)
            {

                AddsFrm x = AddsFrm.AddsFrmFactory(d, cartList);
                x.change += (xe, xr) =>
                {
                    displayShit();
                };
                DialogResult rs = x.ShowDialog(this);
            }
        }
        private void displayShit()
        {

            if (item is Dish d && d.AddsOnPurchase != null && d.AddsOnPurchase.Exists(a => a.Purchase_Qty > 0))
            {
                drop.Visible = true;
                if (isVisible)
                {
                    displayAddsOn();
                }
                else
                {
                    this.Height = baseHeight;
                }
                total.Text = ((item.Purchase_Qty * item.MenuPrice) + d.AddsOnPurchase.Sum(b => b.Purchase_Qty * b.MenuPrice)).ToString("N2");
            }
            else
            {
                total.Top = addlbl.Top;
                pp.Location = new Point(pp.Location.X, total.Bottom + 5);
                addtotal.Visible = false;
                addlbl.Visible = false;
                plbl.Visible = false;
                addtotal.Text = "0.00";
                drop.Visible = false;
                totallbl.Top = addlbl.Top;
                this.Height = baseHeight;
                drop.Visible = false;
                total.Text = (item.Purchase_Qty * item.MenuPrice).ToString("N2");
            }
            TotalChanged?.Invoke(this, EventArgs.Empty);
        }

        private void displayAddsOn()
        {

            if (item is Dish d && d.AddsOnPurchase != null && d.AddsOnPurchase.Exists(a => a.Purchase_Qty > 0))
            {
                drop.Visible = true;
                foreach (Control c in this.Controls.OfType<AddsCart>().ToList())
                {
                    this.Controls.Remove(c);
                }
                foreach (Control c in this.Controls.OfType<Panel>().Where(zx => zx.BackColor == Color.LightGray).ToList())
                {
                    this.Controls.Remove(c);
                }
                Panel p = new Panel();
                p.Width = this.Size.Width - 100;
                p.Height = 2;
                p.BackColor = Color.LightGray;
                p.Location = new Point(50, baseHeight + 20);
                this.Controls.Add(p);
                int y = p.Bottom + 10;
                foreach (var addon in d.AddsOnPurchase)
                {
                    AddsCart cart = new AddsCart(addon);
                    cart.RemoveAddson += (ss, ee) =>
                    {
                        d.AddsOnPurchase.Remove(addon);
                        displayShit();
                    };
                    cart.AddQty += (sss, eee) =>
                    {
                        var ad = ((AddsCart)sss).Addon;
                        var a = d.AddsOnPurchase.Find(z => z.Adds_id == ad.Adds_id);
                        if (a != null)
                        {
                            if (a.Purchase_Qty != a.CurrentlyMaxOrder && a.Purchase_Qty < a.CurrentlyMaxOrder)
                            {
                                a.Purchase_Qty++;
                                a.CurrentlyMaxOrder--;
                                ((AddsCart)sss).updateText();
                            }
                            displayShit();
                        }

                    };
                    cart.ReduceQty += (ssss, eeee) =>
                    {
                        var ad = ((AddsCart)ssss).Addon;
                        var a = d.AddsOnPurchase.Find(z => z.Adds_id == ad.Adds_id);
                        if (a != null)
                        {
                            a.Purchase_Qty--;
                            if (a.Purchase_Qty == 0)
                            {
                                d.AddsOnPurchase.Remove(a);
                            }
                            else
                            {
                                AddsCart ax = (AddsCart)ssss;
                                a.CurrentlyMaxOrder++;
                                ax.updateText();
                            }
                            displayShit();
                        }
                    };
                    cart.Location = new Point(5, y);
                    cart.Size = new Size(this.Width - 20, 130);
                    this.Controls.Add(cart);
                    y += cart.Height + 5;
                }
                total.Top = addlbl.Bottom + 5;
                totallbl.Top = addlbl.Bottom + 5;
                addtotal.Visible = true;
                addlbl.Visible = true;
                plbl.Visible = true;
                addtotal.Text = d.AddsOnPurchase.Sum(b => b.Purchase_Qty * b.MenuPrice).ToString("N2");
                pp.Location = new Point(pp.Location.X, total.Bottom + 5);
                this.Height = y + 10;
            }
            else
            {
                total.Top = addlbl.Top;
                pp.Location = new Point(pp.Location.X, total.Bottom + 5);
                totallbl.Top = addlbl.Top;
                addtotal.Visible = false;
                addlbl.Visible = false;
                plbl.Visible = false;
                addtotal.Text = "0.00";
                drop.Visible = false;
            }
            TotalChanged?.Invoke(this, EventArgs.Empty);
        }
        private void drop_Click(object sender, EventArgs e)
        {
            isVisible = !isVisible;
            drop.ImageRotate = isVisible ? 180 : 0;
            if (item is Dish z && (z.AddsOnPurchase == null || z.AddsOnPurchase.Count == 0))
            {
                return;
            }

            if (isVisible)
            {
                displayAddsOn();
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c is AddsCart)
                    {
                        this.Controls.Remove(c);
                    }
                }
                this.Height = isVisible ? baseHeight : baseHeight + 20;
            }
            TotalChanged?.Invoke(this, EventArgs.Empty);
        }
        private void displayDetails(Menu menu)
        {
            if (menu is Dish || menu is Combo || menu is Appetizer)
            {
                name.Text = menu.MenuName;
                price.Text = menu.MenuPrice.ToString("N2");
                tqty.Text = menu.Purchase_Qty.ToString();
                qty.Text = menu.Purchase_Qty.ToString();
                if (menu is Dish d)
                {
                    total.Text = ((menu.Purchase_Qty * menu.MenuPrice) + d.AddsOnPurchase.Sum(m => m.MenuPrice * m.Purchase_Qty)).ToString("N2");
                }
                else
                {
                    total.Text = (menu.MenuPrice * menu.Purchase_Qty).ToString("N2");
                }
                if (menu.MenuType.ToLower() == "menu")
                {
                    ItemType.Text = "Regular";
                }
                else
                {
                    ItemType.Text = menu.MenuType;
                }
            }
            else if (menu is Product p)
            {
                name.Text = p.MenuName;
                price.Text = p.Variant.MenuPrice.ToString("N2");
                ItemType.Text = p.Variant.MenuName;
                qty.Text = p.Purchase_Qty.ToString();
                tqty.Text = p.Purchase_Qty.ToString();
                total.Text = (p.Variant.MenuPrice * p.Purchase_Qty).ToString("N2");
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (item is Dish || item is Combo || item is Appetizer)
            {
                if (item.CurrentlyMaxOrder > int.Parse(qty.Text))
                {
                    updateQuantity(int.Parse(qty.Text) + 1);
                    QuantityChanged?.Invoke(this, EventArgs.Empty);
                }
            }
            else if (item is Product p)
            {
                if (p.Variant.CurrentlyMaxOrder > int.Parse(qty.Text))
                {
                    updateQuantity(int.Parse(qty.Text) - 1);
                    QuantityChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private void minus_Click(object sender, EventArgs e)
        {
            if (int.Parse(qty.Text) > 0)
            {
                updateQuantity(int.Parse(qty.Text) - 1);
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public void updateQuantity(int newQty)
        {

            if (newQty <= 0)
            {
                this.Parent?.Controls.Remove(this);
                NoQuantity?.Invoke(this, EventArgs.Empty);
            }

            item.Purchase_Qty = newQty;

            displayDetails(item);
            if (panel is MenuCard menuCard)
            {
                menuCard.UpdateMaxOrder(menuCard.Item.CurrentlyMaxOrder - newQty);
            }
            else if (panel is ProductCard pCard)
            {
                if (item is Product p && p.Variant != null)
                {
                    pCard.UpdateMaxOrder(p.Variant.CurrentlyMaxOrder - newQty);
                }
            }
        }
        private void removeAll(object sender, EventArgs e)
        {
            NoQuantity?.Invoke(this, EventArgs.Empty);
        }

        private void addtotal_Click(object sender, EventArgs e)
        {

        }

        private void ItemType_Click(object sender, EventArgs e)
        {

        }
    }

}
