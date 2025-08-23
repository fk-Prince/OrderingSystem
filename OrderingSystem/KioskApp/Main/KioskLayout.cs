using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApp.Appetizers;
using OrderingSystem.KioskApp.Card;
using OrderingSystem.KioskApp.Combos;
using OrderingSystem.KioskApp.Main;
using OrderingSystem.KioskApp.Products;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;
using Panel = System.Windows.Forms.Panel;

namespace OrderingSystem.KioskApp
{
    public partial class KioskLayout : Form, IMenuSelected
    {
        private List<Model.Menu> cartList = new List<Model.Menu>();
        private Guna2Button lastClcked;
        private Coupon selectedCoupon;

        // CART ANIMATION VARIABLES
        private int x;
        private int main;
        private bool isShowing = true;
        private int initialSize;
        public KioskLayout(int i)
        {
            InitializeComponent();
            switch (i)
            {
                case 1:
                    lastClcked = dishButton;
                    break;
                case 2:
                    lastClcked = productButton;
                    break;
                case 3:
                    lastClcked = appetizerButton;
                    break;
                case 4:
                    lastClcked = comboButton;
                    break;
            }

            switch (i)
            {
                case 1:
                    LoadForm(DishFrm.MenuFrmFactory(this, cartList));
                    break;
                case 2:
                    LoadForm(ProductFrm.ProductFrmFactory(this, cartList));
                    break;
                case 3:
                    LoadForm(AppetizerFrm.AppetizerFrmFactory(this, cartList));
                    break;
                case 4:
                    LoadForm(ComboFrm.ComboFrmFactory(this, cartList));
                    break;
            }

            lastClcked.ForeColor = Color.FromArgb(94, 148, 255);
        }


        public static KioskLayout KioskLayoutFactory(int i)
        {
            return new KioskLayout(1);
        }


        public void SelectedItem(Panel panel, Model.Menu items)
        {
            Menu existingMenu = null;
            if (items is Product newProd)
            {
                existingMenu = cartList.FirstOrDefault(p =>
                        (p is Product pr) &&
                        pr.MenuType == newProd.MenuType &&
                        pr.MenuID == newProd.MenuID &&
                        pr.Variant?.MenuID == newProd.Variant?.MenuID
                    );
            }
            else
            {
                existingMenu = cartList.FirstOrDefault(p =>
                    p.MenuType == items.MenuType &&
                    p.MenuID == items.MenuID &&
                  (p is Model.Dish || p is Model.Combo || p is Appetizer)
                );

            }

            if (existingMenu != null)
            {
                existingMenu.Purchase_Qty += items.Purchase_Qty;

                foreach (CartCard cartItem in flowCart.Controls.OfType<CartCard>())
                {
                    if (cartItem.Item is Product existingProduct && items is Product newProduct)
                    {
                        if (existingProduct.MenuType == newProduct.MenuType &&
                            existingProduct.MenuID == newProduct.MenuID &&
                            existingProduct.Variant?.MenuID == newProduct.Variant?.MenuID)
                        {
                            cartItem.updateQuantity(existingMenu.Purchase_Qty);
                            break;
                        }
                    }
                    else if (cartItem.Item.MenuType == existingMenu.MenuType &&
                             cartItem.Item.MenuID == existingMenu.MenuID &&
                            (cartItem.Item is Model.Dish || cartItem.Item is Model.Combo || cartItem.Item is Appetizer))
                    {
                        cartItem.updateQuantity(existingMenu.Purchase_Qty);
                        break;
                    }
                }
            }
            else
            {
                var copy = items.Clone();
                cartList.Add(copy);

                CartCard cart = new CartCard(panel, copy, cartList);
                cart.Margin = new Padding(5, 5, 0, 5);
                cart.QuantityChanged += (s, e) =>
                {
                    var cItem = ((CartCard)s).Item;
                    foreach (ProductCard control in flowCart.Controls.OfType<ProductCard>())
                    {
                        if (control.Item.MenuID == cItem.MenuID)
                        {
                            int purchasedQty = cartList
                                .Where(i => i.MenuID == cItem.MenuID)
                                .Sum(i => i.Purchase_Qty);

                            int maxAvailable = control.Item.CurrentlyMaxOrder - purchasedQty;
                            control.UpdateMaxOrder(maxAvailable);
                        }
                    }
                    CalculateTotal();
                };
                cart.NoQuantity += (s, ex) =>
                {
                    var clickedCart = s as CartCard;
                    if (clickedCart != null)
                    {
                        flowCart.Controls.Remove(clickedCart);
                        clickedCart.Dispose();
                        cartList.RemoveAll(i =>
                            i.MenuID == clickedCart.Item.MenuID &&
                            i.MenuType == clickedCart.Item.MenuType);


                        if (panel is MenuCard menuCard)
                        {
                            menuCard.updateMaxOrder(items.CurrentlyMaxOrder);

                        }
                        else if (panel is ProductCard productCard)
                        {
                            if (items is Product p)
                            {

                                productCard.UpdateMaxOrder(p.Variant.CurrentlyMaxOrder);
                            }
                        }

                    }

                    CalculateTotal();
                };
                cart.TotalChanged += (s, ex) =>
                {
                    CalculateTotal();
                };

                flowCart.Controls.Add(cart);
            }

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            double totalAmount = cartList.Sum(e =>
            {
                if (e is Product p && p.Variant != null)
                    return p.Purchase_Qty * p.Variant.MenuPrice;
                else if (e is Dish d)
                {
                    double addstotal = 0;
                    foreach (Addon a in d.AddsOnPurchase)
                    {
                        addstotal += a.MenuPrice * a.Purchase_Qty;
                    }
                    return (e.Purchase_Qty * e.MenuPrice) + addstotal;
                }
                else return e.Purchase_Qty * e.MenuPrice;
            });

            subtotal.Text = totalAmount.ToString("N2");

            if (selectedCoupon != null)
            {
                double discountA = totalAmount * selectedCoupon.Rate;
                double discountT = totalAmount - discountA;
                double vatT = discountT * 0.12;
                double totalF = discountT + vatT;

                discount.Text = discountA.ToString("N2");
                vat.Text = vatT.ToString("N2");
                total.Text = totalF.ToString("N2");
            }
            else
            {
                double vatT = totalAmount * 0.12;
                double totalF = totalAmount + vatT;

                discount.Text = "0.00";
                vat.Text = vatT.ToString("N2");
                total.Text = totalF.ToString("N2");
            }
            count.Text = cartList?.Count.ToString();
        }
        private void LoadForm(Form f)
        {
            if (mainpanel.Controls.Count > 0)
            {
                mainpanel.Controls.RemoveAt(0);
            }

            Form ff = f as Form;
            ff.Dock = DockStyle.Fill;
            ff.TopLevel = false;
            mainpanel.Controls.Add(ff);
            ff.Show();
        }

