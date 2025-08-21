namespace OrderingSystem.Model
{
    public class Variant : Menu
    {
        //private int variant_id;
        //private string variant_name;
        //private int variant_stock;
        //private double variant_price;
        //private int purchaseQuantity;



        public static VariantBuilder Builder() => new VariantBuilder();

        public class VariantBuilder
        {
            private Variant variant;

            public VariantBuilder()
            {
                variant = new Variant();
            }

            public VariantBuilder SetVaraintId(int variant_id)
            {
                this.variant.menu_id = variant_id;
                return this;
            }

            public VariantBuilder SetVaraintName(string name)
            {
                this.variant.menu_name = name;
                return this;
            }

            public VariantBuilder SetCurrentlyMaxOrder(int stock)
            {
                this.variant.currentlyMaxOrder = stock;
                return this;
            }


            public VariantBuilder SetVaraintPrice(double price)
            {
                this.variant.price = price;
                return this;
            }

            public Variant Build()
            {
                return variant;
            }

        }
    }
}
