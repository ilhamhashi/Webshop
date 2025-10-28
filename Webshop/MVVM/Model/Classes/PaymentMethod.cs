namespace Webshop.MVVM.Model.Classes
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }

        public PaymentMethod(int paymentMethodId, string paymentMethodName)
        {
            PaymentMethodId = paymentMethodId;
            PaymentMethodName = paymentMethodName;
        }

        public PaymentMethod(string paymentMethodName)
        {
            PaymentMethodName = paymentMethodName;
        }
    }
}
