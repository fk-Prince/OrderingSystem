using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using Dish = OrderingSystem.Model.Dish;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApp.Card
{
    public partial class MenuCard : Guna2Panel
    {
        private IMenuSelected itemSelected;
        private Menu item;
        private List<Menu> cartList;
        public Menu Menu => item;

        public MenuCard(Menu menu, IMenuSelected itemSelected, List<Menu> cartList)
        {
            InitializeComponent();
            this.item = menu;
            this.itemSelected = itemSelected;
            this.cartList = cartList;
            BorderColor = Color.LightGray;
            BorderRadius = 10;
            BorderThickness = 1;
            max.Text = menu.CurrentlyMaxOrder.ToString();
            FillColor = Color.LightGray;
            name.Text = menu.MenuName;
            desc.Text = menu.MenuDescription;
            price.Text = menu.MenuPrice.ToString("N2");

            UpdateMaxOrder(menu.CurrentlyMaxOrder);
            display();

        }

        public Menu Item { get => item; }

        public void display()
        {
            //maxlabel.Visible = true;
            //max.Visible = true;
        }

        public void UpdateMaxOrder(int newMax)
        {
            max.Text = newMax.ToString();
            quantity.Maximum = newMax;

            if (newMax <= 0)
            {
                quantity.Minimum = 0;
                quantity.Value = 0;
                quantity.Enabled = false;
                outStock.Visible = true;
                guna2PictureBox2.Enabled = false;
            }
            else
            {
                guna2PictureBox2.Enabled = true;
                outStock.Visible = false;
                quantity.Minimum = 1;
                if (quantity.Value < 1 || quantity.Value > newMax)
                    quantity.Value = 1;
                outStock.Refresh();
                quantity.Enabled = true;
            }
            max.Text = newMax.ToString();
            display();
        }



        private void AddItem(object sender, EventArgs eb)
        {
            int qty = (int)quantity.Value;
            if (qty <= 0) return;

            int totalPurchasedQty = cartList
                    .Where(e => (e.MenuType == item.MenuType && e.MenuID == item.MenuID) ||
                    (e.MenuType == item.MenuType && e.MenuID == item.MenuID) ||
                    (e.MenuType == item.MenuType && e.MenuID == item.MenuID))
                    .Sum(e => e.Purchase_Qty);
            int newQtyMax = item.CurrentlyMaxOrder - totalPurchasedQty - qty;
            quantity.Maximum = newQtyMax;


            if (item is Dish d)
            {
                Dish m = Dish.Builder()
                     .SetMenuType(d.MenuType)
                     .SetMenuId(d.MenuID)
                     .SetDishID(d.DishID)
                     .SetMenuName(d.MenuName)
                     .SetPrice(d.MenuPrice)
                     .SetCurrentlyMaxOrder(d.CurrentlyMaxOrder)
                     .SetPurchaseQuantity(qty)
                     .Build();
                itemSelected.SelectedItem(this, m);
            }
            else if (item is Combo c)
            {
                Combo cc = Combo.Builder()
                    .SetItemType(c.MenuType)
                    .SetMenuID(c.MenuID)
                    .SetComboID(c.Combo_id)
                    .SetComboName(c.MenuName)
                    .SetPrice(c.MenuPrice)
                    .SetCurrentlyMaxOrder(c.CurrentlyMaxOrder)
                    .SetPurchaseQuantity(qty)
                    .Build();
                itemSelected.SelectedItem(this, cc);
            }
            else if (item is Appetizer)
            {
                Appetizer cb = Appetizer.Builder()
                   .SetMenuType(item.MenuType)
                   .SetAppetizerID(item.MenuID)
                   .SetAppetizerName(item.MenuName)
                   .SetPrice(item.MenuPrice)
                   .SetCurrentlyMaxOrder(item.CurrentlyMaxOrder)
                   .SetPurchaseQuantity(qty)
                   .Build();
                itemSelected.SelectedItem(this, cb);
            }
            ;

            UpdateMaxOrder(newQtyMax);

        }
    }
}
