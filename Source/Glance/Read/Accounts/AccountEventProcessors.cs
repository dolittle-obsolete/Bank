using System;
using Dolittle.Events.Processing;
using Dolittle.Logging;
using Dolittle.Runtime.Events;
using Events.Banking.Accounts;
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

        [EventProcessor("4e5746d0-417e-4410-94a8-3ed198e6177c")]
        public void Process(DebitAccountOpened @event, EventMetadata eventMetadata)
        {
            _collection.InsertOne(new Account
            {
                Id = @event.AccountId,
                CustomerId = eventMetadata.EventSourceId,
                Name = @event.Name
            });
        }

        [EventProcessor("2fcc4219-320a-4135-b18f-03ff106bd286")]
        public void Process(BalanceChanged @event, EventMetadata eventMetadata)
        {
            var accounts = _collection.Find(_ => true).ToList();

            var updateDefinition = Builders<Account>.Update
                .Set(_ => _.Balance, @event.NewBalance);

            _collection.UpdateOne(_ => _.Id == eventMetadata.EventSourceId, updateDefinition);
        }
    }
}