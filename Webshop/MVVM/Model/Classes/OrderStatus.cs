namespace Webshop.MVVM.Model.Classes
{ 
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public string OrderStatusName { get; set; }

        public OrderStatus(int orderStatusID, string orderStatusName)
        {
            OrderStatusID = orderStatusID;
            OrderStatusName = orderStatusName;
        }

        public OrderStatus(string orderStatusName)
        {
            OrderStatusName = orderStatusName;
        }
    }
}
