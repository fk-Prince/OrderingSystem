using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Menus
{
    public interface IDishRepository
    {
        Task<List<Dish>> RetrieveMenu();
    }
}
