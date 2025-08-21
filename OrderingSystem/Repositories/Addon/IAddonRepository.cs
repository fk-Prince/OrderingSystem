using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;
using adds = OrderingSystem.Model.Addon;
namespace OrderingSystem.KioskApp.AddsOn
{
    public interface IAddonRepository
    {
        Task<List<adds>> getAddsOnByMenu(int id, List<Menu> cartList);

    }
}
