using System;
using Dolittle.Events;
using Dolittle.Events.Processing;
using Dolittle.Execution;
using Dolittle.Runtime.Events;
using Events.Accounts;
using MongoDB.Driver;

namespace Read.Accounts
{
    public class AccountEventProcessors : ICanProcessEvents
    {
        private readonly IMongoCollection<Account> _collection;
        readonly IMongoCollection<EventProcessExecution> _processings;

        public AccountEventProcessors(IMongoCollection<Account> collection, IMongoCollection<EventProcessExecution> processings)
        {
            _collection = collection;
            _processings = processings;
        }

        [EventProcessor("c93703be-e2c7-4df5-9c60-45205b47489d")]
        public void Process(DebitAccountOpened @event, EventMetadata eventMetadata)
        {
            var execution = InitiateTracking(@event,eventMetadata);
            _collection.InsertOne(new Account
            {
                Id = @event.AccountId,
                CustomerId = eventMetadata.EventSourceId,
                Type = AccountType.Debit
            });
            CompleteTracking(execution);
        }

        [EventProcessor("cfe42fdf-da6b-412d-a112-846e807802b7")]
        public void Process(BalanceChanged @event, EventMetadata eventMetadata)
        {
            var updateDefinition = Builders<Account>.Update
                .Set(_ => _.Balance, @event.NewBalance);

            _collection.UpdateOne(_ => _.Id == eventMetadata.EventSourceId, updateDefinition);
        }

        EventProcessExecution InitiateTracking( IEvent @event, EventMetadata eventMetadata)
        {
            return new EventProcessExecution
            {
                EventProcessor = this.GetType().FullName,
                StartTime = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid(),
                EventType = @event.GetType().FullName,
                CorrelationId = eventMetadata.CorrelationId,
                Occurred = eventMetadata.Occurred
            };
        }

        void CompleteTracking(EventProcessExecution execution)
        {
            execution.EndTime = DateTimeOffset.UtcNow;
            execution.CalculateDuration();
            _processings.InsertOne(execution);
        }
    }

    public class EventProcessExecution
    {
        public Guid Id { get; set; }
        public CorrelationId CorrelationId { get; set; }
        public string EventType { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        
        public DateTimeOffset Occurred { get; set; }
        public string EventProcessor { get; set; }
        public TimeSpan Duration { get; set; }
        
        public TimeSpan Latency { get; set; }

        public void CalculateDuration()
        {
            Duration = EndTime - StartTime;
            Latency = StartTime - Occurred;
        }
    }
}