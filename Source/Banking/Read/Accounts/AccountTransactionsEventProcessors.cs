using Concepts.Accounts;
using Dolittle.Events.Processing;
using Dolittle.Runtime.Events;
using Events.Accounts;
using MongoDB.Driver;

namespace Read.Accounts
{
    public class AccountTransactionsEventProcessors : ICanProcessEvents
    {
        private readonly IMongoCollection<AccountWithTransactions> _collection;

        public AccountTransactionsEventProcessors(IMongoCollection<AccountWithTransactions> collection)
        {
            _collection = collection;
        }

        [EventProcessor("0c91df1f-5c9f-4828-96e4-7dd0bf9ddcba")]
        public void Process(DebitAccountOpened @event, EventMetadata eventMetadata)
        {
            _collection.InsertOne(new AccountWithTransactions { Id = eventMetadata.EventSourceId });
        }


        [EventProcessor("728ed57b-be04-4da7-97b1-bb914e77cb9f")]
        public void Process(WithdrawalPerformedFromDebitAccount @event, EventMetadata eventMetadata)
        {
            AddTransaction(eventMetadata.EventSourceId, -@event.Amount);
        }

        [EventProcessor("4f7497b8-2de8-4b8f-842f-c88f634644d4")]
        public void Process(DepositPerformedToDebitAccount @event, EventMetadata eventMetadata)
        {
            AddTransaction(eventMetadata.EventSourceId, @event.Amount);
        }

        [EventProcessor("c3e03466-793d-4210-a85f-ff4d419dfb3d")]
        public void Process(MoneyTransferredFromDebitAccount @event, EventMetadata eventMetadata)
        {
            AddTransaction(eventMetadata.EventSourceId, -@event.Amount);
        }

        private void AddTransaction(AccountId accountId, double amount)
        {
            var account = _collection.Find(_ => _.Id == accountId).SingleOrDefault();
            if (account != null)
            {
                account.Transactions.Add(amount);
                _collection.ReplaceOne(_ => _.Id == accountId, account);
            }
        }
    }
}