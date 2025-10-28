namespace Webshop.MVVM.Model.Classes
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category(int id, string name)
        {
            CategoryId = id;
            CategoryName = name;
        }

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
