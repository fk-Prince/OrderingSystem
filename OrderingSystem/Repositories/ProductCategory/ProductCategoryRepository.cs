using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.Model;

namespace OrderingSystem.Repositories.Categories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public async Task<List<Category>> getProductCategories()
        {
            List<Category> a = new List<Category>();
            var db = MyDatabase.getInstance();
            try
            {
                var conn = await db.GetConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM product_category", conn);
                MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Category cz = Category.Builder()
                        .SetCategoryID(reader.GetInt32("product_category_id"))
                        .SetCategoryName(reader.GetString("product_category_name"))
                        .SetCategoryType("Product_Category")
                        .Build();
                    a.Add(cz);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await db.CloseConnection();
            }
            return a;
        }
    }
}