        private void Cart_Animation(object sender, EventArgs e)
        {
            if (isShowing)
            {
                x += 50;
                main += 50;
            }
            else
            {
                x -= 50;
                main -= 50;
            }
            if (isShowing && x >= ClientSize.Width)
            {
                x = ClientSize.Width;
                t.Stop();
                isShowing = !isShowing;
            }

            if (!isShowing && x <= initialSize)
            {
                x = initialSize;
                t.Stop();
                isShowing = !isShowing;
            }
            mainpanel.Size = new Size(main - 10, mainpanel.Height);
            cartPanel.Location = new Point(x, cartPanel.Location.Y);

        }
        private void CartButton(object sender, EventArgs e)
        {
            t.Start();
        }
        private void KioskLayout_SizeChanged(object sender, EventArgs e)
        {
            initialSize = cartPanel.Location.X;
            x = cartPanel.Location.X;
            main = mainpanel.Size.Width;
        }

        private void ExitButton(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ReviewOrderB(object sender, EventArgs e)
        {
            // DO HANDLE REVIEW ORDER 
        }
        private void DishSideClicked(object sender, EventArgs e)
        {
            LoadForm(DishFrm.MenuFrmFactory(this, cartList));
            changePrimary(sender);
        }
        private void ComboSideClicked(object sender, EventArgs e)
        {
            LoadForm(ComboFrm.ComboFrmFactory(this, cartList));
            changePrimary(sender);
        }
        private void ProductSideClicked(object sender, EventArgs e)
        {
            LoadForm(ProductFrm.ProductFrmFactory(this, cartList));
            changePrimary(sender);
        }
        private void AppetizerSideClicked(object sender, EventArgs e)
        {
            LoadForm(AppetizerFrm.AppetizerFrmFactory(this, cartList));
            changePrimary(sender);
        }
        private void changePrimary(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            if (lastClcked != b)
            {
                lastClcked.ForeColor = Color.White;
                b.ForeColor = Color.FromArgb(94, 148, 255);
                lastClcked = b;
            }
        }
        private void CouponClicked(object sender, EventArgs e)
        {
            ClickOutsideRemover remover = null;
            CouponFrm cFrm = CouponFrm.CouponFrmFactory();
            cFrm.Location = new Point(
                             (this.ClientSize.Width - cFrm.Width) / 2,
                             (this.ClientSize.Height - cFrm.Height) / 2
                         );
            remover = new ClickOutsideRemover(cFrm, () =>
            {
                if (this.Controls.Contains(cFrm))
                {
                    this.Controls.Remove(cFrm);
                    Application.RemoveMessageFilter(remover);
                }
            });

            Application.AddMessageFilter(remover);
            cFrm.CouponSelected += (ss, ee) =>
            {
                Coupon ex = ee;
                selectedCoupon = ee;
                if (ex != null)
                {
                    discountlbl.Text = (selectedCoupon.Rate * 100) + "% Coupon Code";
                    discountlbl.Visible = true;
                }
                else if (ex == null)
                {
                    discountlbl.Text = "0.00";
                    discountlbl.Visible = false;
                }
                CalculateTotal();
            };
            cFrm.Show();
            cFrm.Visible = true;
            this.Controls.Add(cFrm);
            cFrm.BringToFront();
        }
    }

    public class ClickOutsideRemover : IMessageFilter
    {
        private Control target;
        private Action onClickOutside;

        public ClickOutsideRemover(Control target, Action onClickOutside)
        {
            this.target = target;
            this.onClickOutside = onClickOutside;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x201)
            {
                Point cursorPos = Control.MousePosition;
                if (target.Parent != null && !target.Bounds.Contains(target.Parent.PointToClient(cursorPos)))
                {
                    onClickOutside?.Invoke();
                    return false;
                }
            }

            return false;
        }

    }
}
