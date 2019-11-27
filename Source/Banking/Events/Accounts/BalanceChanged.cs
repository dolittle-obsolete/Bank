using Dolittle.Events;

namespace Events.Accounts
{
    public class BalanceChanged : IEvent
    {
        public BalanceChanged(double oldBalance, double newBalance)
        {
            OldBalance = oldBalance;
            NewBalance = newBalance;
        }

        public double OldBalance { get; }
        public double NewBalance { get; }
    }
}