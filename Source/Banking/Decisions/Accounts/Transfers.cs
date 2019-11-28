using Dolittle.Events.Processing;
using Events.Accounts;
using Domain.Accounts;
using Dolittle.Runtime.Events;

namespace Decisions.Accounts
{
    public class Transfers : ICanProcessEvents
    {
        private readonly IReactions _reactions;

        public Transfers(IReactions reactions) => _reactions = reactions;

        [EventProcessor("cd44f83d-b5f8-4a73-a7aa-1e5993771da0")]
        public void Process(MoneyTransferredFromDebitAccount @event, EventMetadata eventMetadata)
        {
            _reactions.AggregateRoot<DebitAccount>(a => a
                .Rehydrate(@event.To)
                .Perform(_ => _.DepositFromOtherAccount(eventMetadata.EventSourceId, @event.Amount))
            );
        }
    }
}