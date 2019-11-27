using Dolittle.Events;

namespace Events.Accounts
{
    public class DepositPerformedToDebitAccount : IEvent
    {
        public DepositPerformedToDebitAccount(double amount)
        {
            Amount = amount;
        }

        public double Amount { get; }
    }
}