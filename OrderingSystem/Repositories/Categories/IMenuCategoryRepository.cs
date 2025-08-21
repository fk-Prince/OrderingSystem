using System.Collections.Generic;
using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.Repositories.Categories
{
    public interface IMenuCategoryRepository
    {
        Task<List<Category>> GetCategories();
    }
}
