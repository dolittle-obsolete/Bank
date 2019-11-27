using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.MyBC1.Accounts
{
    [Artifact("32ef580e-06fc-463b-b490-2b5e9adfd967")]
    public class AccountOpened : IEvent
    {
        public AccountOpened(string owner)
        {
            Owner = owner;
        }

        public string Owner { get; }
    }
}