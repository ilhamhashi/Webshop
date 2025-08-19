namespace Webshop.MVVM.Model.Classes
{
    internal class DeliveryMethod
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DeliveryTime { get; set; }
        public double Price { get; set; }

        public DeliveryMethod(int iD, string name, string deliveryTime, double price)
        {
            ID = iD;
            Name = name;
            DeliveryTime = deliveryTime;
            Price = price;
        }
    }
}
