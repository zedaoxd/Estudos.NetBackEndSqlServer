using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.entities;

namespace PaymentContext.Domain.entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments;

        public Subscription(DateTime? expireDate)
        {
            CareateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CareateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments => _payments.ToArray();

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payment", "A data do pagamento deve ser futura")
            );

            // if (IsValid) // Só adciona se for válido
            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Disable()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}