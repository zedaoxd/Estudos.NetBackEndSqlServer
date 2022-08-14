using Flunt.Notifications;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : Shared.ValueObjects.ValueObjects
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsEmail(Address, "Email.Address", "Email invalido")
            );
        }

        public string Address { get; private set; }
    }
}