using System;
using System.Drawing;

namespace OrderingSystem.Model
{
    public class Menu
    {
        protected string menu_type;
        protected int menu_id;
        protected string menu_name;
        protected double price;
        protected Image image;
        protected int currentlyMaxOrder;
        protected int purchaseQty;
        protected string menu_description;
        protected TimeSpan estimated_time;
        protected int category_id;


        public string MenuDescription => menu_description;
        public string MenuType => menu_type;
        public string MenuName => menu_name;
        public int MenuID => menu_id;

        public int CurrentlyMaxOrder { get => currentlyMaxOrder; set => currentlyMaxOrder = value; }
        public double MenuPrice => price;
        public Image Image => image;

        public int Purchase_Qty { get => purchaseQty; set => purchaseQty = value; }

        public TimeSpan Estimated_time { get => estimated_time; }
        public int Category_id { get => category_id; }

        public virtual Menu Clone()
        {
            return new Menu
            {
                menu_type = menu_type,
                menu_id = MenuID,
                menu_name = menu_name,
                menu_description = menu_description,
                price = price,
                image = image,
                currentlyMaxOrder = currentlyMaxOrder,
                purchaseQty = purchaseQty,
                category_id = category_id,
                estimated_time = estimated_time
            };

        }
    }
}
