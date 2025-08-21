namespace OrderingSystem.Model
{
    public class Category
    {
        private string category_name;
        private int category_id;
        private string category_type;

        public string Category_name { get => category_name; }
        public int Category_id { get => category_id; }
        public string Category_type { get => category_type; }
        public static CategoryBuilder Builder() => new CategoryBuilder();

        public class CategoryBuilder
        {
            private Category cat;
            public CategoryBuilder()
            {
                cat = new Category();
            }

            public CategoryBuilder SetCategoryName(string name)
            {
                cat.category_name = name;
                return this;
            }

            public CategoryBuilder SetCategoryID(int id)
            {
                cat.category_id = id;
                return this;
            }

            public CategoryBuilder SetCategoryType(string type)
            {
                cat.category_type = type;
                return this;
            }

            public Category Build()
            {
                return cat;
            }
        }
    }
}
