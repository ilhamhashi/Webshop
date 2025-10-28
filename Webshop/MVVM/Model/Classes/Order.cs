namespace Webshop.MVVM.Model.Classes
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int PointsUsed { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentMethodId { get; set; }

        public Order(int orderId, DateTime orderDate, int pointsUsed, int customerId, int orderStatusId, int paymentMethodId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            PointsUsed = pointsUsed;
            CustomerId = customerId;
            OrderStatusId = orderStatusId;
            PaymentMethodId = paymentMethodId;
        }

        public Order(DateTime orderDate, int pointsUsed, int customerId, int orderStatusId, int paymentMethodId)
        {
            OrderDate = orderDate;
            PointsUsed = pointsUsed;
            CustomerId = customerId;
            OrderStatusId = orderStatusId;
            PaymentMethodId = paymentMethodId;
        }
    }
}
