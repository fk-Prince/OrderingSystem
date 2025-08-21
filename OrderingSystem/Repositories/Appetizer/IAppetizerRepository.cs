using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Appetizers
{
    public interface IAppetizerRepository
    {
        Task<List<Appetizer>> GetAppetizers();
    }
}
