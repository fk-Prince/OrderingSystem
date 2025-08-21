using System.Drawing;

namespace OrderingSystem.Model
{
    public class Appetizer : Menu
    {
        private int appetizer_id;

        public int Appetizer_id { get => appetizer_id; }

        public static AppetizerBuilder Builder() => new AppetizerBuilder();

        public class AppetizerBuilder
        {
            private readonly Appetizer appetizer;

            public AppetizerBuilder()
            {
                appetizer = new Appetizer();
            }

            public AppetizerBuilder SetPurchaseQuantity(int pQty)
            {
                this.appetizer.purchaseQty = pQty;
                return this;
            }
            public AppetizerBuilder SetCurrentlyMaxOrder(int maxOrder)
            {
                this.appetizer.CurrentlyMaxOrder = maxOrder;
                return this;
            }
            public AppetizerBuilder SetAppetizerName(string name)
            {
                this.appetizer.menu_name = name;
                return this;
            }

            public AppetizerBuilder SetMenuId(int id)
            {
                this.appetizer.menu_id = id;
                return this;
            }
            public AppetizerBuilder SetDescription(string desc)
            {
                this.appetizer.menu_description = desc;
                return this;
            }

            public AppetizerBuilder SetAppetizerID(int id)
            {
                this.appetizer.appetizer_id = id;
                return this;
            }

            public AppetizerBuilder SetMenuType(string type)
            {
                this.appetizer.menu_type = type;
                return this;
            }

            public AppetizerBuilder SetPrice(double price)
            {
                this.appetizer.price = price;
                return this;
            }

            public AppetizerBuilder SetImage(Image img)
            {
                this.appetizer.image = img;
                return this;
            }

            public Appetizer Build()
            {
                return appetizer;
            }
        }

        public override Menu Clone()
        {
            return new Appetizer
            {
                menu_type = menu_type,
                menu_id = MenuID,
                menu_name = menu_name,
                price = price,
                image = image,
                currentlyMaxOrder = currentlyMaxOrder,
                purchaseQty = purchaseQty,
                appetizer_id = appetizer_id,
            };
        }
    }
}
