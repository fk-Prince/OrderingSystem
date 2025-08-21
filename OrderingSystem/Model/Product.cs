using System.Collections.Generic;
using System.Drawing;

namespace OrderingSystem.Model
{
    public class Product : Menu
    {

        private List<Variant> variantList;
        private Variant variantPurchased;

        public Product()
        {
            variantList = new List<Variant>();
        }

        public Variant Variant { get => variantPurchased; set => variantPurchased = value; }
        public List<Variant> VariantList { get => variantList; set => variantList = value; }
        public static ProductBuilder Builder() => new ProductBuilder();
        public override Menu Clone()
        {
            return new Product
            {
                menu_type = menu_type,
                menu_id = MenuID,
                menu_name = menu_name,
                price = price,
                image = image,
                currentlyMaxOrder = currentlyMaxOrder,
                purchaseQty = purchaseQty,
                variantList = variantList,
                Variant = Variant,
                category_id = category_id
            };

        }
        public class ProductBuilder
        {
            private readonly Product product;

            public ProductBuilder SetProductCategoryID(int id)
            {
                this.product.category_id = id;
                return this;
            }
            public ProductBuilder SetVariantPurchase(Variant variant)
            {
                this.product.Variant = variant;
                return this;
            }
            public ProductBuilder SetVariantList(List<Variant> variantList)
            {
                this.product.variantList = variantList;
                return this;
            }
            public ProductBuilder()
            {
                product = new Product();
            }
            public ProductBuilder SetPurchaseQuantity(int pQty)
            {
                this.product.purchaseQty = pQty;
                return this;
            }
            public ProductBuilder SetMaxOrder(int maxOrder)
            {
                this.product.currentlyMaxOrder = maxOrder;
                return this;
            }
            public ProductBuilder SetMenuType(string name)
            {
                this.product.menu_type = name;
                return this;
            }
            public ProductBuilder SetProductName(string name)
            {
                this.product.menu_name = name;
                return this;
            }

            public ProductBuilder SetProductDescription(string desc)
            {
                this.product.menu_description = desc;
                return this;
            }

            public ProductBuilder SetProductID(int id)
            {
                this.product.menu_id = id;
                return this;
            }

            public ProductBuilder SetItemType(string type)
            {
                this.product.menu_type = type;
                return this;
            }

            public ProductBuilder SetPrice(double price)
            {
                this.product.price = price;
                return this;
            }

            public ProductBuilder SetImage(Image img)
            {
                this.product.image = img;
                return this;
            }

            public Product Build()
            {
                return product;
            }
        }
    }
}
