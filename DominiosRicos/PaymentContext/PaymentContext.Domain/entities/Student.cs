using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.entities;

namespace PaymentContext.Domain.entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionsActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasSubscriptionsActive = true;
                }

                // AddNotifications(new Contract<Notification>()
                //     .Requires() 
                //     .IsFalse(hasSubscriptionsActive, "Sudent.subscriptions", "Este aluno já tem uma assinatura ativa")
                // );

                // or 

                if (hasSubscriptionsActive)
                    AddNotification("Sudent.subscriptions", "Este aluno já tem uma assinatura ativa");
            }
        }
    }
}