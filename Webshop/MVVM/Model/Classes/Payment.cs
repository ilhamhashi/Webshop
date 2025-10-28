namespace Webshop.MVVM.Model.Classes
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public int OrderId { get; set; }

    }
}
