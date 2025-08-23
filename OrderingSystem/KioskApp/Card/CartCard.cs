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
        private Panel parentPanel;
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
            this.parentPanel = panel;

            cartLayout();


            drop.Visible = item is Dish d && d.AddsOnPurchase.Count != 0;
            addonButton.Visible = item is Dish;

            displayDetails(item);
        }
        private void cartLayout()
        {
            BorderRadius = 10;
            BorderColor = Color.LightGray;
            FillColor = Color.FromArgb(228, 228, 228);
            BackColor = Color.Transparent;
            BorderThickness = 1;
        }
        private void showAddonButton(object sender, EventArgs e)
        {
            if (item is Dish d)
            {
                AddsFrm x = AddsFrm.AddsFrmFactory(d, cartList);
                x.purchaseQuantityChanged += (xe, xr) => displayShit();
                x.ShowDialog(this);
            }
        }
        private void displayShit()
        {
            if (item is Dish d && d.AddsOnPurchase.Any(a => a.Purchase_Qty > 0))
            {
                updateDish(d);
            }
            else
            {
                updateRegular();
            }
            TotalChanged?.Invoke(this, EventArgs.Empty);
        }
        private void updateDish(Dish dish)
        {
            drop.Visible = true;
            addlbl.Visible = true;
            plbl.Visible = true;
            addtotal.Visible = true;

            if (isVisible)
            {
                displayAddsOn();
            }
            else
            {
                this.Height = baseHeight;
                clearPanel();
            }

            total.Text = ((item.Purchase_Qty * item.MenuPrice) + dish.AddsOnPurchase.Sum(b => b.Purchase_Qty * b.MenuPrice)).ToString("N2");
        }
        private void updateRegular()
        {
            total.Top = addlbl.Top;
            totallbl.Top = addlbl.Top;
            pp.Location = new Point(pp.Location.X, total.Bottom + 5);

            addtotal.Visible = false;
            addlbl.Visible = false;
            plbl.Visible = false;
            addtotal.Text = "0.00";
            drop.Visible = false;

            this.Height = baseHeight;
            total.Text = (item.Purchase_Qty * item.MenuPrice).ToString("N2");
        }
        private void displayAddsOn()
        {
            if (item is Dish dish)
            {
                clearPanel();
                panelSeparator();
                displayAddOnCart(dish);
                updateTextPosition(dish);
            }
        }
        private void clearPanel()
        {
            var controlsToRemove = this.Controls.OfType<AddsCart>().Cast<Control>()
                .Concat(this.Controls.OfType<Panel>().Where(p => p.BackColor == Color.LightGray));
            foreach (var c in controlsToRemove.ToList())
            {
                this.Controls.Remove(c);
            }
        }
        private void panelSeparator()
        {
            Panel p = new Panel();
            p.Width = this.Size.Width - 100;
            p.Height = 2;
            p.BackColor = Color.LightGray;
            p.Location = new Point(50, baseHeight + 20);
            this.Controls.Add(p);
        }
        private void displayAddOnCart(Dish dish)
        {
            int y = baseHeight + 32;
            foreach (var addon in dish.AddsOnPurchase)
            {
                AddsCart cart = new AddsCart(addon);
                cart.RemoveAddson += (ss, ee) =>
                {
                    dish.AddsOnPurchase.Remove(addon);
                    displayShit();
                };
                cart.AddQty += (sss, eee) =>
                {
                    var ad = ((AddsCart)sss).Addon;
                    var a = dish.AddsOnPurchase.Find(z => z.Adds_id == ad.Adds_id);
                    if (a != null && a.Purchase_Qty < a.CurrentlyMaxOrder)
                    {
                        a.Purchase_Qty++;
                        a.CurrentlyMaxOrder--;
                        ((AddsCart)sss).updateText();
                        displayShit();
                    }
                };
                cart.ReduceQty += (ssss, eeee) =>
                {
                    var ad = ((AddsCart)ssss).Addon;
                    var a = dish.AddsOnPurchase.Find(z => z.Adds_id == ad.Adds_id);
                    if (a != null)
                    {
                        a.Purchase_Qty--;
                        if (a.Purchase_Qty == 0)
                        {
                            dish.AddsOnPurchase.Remove(a);
                        }
                        else
                        {
                            a.CurrentlyMaxOrder++;
                            ((AddsCart)ssss).updateText();
                        }
                        displayShit();
                    }
                };
                cart.Location = new Point(5, y);
                cart.Size = new Size(this.Width - 20, 130);
                this.Controls.Add(cart);
                y += cart.Height + 5;
            }
        }
        private void updateTextPosition(Dish d)
        {
            total.Top = addlbl.Bottom + 5;
            totallbl.Top = addlbl.Bottom + 5;
            addtotal.Text = d.AddsOnPurchase.Sum(b => b.Purchase_Qty * b.MenuPrice).ToString("N2");
            pp.Location = new Point(pp.Location.X, total.Bottom + 5);
            this.Height = this.Controls.OfType<AddsCart>().LastOrDefault()?.Bottom + 10 ?? baseHeight;
        }
        private void dropdownClicked(object sender, EventArgs e)
        {
            isVisible = !isVisible;
            drop.ImageRotate = isVisible ? 180 : 0;
            if (item is Dish d && d.AddsOnPurchase.Any())
            {
                if (isVisible)
                {
                    displayAddsOn();
                }
                else
                {
                    clearPanel();
                    this.Height = baseHeight + 20;
                }
                TotalChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private void displayDetails(Menu menu)
        {
            name.Text = menu.MenuName;
            qty.Text = menu.Purchase_Qty.ToString();
            tqty.Text = menu.Purchase_Qty.ToString();

            if (menu is Product p)
            {
                price.Text = p.Variant.MenuPrice.ToString("N2");
                ItemType.Text = p.Variant.MenuName;
                total.Text = (p.Variant.MenuPrice * p.Purchase_Qty).ToString("N2");
            }
            else
            {
                price.Text = menu.MenuPrice.ToString("N2");
                ItemType.Text = (menu.MenuType.ToLower() == "menu") ? "Regular" : menu.MenuType;

                double totalPrice = menu.MenuPrice * menu.Purchase_Qty;
                if (menu is Dish d)
                {
                    if (d.AddsOnPurchase != null)
                    {
                        totalPrice += d.AddsOnPurchase.Sum(m => m.MenuPrice * m.Purchase_Qty);
                    }
                }
                total.Text = totalPrice.ToString("N2");
            }
        }
        private void addQuantity(object sender, EventArgs e)
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
        private void reduceQty(object sender, EventArgs e)
        {
            if (int.Parse(qty.Text) > 0)
            {
                updateQuantity(int.Parse(qty.Text) - 1);
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private void removeAll(object sender, EventArgs e)
        {
            NoQuantity?.Invoke(this, EventArgs.Empty);
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
            if (parentPanel is MenuCard menuCard)
            {
                menuCard.updateMaxOrder(menuCard.Menu.CurrentlyMaxOrder - newQty);
            }
            else if (parentPanel is ProductCard pCard)
            {
                if (item is Product p && p.Variant != null)
                {
                    pCard.UpdateMaxOrder(p.Variant.CurrentlyMaxOrder - newQty);
                }
            }
        }

    }

}
