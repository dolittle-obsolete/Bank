using System.Linq;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.Accounts
{
    public class AllAccounts : IQueryFor<Account>
    {
        public AllAccounts(IMongoCollection<Account> collection) => Query = collection?.AsQueryable();

        public IQueryable<Account> Query { get; }
    }
}