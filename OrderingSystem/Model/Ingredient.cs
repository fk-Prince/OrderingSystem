namespace OrderingSystem.Model
{
    public class Ingredient
    {
        private string ingredient_name;
        private int quantity;

        public string Ingredient_name { get => ingredient_name; }
        public int Quantity { get => quantity; }

        public class IngredientBuilder
        {
            private readonly Ingredient ingredient;

            public IngredientBuilder SetName(string name)
            {
                this.ingredient.ingredient_name = name;
                return this;
            }

            public IngredientBuilder SetQuantity(int qty)
            {
                this.ingredient.quantity = qty;
                return this;
            }
        }
    }
}
