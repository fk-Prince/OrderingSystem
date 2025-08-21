using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.KioskApp.AddsOn;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;


namespace OrderingSystem.KioskApp.Card
{
    public partial class AddsFrm : Form
    {

        public event EventHandler change;
        private Dish m;

        public Dish Dish => m;

        public AddsFrm(Dish m, IAddonRepository addonRepository, List<Menu> cartList)
        {
            InitializeComponent();
            this.m = m;
            //BorderRadius = 15;
            //BackColor = Color.Transparent;

            //FillColor = Color.FromArgb(34, 34, 34);
            //Focus();
            this.BringToFront();
            this.HandleCreated += async (s, e) =>
            {
                List<Addon> adds = await addonRepository.getAddsOnByMenu(m.DishID, cartList);
                if (cartList != null && cartList.Count != 0)
                {
                    foreach (Addon menu in adds)
                    {
                        var dishItem = cartList
                            ?.OfType<Dish>()
                            .FirstOrDefault(d => d.AddsOnPurchase?.Any(cbe => cbe.Adds_id == menu.Adds_id) == true);

                        if (dishItem != null)
                        {
                            var matchingAddOn = dishItem.AddsOnPurchase
                                .FirstOrDefault(cbe => cbe.Adds_id == menu.Adds_id);

                            if (matchingAddOn != null)
                            {
                                menu.CurrentlyMaxOrder -= matchingAddOn.Purchase_Qty;

                                if (menu.CurrentlyMaxOrder < 0)
                                    menu.CurrentlyMaxOrder = 0;
                            }
                        }
                    }
                }
                displayAdds(adds);
            };
        }

        private void displayAdds(List<Addon> adds)
        {
            flowPanel.Controls.Clear();
            foreach (Addon x in adds)
            {
                AddsCard b = new AddsCard(x, m);
                b.xxc += (xe, xr) =>
                {
                    change?.Invoke(this, EventArgs.Empty);
                };
                if (adds.Count > 3)
                {
                    b.Margin = new Padding(42, 5, 5, 5);
                }
                else
                {
                    b.Margin = new Padding(40, 5, 5, 5);
                }
                flowPanel.Controls.Add(b);
            }
        }

        public static AddsFrm AddsFrmFactory(Dish d, List<Menu> cartList)
        {
            IAddonRepository addonRepository = new AddonRepository();
            return new AddsFrm(d, addonRepository, cartList);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }


}
