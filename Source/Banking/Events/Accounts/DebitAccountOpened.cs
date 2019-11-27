using System;
using Dolittle.Events;

namespace Events.Accounts
{
    public class DebitAccountOpened : IEvent
    {
        public DebitAccountOpened(Guid accountId, string name)
        {
            AccountId = accountId;
            Name = name;
        }

        public Guid AccountId { get; }
        public string Name { get; }
    }
}