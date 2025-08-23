    using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.KioskApp.Card;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;
namespace OrderingSystem.KioskApp.Combos
{
    public partial class ComboFrm : Form
    {
        private IComboRepository comboRepository;
        private IMenuSelected itemSelected;
        private List<Menu> cartList;
        private static ComboFrm instance;
        public ComboFrm(IMenuSelected itemSelected, IComboRepository comboRepository, List<Menu> cartList)
        {
            InitializeComponent();
            this.comboRepository = comboRepository;
            this.itemSelected = itemSelected;
            this.cartList = cartList;
            this.Load += async (s, e) =>
            {
                spinner.Start();
                await runAsyncFunction();
            };
        }

        private async Task runAsyncFunction()
        {
            try
            {
                List<Combo> combos = await comboRepository.RetrieveCombo();
                spinner.Stop();
                spinner.Visible = false;
                displayMenu(combos);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("menufrm   runAsyncFunction      " + ex.Message);
            }
        }

        private void displayMenu(List<Combo> combos)
        {
            if (cartList != null || cartList.Count != 0)
            {
                foreach (var combo in combos)
                {
                    var cartItem = cartList?.Find(c => c.MenuID == combo.MenuID && c.MenuType == combo.MenuType);
                    if (cartItem != null)
                    {
                        combo.CurrentlyMaxOrder -= cartItem.Purchase_Qty;
                        if (combo.CurrentlyMaxOrder < 0)
                            combo.CurrentlyMaxOrder = 0;
                    }
                }
            }
            flowPanel.Controls.Clear();
            foreach (Combo c in combos)
            {
                MenuCard p = new MenuCard(c, itemSelected, cartList);
                p.Margin = new Padding(10, 30, 10, 30);
                flowPanel.Controls.Add(p);
            }
        }

        public static ComboFrm ComboFrmFactory(IMenuSelected itemSelected, List<Model.Menu> cartList)
        {
            if (instance == null)
            {
                IComboRepository comboRepository = new ComboRepository();
                return instance = new ComboFrm(itemSelected, comboRepository, cartList);
            }
            else
            {
                return instance;
            }
        }

        private void search_TextChanged(object sender, System.EventArgs e)
        {
            t.Stop();
            t.Start();
        }

        private void t_Tick(object sender, System.EventArgs e)
        {
            t.Stop();
            string tx = search.Text.Trim().ToLower();
            foreach (Control c in flowPanel.Controls)
            {
                if (c is MenuCard card)
                {
                    Combo combo = (Combo)card.Menu;
                    bool match = string.IsNullOrWhiteSpace(tx) || combo.MenuName.ToLower().Contains(tx);
                    c.Visible = string.IsNullOrWhiteSpace(tx) || combo.MenuName.ToLower().Contains(tx);
                }
            }
        }


    }
}
