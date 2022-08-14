namespace PaymentContext.Domain.entities
{
    public class Subscription
    {
        public DateTime CareateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Active { get; set; }
        public List<Payment> Payments { get; set; }
    }
}