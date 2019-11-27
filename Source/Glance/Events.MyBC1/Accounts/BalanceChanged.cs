using System;
using Dolittle.Events;

namespace Events.Banking.Accounts
{
    [Artifact("46562c90-db14-4e7f-bc21-d27552baac20")]
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