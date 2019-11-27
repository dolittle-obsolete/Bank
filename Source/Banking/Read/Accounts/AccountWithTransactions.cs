using System.Collections.Generic;
using Concepts.Accounts;
using Dolittle.ReadModels;

namespace Read.Accounts
{
    public class AccountWithTransactions : IReadModel
    {
        public AccountId Id { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}