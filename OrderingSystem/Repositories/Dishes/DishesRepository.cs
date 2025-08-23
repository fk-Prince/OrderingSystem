using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.KioskApp.MenuBuilder;
using Dish = OrderingSystem.Model.Dish;

namespace OrderingSystem.KioskApp.Menus
{
    public class DishesRepository : IDishRepository
    {
        public async Task<List<Dish>> RetrieveDish()
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
                        Dish m = (Dish)MenuBuilderFactory.BuildFromSQL(reader);
                        mList.Add(m);
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await db.CloseConnection();
            }
            return mList;
        }
    }
}
