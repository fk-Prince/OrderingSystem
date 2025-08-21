using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.KioskApp.Card;
using OrderingSystem.Model;
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
        public ProductFrm(IProductRepository productRepository, IMenuSelected itemSelected, List<Menu> cartList)
        {
            InitializeComponent();
            this.productRepository = productRepository;
            this.itemSelected = itemSelected;
            this.cartList = cartList;
            spinner.Start();
            runAsyncFunction();
        }

        public static Form ProductFrmFactory(IMenuSelected itemSelected, List<Menu> cartList)
        {
            if (instance == null)
            {
                IProductRepository productRepository = new ProductRepository();
                return new ProductFrm(productRepository, itemSelected, cartList);
            }
            else
            {
                return instance;
            }
        }

        private async void runAsyncFunction()
        {

            try
            {
                products = await productRepository.GetProducts();
                await displayCategory();
                spinner.Stop();
                spinner.Visible = false;
                displayMenu(products);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ex " + ex.Message);
            }

        }

        private async Task displayCategory()
        {
            var db = MyDatabase.getInstance();
            try
            {
                var conn = await db.GetConnection();
                string query = @"
                                SELECT c.product_category_id, c.product_category_name 
                                    FROM product_category c 
                                INNER JOIN product p 
                                    ON p.product_category_id = c.product_category_id 
                                GROUP BY c.product_category_id, c.product_category_name
                                ";
                var cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
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
                    while (await reader.ReadAsync())
                    {
                        Guna2Button b = new Guna2Button();
                        b.Text = reader.GetString("product_category_name");
                        b.FillColor = Color.Transparent;
                        b.BorderColor = Color.FromArgb(34, 34, 34);
                        b.BorderThickness = 1;
                        b.Tag = reader.GetInt32("product_category_id");
                        b.Click += ActiveCat;
                        b.AutoRoundedCorners = true;
                        b.Size = new Size(120, 40);
                        b.ForeColor = Color.FromArgb(34, 34, 34);
                        flowCat.Controls.Add(b);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await db.CloseConnection();
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

        private void flowPanel_Paint(object sender, PaintEventArgs e)
        {

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
