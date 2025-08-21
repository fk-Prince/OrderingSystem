using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using Newtonsoft.Json;
using OrderingSystem.Database;
using OrderingSystem.Model;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApp.AddsOn
{
    public class AddonRepository : IAddonRepository
    {


        public async Task<List<Addon>> getAddsOnByMenu(int id, List<Menu> cartList)
        {
            List<Addon> l = new List<Addon>();
            var db = MyDatabase.getInstance();
            try
            {


                var conn = await db.GetConnection();
                MySqlCommand cmd = new MySqlCommand("RetrieveAddFromJson", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                string json = JsonConvert.SerializeObject(cartList);
                cmd.Parameters.AddWithValue("@p_menu_data", json);
                MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    l.Add(
                         Addon.Builder()
                            .SetAddsOnID(reader.GetInt32("adds_id"))
                            .SetAddsOnIngredientID(reader.GetInt32("ingredient_id"))
                            .SetAddsOnPrice(reader.GetDouble("price"))
                            .SetAddsOnName(reader.GetString("adds_name"))
                            .SetAddsOnMaxOrder(reader.GetInt32("min_max_order"))
                            .Build()
                     );

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
            return l;
        }
    }
}
