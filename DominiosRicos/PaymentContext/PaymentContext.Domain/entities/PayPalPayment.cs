namespace PaymentContext.Domain.entities
{
    public class PayPalPayment : Payment
    {
        public string TranscationCode { get; set; }
    }
}