namespace Webshop.MVVM.Model.Classes
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public Order(int id, DateTime createdDate, double totalDiscount, double totalPrice, Customer customer, OrderStatus orderStatus, DeliveryMethod deliveryMethod, PaymentMethod paymentMethod)
        {
            Id = id;
            CreatedDate = createdDate;
            TotalDiscount = totalDiscount;
            TotalPrice = totalPrice;
            Customer = customer;
            OrderStatus = orderStatus;
            DeliveryMethod = deliveryMethod;
            PaymentMethod = paymentMethod;
        }
    }
}
