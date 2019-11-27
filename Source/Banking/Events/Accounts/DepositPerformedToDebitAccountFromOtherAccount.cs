using System;
using Dolittle.Events;

namespace Events.Accounts
{
    public class DepositPerformedToDebitAccountFromOtherAccount : IEvent
    {
        public DepositPerformedToDebitAccountFromOtherAccount(Guid from, double amount)
        {
            From = from;
            Amount = amount;
        }

        public Guid From { get; }

        public double Amount { get; }
    }
}