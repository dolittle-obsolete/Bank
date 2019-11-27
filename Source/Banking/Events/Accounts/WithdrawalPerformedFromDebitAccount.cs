using Dolittle.Events;

namespace Events.Accounts
{
    public class WithdrawalPerformedFromDebitAccount : IEvent
    {
        public WithdrawalPerformedFromDebitAccount(double amount)
        {
            Amount = amount;
        }

        public double Amount { get; }
    }
}