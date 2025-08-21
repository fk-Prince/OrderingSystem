using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Combos
{
    public class ComboRepository : IComboRepository
    {
        public async Task<List<Combo>> RetrieveCombo()
        {
            List<Combo> cList = new List<Combo>();
            var db = MyDatabase.getInstance();

            try
            {
                var conn = await db.GetConnection();
                var cmd = new MySqlCommand("RetrieveCombo", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_combo_id", DBNull.Value);
                cmd.Parameters.AddWithValue("p_isAvailable", "Yes");

                MySqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Combo m = Combo.Builder()
                          .SetItemType(reader.GetString("menu_type"))
                          .SetMenuID(reader.GetInt32("menu_id"))
                          .SetComboID(reader.GetInt32("combo_id"))
                          .SetComboName(reader.GetString("menu_name"))
                          .SetComboDescription(reader.GetString("menu_description"))
                          .SetPrice(reader.GetDouble("price"))
                          .SetCurrentlyMaxOrder(reader.GetInt32("Max_Order"))
                          .Build();
                        cList.Add(m);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("xx");
            }
            finally
            {
                await db.CloseConnection();
            }
            return cList;
        }
    }
}
