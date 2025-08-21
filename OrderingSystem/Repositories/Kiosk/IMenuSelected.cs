
using System.Windows.Forms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp
{
    public interface IMenuSelected
    {
        void SelectedItem(Panel panel, Model.Menu menu);
    }
}
