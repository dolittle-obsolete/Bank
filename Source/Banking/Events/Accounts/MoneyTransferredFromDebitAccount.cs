using System;
using Dolittle.Events;

namespace Events.Accounts
{
    public class MoneyTransferredFromDebitAccount : IEvent
    {
        public MoneyTransferredFromDebitAccount(Guid to, double amount)
        {
            To = to;
            Amount = amount;
        }

        public Guid To { get; }

        public double Amount { get; }
    }
}