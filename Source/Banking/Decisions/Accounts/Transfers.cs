using Dolittle.Events.Processing;
using Events.Accounts;

namespace Decisions.Accounts
{
    public class Transfers
    {
        /*
        private readonly IAggregateOf<Account> _account;

        public Transfers(IAggregateOf<Account> account)
        {
            _account = account;
        }
        
        [EventProcessor("cd44f83d-b5f8-4a73-a7aa-1e5993771da0")]
        public void Process(DepositPerformedToDebitAccountFromOtherAccount @event, EventMetadata eventMetadata)
        {
            _account
                .Rehydrate(eventMetadata.EventSourceId)
                .Perform(_ => _.DepositFromOtherAccount(@event.From, @event.Amount));
        }*/
    }
}