using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApp.MenuBuilder;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApp.Card
{
    public partial class MenuCard : Guna2Panel
    {
        private IMenuSelected itemSelected;
        private Menu menu;
        private List<Menu> cartList;
        public Menu Menu => menu;
        public MenuCard(Menu menu, IMenuSelected itemSelected, List<Menu> cartList)
        {
            InitializeComponent();
            this.menu = menu;
            this.itemSelected = itemSelected;
            this.cartList = cartList;

            cartLayout();
            displayMenu(menu);
            updateMaxOrder(menu.CurrentlyMaxOrder);
        }

        private void cartLayout()
        {
            BorderColor = Color.LightGray;
            BorderRadius = 10;
            BorderThickness = 1;
        }

        private void displayMenu(Menu menu)
        {
            FillColor = Color.LightGray;
            name.Text = menu.MenuName;
            image.Image = menu.Image;
            desc.Text = menu.MenuDescription;
            price.Text = menu.MenuPrice.ToString("N2");
        }




        public void updateMaxOrder(int newMax)
        {
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
        }



        private void AddItem(object sender, EventArgs eb)
        {
            int qty = (int)quantity.Value;
            if (qty <= 0) return;

            int totalPQ = cartList
                    .Where(e => (e.MenuType == menu.MenuType && e.MenuID == menu.MenuID) ||
                    (e.MenuType == menu.MenuType && e.MenuID == menu.MenuID) ||
                    (e.MenuType == menu.MenuType && e.MenuID == menu.MenuID))
                    .Sum(e => e.Purchase_Qty);
            int newQtyMax = menu.CurrentlyMaxOrder - totalPQ - qty;
            quantity.Maximum = newQtyMax;



            var menuBuilder = MenuBuilderFactory.Build(menu, qty);
            itemSelected.SelectedItem(this, menuBuilder);
            updateMaxOrder(newQtyMax);

        }


    }
}
