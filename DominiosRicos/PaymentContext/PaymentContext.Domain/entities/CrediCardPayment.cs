using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.entities
{
    public class CrediCardPayment : Payment
    {
        public CrediCardPayment(string cardHoldName,
                                string cardNumber,
                                string lastTransactionNumber,
                                DateTime paidDate,
                                DateTime expireDate,
                                decimal total,
                                decimal totalPaid,
                                string payer,
                                Document document,
                                Address address,
                                Email email)
            : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
        {
            CardHoldName = cardHoldName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHoldName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}