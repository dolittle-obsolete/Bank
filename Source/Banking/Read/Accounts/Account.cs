using Concepts.Accounts;
using Dolittle.ReadModels;

namespace Read.Accounts
{
    public class Account : IReadModel
    {
        public AccountId Id { get; set; }
        public CustomerId CustomerId {  get; set; }

        public AccountType Type { get; set; }

        public double Balance { get; set; }
    }
}