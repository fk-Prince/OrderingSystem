using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.Database;
using OrderingSystem.KioskApp.Card;
using OrderingSystem.KioskApp.Menus;
using OrderingSystem.Model;
using OrderingSystem.Repositories.Categories;
using Dish = OrderingSystem.Model.Dish;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApp
{
    public partial class DishFrm : Form
    {
        private IDishRepository dishRepository;
        private IMenuSelected itemSelected;
        private IMenuCategoryRepository menuCategoryRepository;
        private List<Menu> cartList;
        private List<Dish> menus;
        private List<Category> categories;

        //CATEGORIES UTIL
        private Guna2Button lastButton;
        private bool isDragging = false;
        private Point dragStart;
        private int startX;

        private static DishFrm instance;
        public DishFrm(IDishRepository dishRepository, IMenuCategoryRepository menuCategoryRepository, IMenuSelected itemSelected, List<Menu> cartList)
        {
            InitializeComponent();
            this.menuCategoryRepository = menuCategoryRepository;
            this.dishRepository = dishRepository;
            this.itemSelected = itemSelected;
            this.cartList = cartList;
            spinner.Start();
        }
        public static DishFrm MenuFrmFactory(IMenuSelected itemSelected, List<Menu> cartList)
        {
            if (instance == null)
            {
                IMenuCategoryRepository menuCategoryRepository = new MenuCategoryRepository();
                IDishRepository dishRepository = new DishesRepository();
                return instance = new DishFrm(dishRepository, menuCategoryRepository, itemSelected, cartList);
            }
            else
            {
                return instance;
            }
        }
        private void displayDishes(List<Dish> menus)
        {
            if (cartList != null || cartList.Count != 0)
            {
                foreach (var menu in menus)
                {
                    var cartItem = cartList?.Find(c => c.MenuID == menu.MenuID && c.MenuType == menu.MenuType);
                    if (cartItem != null)
                    {
                        menu.CurrentlyMaxOrder -= cartItem.Purchase_Qty;
                        if (menu.CurrentlyMaxOrder < 0)
                            menu.CurrentlyMaxOrder = 0;
                    }
                }
            }
            flowPanel.Controls.Clear();
            foreach (Dish m in menus)
            {
                MenuCard p = new MenuCard(m, itemSelected, cartList);
                p.Margin = new Padding(10, 10, 10, 10);
                p.Tag = m.Category_id;
                flowPanel.Controls.Add(p);
            }
        }
        private async Task runAsyncFunction()
        {
            try
            {
                categories = await menuCategoryRepository.GetCategories();
                menus = await dishRepository.RetrieveDish();
                displayDishes(CloneMenuList(menus));
                displayCategory(categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show("menufrm   runAsyncFunction      " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                spinner.Visible = false;
            }
        }
        private List<Dish> CloneMenuList(List<Dish> original)
        {
            return original
                .Select(d => (Dish)d.Clone())
                .ToList();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            t.Stop();
            string tx = search.Text.Trim().ToLower();
            int id = (int)lastButton.Tag;
            foreach (Control c in flowPanel.Controls)
            {
                if (c is MenuCard card)
                {
                    Dish dish = (Dish)card.Menu;
                    bool matchesCategory = (id == 0 || dish.Category_id == id);
                    bool matchesSearch = string.IsNullOrWhiteSpace(tx) || dish.MenuName.ToLower().Contains(tx);
                    c.Visible = (id == 0 || dish.Category_id == id) && string.IsNullOrWhiteSpace(tx) || dish.MenuName.ToLower().Contains(tx);
                }
            }
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            t.Stop();
            t.Start();
        }
        private async void DishFrm_Load(object sender, EventArgs e)
        {
            await runAsyncFunction();
        }
        private void displayCategory(List<Category> cat)
        {
            var db = MyDatabase.getInstance();
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
            foreach (Category c in cat)
            {
                Guna2Button b = new Guna2Button();
                b.Text = c.Category_name;
                b.FillColor = Color.Transparent;
                b.BorderColor = Color.FromArgb(34, 34, 34);
                b.BorderThickness = 1;
                b.Tag = c.Category_id;
                b.Click += ActiveCat;
                b.AutoRoundedCorners = true;
                b.Size = new Size(120, 40);
                b.ForeColor = Color.FromArgb(34, 34, 34);
                flowCat.Controls.Add(b);
            }
        }
        private void displayMenuCategory(int id)
        {
            foreach (MenuCard control in flowPanel.Controls)
            {
                if (id == 0)
                {
                    control.Visible = true;
                }
                else
                {
                    control.Visible = ((int)control.Tag == id);
                }
            }
        }
        private void ActiveCat(object sender, EventArgs e)
        {
            Guna2Button x = (Guna2Button)sender;
            if (lastButton != x)
            {
                lastButton.FillColor = Color.Transparent;
                x.FillColor = Color.FromArgb(94, 148, 255);
                lastButton = x;

                if (x.Tag != null)
                {
                    int id = (int)x.Tag;
                    displayMenuCategory(id);
                }
            }
        }
        private void flowCat_MouseClick(object sender, MouseEventArgs e)
        {
            isDragging = true;

        }
        private void flowCat_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.Location.X - dragStart.X;
                flowCat.AutoScrollPosition = new Point(-(startX + deltaX), 0); ;
            }
        }
        private void flowCat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flowCat.Cursor = Cursors.Hand;
                isDragging = true;
                dragStart = e.Location;
                startX = flowCat.AutoScrollPosition.X;
            }
        }
        private void flowCat_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

    }
}
