using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.util;
using Dish = OrderingSystem.Model.Dish;

namespace OrderingSystem.KioskApp.Menus
{
    public class DishesRepository : IDishRepository
    {
        public async Task<List<Dish>> RetrieveMenu()
        {
            List<Dish> mList = new List<Dish>();
            var db = MyDatabase.getInstance();
            try
            {
                var conn = await db.GetConnection();
                var command = new MySqlCommand("RetrieveDishes", conn);


                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("p_dish_id", DBNull.Value);
                command.Parameters.AddWithValue("p_isAvailable", "Yes");
                MySqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Dish m = Dish.Builder()
                            .SetMenuType(reader.GetString("menu_type"))
                            .SetMenuId(reader.GetInt32("menu_id"))
                            .SetDishID(reader.GetInt32("dish_id"))
                            .SetMenuName(reader.GetString("menu_name"))
                            .SetImage(ImageHelper.GetImageFromBlob(reader))
                            .SetDescription(reader.GetString("menu_description"))
                            .SetPrice(reader.GetDouble("price"))
                            .SetCurrentlyMaxOrder(reader.GetInt32("Max_Order"))
                            .SetCategoryId(reader.GetInt32("category_id"))
                            .Build();

                        mList.Add(m);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("di   DisplayMenu      " + ex.Message);
            }
            finally
            {
                await db.CloseConnection();
            }
            return mList;
        }
    }
}
