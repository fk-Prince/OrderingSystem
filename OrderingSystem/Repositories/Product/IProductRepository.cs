using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Products
{
    public interface IProductRepository
    {

        Task<List<Product>> GetProducts();
    }
}
