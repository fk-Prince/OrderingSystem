using System.Windows.Forms;
using OrderingSystem.Database;
using OrderingSystem.KioskApp;

namespace OrderingSystem
{
    public partial class KioskDashboard : Form
    {
        public KioskDashboard()
        {
            InitializeComponent();
            var db = MyDatabase.getInstance();

        }


        public void LoadForm(Form f)
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

        private void DishesClicked(object sender, System.EventArgs e)
        {
            LoadForm(KioskLayout.KioskLayoutFactory(1));
        }

        private void PackageClicked(object sender, System.EventArgs e)
        {
            LoadForm(KioskLayout.KioskLayoutFactory(4));
        }
    }
}
