namespace Webshop.MVVM.Model.Classes
{
    internal class ShoppingCart
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }

        public ShoppingCart(int id, int customerID)
        {
            Id = id;
            CustomerID = customerID;
        }
    }
}
