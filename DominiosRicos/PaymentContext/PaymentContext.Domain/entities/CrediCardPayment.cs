namespace PaymentContext.Domain.entities
{
    public class CrediCardPayment : Payment
    {
        public string CardHoldName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }
}