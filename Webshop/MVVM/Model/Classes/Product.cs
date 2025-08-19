namespace Webshop.MVVM.Model.Classes
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }

        public Product(int id, string name, string description, int price, int stock, string imagePath, int categoryID)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ImagePath = imagePath;
            CategoryID = categoryID;
        }
    }
}
