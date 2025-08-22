using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApp.Card
{
    public partial class ProductCard : Guna2Panel
    {
        private Menu item;
        private IMenuSelected itemSelected;
        private List<Menu> cartList;

        public Menu Item => item;
        public ProductCard(Menu item, IMenuSelected itemSelected, List<Menu> cartList)
        {
            InitializeComponent();
            this.item = item;
            this.cartList = cartList;
            this.itemSelected = itemSelected;
            FillColor = Color.LightGray;
            BorderRadius = 10;
            BorderThickness = 1; ;
            name.Text = item.MenuName;
            desc.Text = item.MenuDescription;
            image.Image = item.Image;
            if (item is Product p)
            {
                foreach (Variant v in p.VariantList)
                {
                    vList.Items.Add(v.MenuName.Substring(0, 1).ToUpper() + v.MenuName.Substring(1).ToLower());
                    UpdateMaxOrder(v.CurrentlyMaxOrder);
                }

                if (p.VariantList.Count > 0)
                {
                    vList.SelectedIndex = 0;
                    price.Text = p.VariantList[0].MenuPrice.ToString("N2");
                }
            }
            displayMax();
        }

        private void displayMax()
        {
            if (vList.SelectedIndex == -1) return;
            int x = 0;
            if (item is Product p)
            {
                x = p.VariantList[vList.SelectedIndex].CurrentlyMaxOrder;
            }
        }

        public void UpdateMaxOrder(int newMax)
        {
            if (vList.SelectedIndex == -1) return;

            if (item is Product p)
            {

                quantity.Maximum = newMax;

                if (newMax <= 0)
                {
                    quantity.Minimum = 0;
                    quantity.Enabled = false;
                    outStock.Visible = true;
                    //st.Visible = false;
                }
                else
                {
                    outStock.Visible = false;
                    //st.Visible = true;
                    quantity.Minimum = 1;
                    quantity.Enabled = true;
                }
                displayMax();
            }
        }

        private void VariantSelector(object sender, System.EventArgs e)
        {
            if (vList.SelectedIndex == -1) return;
            int index = vList.SelectedIndex;

            if (item is Product p)
            {
                int noPurchase = cartList
                    .Where(i => i is Product cp &&
                                cp.MenuID == p.MenuID &&
                                cp.Variant?.MenuID == p.VariantList[index].MenuID)
                    .Sum(i => i.Purchase_Qty);

                price.Text = p.VariantList[index].MenuPrice.ToString("N2");
                UpdateMaxOrder(p.VariantList[index].CurrentlyMaxOrder - noPurchase);
            }
        }

        private void AddItem(object sender, System.EventArgs be)
        {
            if (vList.SelectedIndex < 0) return;
            int qty = (int)quantity.Value;
            if (qty <= 0) return;

            int totalPurchasedQty = cartList
                        .Where(e => e is Product p && p.Variant != null && p.Variant.MenuID == ((Product)item).VariantList[vList.SelectedIndex].MenuID)
                        .Sum(e => e.Purchase_Qty);

            int newQtyMax = ((Product)item).VariantList[vList.SelectedIndex].CurrentlyMaxOrder - totalPurchasedQty - qty;
            quantity.Maximum = newQtyMax;
            if (item is Product x)
            {
                Product p = Product.Builder()
                    .SetProductID(x.MenuID)
                    .SetProductName(x.MenuName)
                    .SetItemType(x.MenuType)
                    .SetProductDescription(x.MenuDescription)
                    .SetVariantPurchase(x.VariantList[vList.SelectedIndex])
                    .SetPurchaseQuantity(qty)
                    .Build();
                ;

                itemSelected.SelectedItem(this, p);
            }
            UpdateMaxOrder(newQtyMax);
        }


    }
}
