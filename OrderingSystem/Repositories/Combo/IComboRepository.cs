using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Combos
{
    public interface IComboRepository
    {
        Task<List<Combo>> RetrieveCombo();

    }
}
