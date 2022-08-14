namespace PaymentContext.Domain.ValueObjects
{
    public class Email : Shared.ValueObjects.ValueObjects
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}