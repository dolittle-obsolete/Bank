using System;
using Dolittle.ReadModels;

namespace Read.Accounts
{
    public class Transaction : IReadModel
    {
        public TransactionReason Reason { get; set; }
        public double Amount { get; set; }

        public DateTimeOffset Occurred { get; set; }
    }
}