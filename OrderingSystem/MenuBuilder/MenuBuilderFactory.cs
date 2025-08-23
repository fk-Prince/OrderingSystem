using MySqlConnector;
using OrderingSystem.Model;
using OrderingSystem.util;

namespace OrderingSystem.KioskApp.MenuBuilder
{
    public class MenuBuilderFactory
    {
        public static Menu Build(Menu menu, int qty)
        {
            switch (menu)
            {
                case Dish d:
                    return Dish.Builder()
                        .SetMenuType(d.MenuType)
                        .SetMenuId(d.MenuID)
                        .SetDishID(d.DishID)
                        .SetMenuName(d.MenuName)
                        .SetImage(d.Image)
                        .SetPrice(d.MenuPrice)
                        .SetCategoryId(d.Category_id)
                        .SetCurrentlyMaxOrder(d.CurrentlyMaxOrder)
                        .SetPurchaseQuantity(qty)
                        .Build();

                case Combo c:
                    return Combo.Builder()
                        .SetItemType(c.MenuType)
                        .SetMenuID(c.MenuID)
                        .SetComboID(c.Combo_id)
                        .SetComboName(c.MenuName)
                        .SetPrice(c.MenuPrice)
                        .SetImage(c.Image)
                        .SetCurrentlyMaxOrder(c.CurrentlyMaxOrder)
                        .SetPurchaseQuantity(qty)
                        .Build();

                case Appetizer a:
                    return Appetizer.Builder()
                        .SetMenuType(a.MenuType)
                        .SetMenuId(a.MenuID)
                        .SetAppetizerID(a.Appetizer_id)
                        .SetAppetizerName(a.MenuName)
                        .SetPrice(a.MenuPrice)
                        .SetImage(a.Image)
                        .SetCurrentlyMaxOrder(a.CurrentlyMaxOrder)
                        .SetPurchaseQuantity(qty)
                        .Build();

                default:
                    return null;
            }
        }

        public static Menu BuildFromSQL(MySqlDataReader reader)
        {
            string type = reader.GetString("menu_type").ToLower();
            switch (type)
            {
                case "dishes":
                    return Dish.Builder()
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

                case "combo":
                    return Combo.Builder()
                          .SetItemType(reader.GetString("menu_type"))
                          .SetMenuID(reader.GetInt32("menu_id"))
                          .SetComboID(reader.GetInt32("combo_id"))
                          .SetComboName(reader.GetString("menu_name"))
                          .SetImage(ImageHelper.GetImageFromBlob(reader))
                          .SetComboDescription(reader.GetString("menu_description"))
                          .SetPrice(reader.GetDouble("price"))
                          .SetCurrentlyMaxOrder(reader.GetInt32("Max_Order"))
                          .Build();

                case "appetizer":
                    return Appetizer.Builder()
                        .SetMenuType(reader.GetString("menu_type"))
                        .SetMenuId(reader.GetInt32("menu_id"))
                        .SetAppetizerName(reader.GetString("menu_name"))
                        .SetImage(ImageHelper.GetImageFromBlob(reader))
                        .SetAppetizerID(reader.GetInt32("appetizer_id"))
                        .SetDescription(reader.GetString("menu_description"))
                        .SetPrice(reader.GetDouble("price"))
                        .SetCurrentlyMaxOrder(reader.GetInt32("Max_Order"))
                        .Build();

                default:
                    return null;
            }
        }
    }
}
