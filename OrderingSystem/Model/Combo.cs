using System.Drawing;

namespace OrderingSystem.Model
{
    public class Combo : Menu
    {
        private int combo_id;

        public int Combo_id { get => combo_id; }

        public static ComboBuilder Builder() => new ComboBuilder();

        public class ComboBuilder
        {
            private readonly Combo combo;

            public ComboBuilder()
            {
                combo = new Combo();
            }
            public ComboBuilder SetPurchaseQuantity(int pQty)
            {
                this.combo.purchaseQty = pQty;
                return this;
            }
            public ComboBuilder SetCurrentlyMaxOrder(int maxOrder)
            {
                this.combo.currentlyMaxOrder = maxOrder;
                return this;
            }



            public ComboBuilder SetComboName(string name)
            {
                this.combo.menu_name = name;
                return this;
            }

            public ComboBuilder SetComboDescription(string desc)
            {
                this.combo.menu_description = desc;
                return this;
            }

            public ComboBuilder SetMenuID(int id)
            {
                this.combo.menu_id = id;
                return this;
            }

            public ComboBuilder SetComboID(int id)
            {
                this.combo.combo_id = id;
                return this;
            }

            public ComboBuilder SetItemType(string type)
            {
                this.combo.menu_type = type;
                return this;
            }

            public ComboBuilder SetPrice(double price)
            {
                this.combo.price = price;
                return this;
            }

            public ComboBuilder SetImage(Image img)
            {
                this.combo.image = img;
                return this;
            }

            public Combo Build()
            {
                return combo;
            }
        }
        public override Menu Clone()
        {
            return new Combo
            {
                menu_type = menu_type,
                menu_id = MenuID,
                menu_name = menu_name,
                price = price,
                image = image,
                currentlyMaxOrder = currentlyMaxOrder,
                purchaseQty = purchaseQty,
            };

        }

    }
}
