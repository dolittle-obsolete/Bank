using System.Linq;
using Concepts.Accounts;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.Accounts
{
    public class TransactionsForAccount : IQueryFor<Transaction>
    {
        private readonly IMongoCollection<AccountWithTransactions> _collection;

        public TransactionsForAccount(IMongoCollection<AccountWithTransactions> collection)
        {
            _collection = collection;
        }

        public AccountId AccountId { get; set; }

        public IQueryable<Transaction> Query => _collection.Find(_ => _.Id == AccountId).Single().Transactions.AsQueryable().OrderByDescending(_ => _.Occurred);
    }
}