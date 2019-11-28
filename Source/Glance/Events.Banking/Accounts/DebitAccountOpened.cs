using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Banking.Accounts
{
    [Artifact("70a743d0-63df-4215-a44f-7915e835fcf8")]
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