namespace Webshop.MVVM.Model.Classes
{
    internal class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        public Product Product { get; set; }
        public int OrderID { get; set; }
        public int ShoppingCartID { get; set; }

        public OrderLine(int id, int quantity, double subTotal, Product product, int orderID, int shoppingCartID)
        {
            Id = id;
            Quantity = quantity;
            SubTotal = subTotal;
            Product = product;
            OrderID = orderID;
            ShoppingCartID = shoppingCartID;
        }
    }
}
