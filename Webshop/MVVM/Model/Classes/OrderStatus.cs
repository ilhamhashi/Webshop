namespace Webshop.MVVM.Model.Classes
{
    internal enum Status
    {
        Created,
        Processing,
        Packing,
        UnderDelivery,
        Delivered,
        Cancelled        
    }

    internal class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public Status Status { get; set; }

        public OrderStatus(int orderStatusID, Status status)
        {
            OrderStatusID = orderStatusID;
            Status = status;
        }
    }
}
