using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.Model;

namespace OrderingSystem.Repositories.Categories
{
    public class MenuCategoryRepository : IMenuCategoryRepository
    {
        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();
            var db = MyDatabase.getInstance();
            try
            {
                var conn = await db.GetConnection();
                string query = @"
                                SELECT c.menu_category_id, c.menu_category_name 
                                    FROM menu_categories c 
                                INNER JOIN dishes m 
                                    ON m.category_id = c.menu_category_id 
                                GROUP BY c.menu_category_id, c.menu_category_id
                                ";
                var cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Category cz = Category.Builder()
                       .SetCategoryID(reader.GetInt32("menu_category_id"))
                       .SetCategoryName(reader.GetString("menu_category_name"))
                       .SetCategoryType("Menu_Category")
                       .Build();
                        categories.Add(cz);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await db.CloseConnection();
            }

            return categories;
        }
    }
}
