
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.Model;
using OrderingSystem.util;

namespace OrderingSystem.KioskApp.Appetizers
{
    public class AppetizerRepository : IAppetizerRepository
    {
        public async Task<List<Appetizer>> GetAppetizers()
        {
            List<Appetizer> appList = new List<Appetizer>();
            var db = MyDatabase.getInstance();
            try
            {
                var conn = await db.GetConnection();
                var cmd = new MySqlCommand("RetrieveAppetizer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_appetizer_id", DBNull.Value);
                cmd.Parameters.AddWithValue("p_isAvailable", "Yes");

                MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Appetizer app = Appetizer.Builder()
                        .SetMenuType(reader.GetString("menu_type"))
                        .SetMenuId(reader.GetInt32("menu_id"))
                        .SetAppetizerName(reader.GetString("menu_name"))
                        .SetImage(ImageHelper.GetImageFromBlob(reader))
                        .SetAppetizerID(reader.GetInt32("appetizer_id"))
                        .SetDescription(reader.GetString("menu_description"))
                        .SetPrice(reader.GetDouble("price"))
                        .SetCurrentlyMaxOrder(reader.GetInt32("Max_Order"))
                        .Build();

                    appList.Add(app);
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

            return appList;
        }
    }
}
