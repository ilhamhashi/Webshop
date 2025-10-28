namespace Webshop.MVVM.Model.Classes
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderId { get; set; }

        public Shipment(int shipmentId, DateTime shipmentDate, int orderId)
        {
            ShipmentId = shipmentId;
            ShipmentDate = shipmentDate;
            OrderId = orderId;
        }

        public Shipment(DateTime shipmentDate, int orderId)
        {
            ShipmentDate = shipmentDate;
            OrderId = orderId;
        }
    }
}
