using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApp.Card;
using OrderingSystem.Model;
using OrderingSystem.Repositories.Categories;
using Menu = OrderingSystem.Model.Menu;


namespace OrderingSystem.KioskApp.Products
{
    public partial class ProductFrm : Form
    {
        private IProductRepository productRepository;
        private IMenuSelected itemSelected;
        private List<Menu> cartList;
        private static ProductFrm instance;
        private Guna2Button lastButton;
        private List<Product> products;
        private List<Category> productsCategoryList;
        private IProductCategoryRepository productCategoryRepository;
        public ProductFrm(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IMenuSelected itemSelected, List<Menu> cartList)
        {
            InitializeComponent();
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.itemSelected = itemSelected;
            this.cartList = cartList;
            this.Load += async (s, e) =>
            {
                await runAsyncFunction();
            };
        }

        public static Form ProductFrmFactory(IMenuSelected itemSelected, List<Menu> cartList)
        {
            if (instance == null)
            {
                IProductRepository productRepository = new ProductRepository();
                IProductCategoryRepository productCategoryRepository = new ProductCategoryRepository();
                return new ProductFrm(productRepository, productCategoryRepository, itemSelected, cartList);
            }
            else
            {
                return instance;
            }
        }

        private async Task runAsyncFunction()
        {
            spinner.Start();
            try
            {
                products = await productRepository.GetProducts();
                productsCategoryList = await productCategoryRepository.getProductCategories();
                displayMenu(products);
                displayCategory(productsCategoryList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                spinner.Visible = false;
            }

        }

        private void displayCategory(List<Category> productsCategoryList)
        {
            if (productsCategoryList.Count > 0)
            {
                Guna2Button ba = new Guna2Button();
                ba.Text = "All";
                ba.Tag = 0;
                ba.BorderColor = Color.FromArgb(34, 34, 34);
                ba.BorderThickness = 1;
                ba.Click += ActiveCat;
                ba.AutoRoundedCorners = true;
                ba.Size = new Size(120, 40);
                ba.ForeColor = Color.FromArgb(34, 34, 34);
                flowCat.Controls.Add(ba);
                lastButton = ba;

                foreach (var cat in productsCategoryList)
                {
                    Guna2Button b = new Guna2Button();
                    b.Text = cat.Category_name;
                    b.FillColor = Color.Transparent;
                    b.BorderColor = Color.FromArgb(34, 34, 34);
                    b.BorderThickness = 1;
                    b.Tag = cat.Category_id;
                    b.Click += ActiveCat;
                    b.AutoRoundedCorners = true;
                    b.Size = new Size(120, 40);
                    b.ForeColor = Color.FromArgb(34, 34, 34);
                    flowCat.Controls.Add(b);
                }
            }
        }

        private void ActiveCat(object sender, System.EventArgs e)
        {
            Guna2Button x = (Guna2Button)sender;
            if (lastButton != x)
            {
                lastButton.FillColor = Color.Transparent;
                x.FillColor = Color.FromArgb(94, 148, 255);
                lastButton = x;

                t.Start();
            }
        }

        private void displayMenu(List<Product> products)
        {
            if (cartList != null || cartList.Count != 0)
            {
                foreach (var combo in products)
                {
                    var cartItem = cartList?.Find(c => c.MenuID == combo.MenuID && c.MenuType == combo.MenuType);

                    if (cartItem != null)
                    {
                        Product p = cartItem as Product;
                        foreach (Variant v in p.VariantList)
                        {
                            if (v != null)
                            {
                                v.Purchase_Qty -= cartItem.Purchase_Qty;
                                if (v.CurrentlyMaxOrder < 0)
                                {
                                    v.CurrentlyMaxOrder = 0;
                                }
                            }
                        }
                    }
                }
            }
            flowPanel.Controls.Clear();
            foreach (Product pr in products)
            {
                ProductCard p = new ProductCard(pr, itemSelected, cartList);
                p.Margin = new Padding(10, 30, 10, 30);
                flowPanel.Controls.Add(p);
            }
        }

        private void t_Tick(object sender, System.EventArgs e)
        {
            t.Stop();
            t.Start();
        }

        private void search_TextChanged(object sender, System.EventArgs e)
        {
            t.Stop();
            string tx = search.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(tx))
            {
                if ((int)lastButton.Tag == 0)
                {
                    displayMenu(products);
                }
                else
                {

                    List<Product> m = products.Where(b => b.Category_id == (int)lastButton.Tag).ToList();
                    displayMenu(m);
                }
            }
            else
            {
                if ((int)lastButton.Tag == 0)
                {
                    List<Product> m = products.Where(b => b.MenuName.ToLower().Contains(tx)).ToList();
                    displayMenu(m);
                }
                else
                {
                    List<Product> m = products.Where(b =>
                            b.Category_id == (int)lastButton.Tag &&
                            b.MenuName.ToLower().Contains(tx)).ToList();

                    displayMenu(m);
                }
            }
        }
    }
}
