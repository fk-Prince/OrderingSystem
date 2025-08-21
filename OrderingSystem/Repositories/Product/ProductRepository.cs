using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApp.Products
{
    public class ProductRepository : IProductRepository
    {
        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = new List<Product>();
            var db = MyDatabase.getInstance();
            try
            {
                var conn = await db.GetConnection();
                var cmd = new MySqlCommand("RetrieveProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_product_id", DBNull.Value);
                cmd.Parameters.AddWithValue("p_variant_id", DBNull.Value);
                cmd.Parameters.AddWithValue("p_isAvailable", "Yes");

                MySqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        string v = reader.GetString("pvid_name_Price_Stock");
                        List<Variant> vList = new List<Variant>();

                        string[] outerParts = v.Split(',');
                        foreach (string texts in outerParts)
                        {
                            string[] parts = texts.Trim().Split('|');
                            vList.Add(
                                Variant.Builder()
                                .SetVaraintId(int.Parse(parts[0].Trim()))
                                .SetVaraintName(parts[1].Trim())
                                .SetVaraintPrice(double.Parse(parts[2].Trim()))
                                .SetCurrentlyMaxOrder(int.Parse(parts[3].Trim()))
                                .Build()
                            );
                        }

                        Product p = Product.Builder()
                            .SetMenuType(reader.GetString("item_type"))
                            .SetProductID(reader.GetInt32("product_id"))
                            .SetProductCategoryID(reader.GetInt32("product_category_id"))
                            .SetProductName(reader.GetString("product_name"))
                            .SetProductDescription(reader.GetString("product_description"))
                            .SetVariantList(vList)
                            .Build();

                        products.Add(p);
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
            return products;
        }
    }
}
