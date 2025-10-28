namespace Webshop.MVVM.Model.Classes
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public Product(int productId, string productName, int categoryId, double productPrice, int stockQuantity)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            Price = productPrice;
            StockQuantity = stockQuantity;
        }

        public Product(string productName, int categoryId, double productPrice, int stockQuantity)
        {
            ProductName = productName;
            CategoryId = categoryId;
            Price = productPrice;
            StockQuantity = stockQuantity;
        }
    }
}
