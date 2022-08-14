using Flunt.Notifications;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : Shared.ValueObjects.ValueObjects
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .IsLowerThan(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(FirstName, 40, "Nome.FirstName", "Nome deve ter menos de 40 caracteres")
                .IsGreaterThan(LastName, 40, "Nome.LastName", "Sobrenome deve ter menos de 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

    }
}