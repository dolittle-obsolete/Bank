using System.Linq;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.Accounts
{
    public class AllDebitAccounts : IQueryFor<Account>
    {
        public AllDebitAccounts(IMongoCollection<Account> collection) => Query = collection?.Find(_ => _.Type == AccountType.Debit).ToList().AsQueryable();

        public IQueryable<Account> Query { get; }
    }
}