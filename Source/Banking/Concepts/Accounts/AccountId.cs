using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Concepts.Accounts
{
    public class AccountId : ConceptAs<Guid>
    {
        public static implicit operator AccountId(Guid accountId) => new AccountId { Value = accountId };
        public static implicit operator EventSourceId(AccountId accountId) => accountId.Value;
        public static implicit operator AccountId(EventSourceId eventSourceId) => new AccountId { Value = eventSourceId.Value };
    }
}