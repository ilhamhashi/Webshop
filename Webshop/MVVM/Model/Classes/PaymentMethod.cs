namespace Webshop.MVVM.Model.Classes
{
    internal class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PaymentMethod(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
