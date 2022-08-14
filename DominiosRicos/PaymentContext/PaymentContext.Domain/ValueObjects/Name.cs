namespace PaymentContext.Domain.ValueObjects
{
    public class Name : Shared.ValueObjects.ValueObjects
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;


            if (string.IsNullOrEmpty(FirstName))
                AddNotification("FirstName", "Nome inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

    }
}