using Dolittle.Events.Processing;
using Dolittle.Runtime.Events;
using Events.Accounts;
using MongoDB.Driver;

namespace Read.Accounts
{
    public class AccountEventProcessors : ICanProcessEvents
    {
        private readonly IMongoCollection<Account> _collection;

        public AccountEventProcessors(IMongoCollection<Account> collection)
        {
            _collection = collection;
        }

        [EventProcessor("c93703be-e2c7-4df5-9c60-45205b47489d")]
        public void Process(DebitAccountOpened @event, EventMetadata eventMetadata)
        {
            _collection.InsertOne(new Account
            {
                Id = @event.AccountId,
                CustomerId = eventMetadata.EventSourceId,
                Type = AccountType.Debit
            });
        }

        [EventProcessor("cfe42fdf-da6b-412d-a112-846e807802b7")]
        public void Process(BalanceChanged @event, EventMetadata eventMetadata)
        {
            var updateDefinition = Builders<Account>.Update
                .Set(_ => _.Balance, @event.NewBalance);

            _collection.UpdateOne(_ => _.Id == eventMetadata.EventSourceId, updateDefinition);
        }
    }
}