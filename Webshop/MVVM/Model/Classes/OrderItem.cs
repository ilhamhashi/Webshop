namespace Webshop.MVVM.Model.Classes
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool SelectedToCart { get; set; }

        public OrderItem(int orderId, int productId, int quantity, double price, bool selectedToCart)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            SelectedToCart = selectedToCart;
        }

        public OrderItem(int productId, int quantity, double price, bool selectedToCart)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            SelectedToCart = selectedToCart;
        }
    }
}
