using System.Collections.Generic;
using System.Drawing;

namespace OrderingSystem.Model
{
    public class Dish : Menu
    {
        private List<Addon> addon;
        private List<Ingredient> ingredientList;
        private int dish_id;
        public int DishID { get => dish_id; }
        public List<Addon> AddsOnPurchase { get => addon; }


        private Dish()
        {
            addon = new List<Addon>();
            ingredientList = new List<Ingredient>();
        }


        public void AddOnPurchase(Addon item)
        {
            addon.Add(item);
        }
        public static DishBuilder Builder() => new DishBuilder();

        public class DishBuilder
        {
            private readonly Dish menu;

            public DishBuilder()
            {
                menu = new Dish();
            }
            public DishBuilder SetCategoryId(int id)
            {
                this.menu.category_id = id;
                return this;
            }
            public DishBuilder SetPurchaseQuantity(int pQty)
            {
                this.menu.purchaseQty = pQty;
                return this;
            }
            public DishBuilder SetCurrentlyMaxOrder(int maxOrder)
            {
                this.menu.currentlyMaxOrder = maxOrder;
                return this;
            }

            public DishBuilder SetMenuName(string name)
            {
                this.menu.menu_name = name;
                return this;
            }


            public DishBuilder SetDescription(string desc)
            {
                this.menu.menu_description = desc;
                return this;
            }
            public DishBuilder SetMenuId(int id)
            {
                this.menu.menu_id = id;
                return this;
            }

            public DishBuilder SetDishID(int id)
            {
                this.menu.dish_id = id;
                return this;
            }

            public DishBuilder SetMenuType(string type)
            {
                this.menu.menu_type = type;
                return this;
            }

            public DishBuilder SetPrice(double price)
            {
                this.menu.price = price;
                return this;
            }

            public DishBuilder SetImage(Image img)
            {
                this.menu.image = img;
                return this;
            }

            public DishBuilder SetAddIngredient(Ingredient ingredient)
            {
                this.menu.ingredientList.Add(ingredient);
                return this;
            }

            public Dish Build()
            {
                return menu;
            }
        }

        public override Menu Clone()
        {
            return new Dish
            {
                menu_type = menu_type,
                menu_id = MenuID,
                menu_name = menu_name,
                price = price,
                image = image,
                menu_description = menu_description,
                currentlyMaxOrder = currentlyMaxOrder,
                category_id = category_id,
                addon = addon,
                purchaseQty = purchaseQty,
                dish_id = dish_id,
            };

        }
    }
}
