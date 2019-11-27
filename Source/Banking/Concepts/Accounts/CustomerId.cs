using System;
using Dolittle.Concepts;
using Dolittle.Runtime.Events;

namespace Concepts.Accounts
{
    public class CustomerId : ConceptAs<Guid>
    {
        public static implicit operator CustomerId(Guid customerId) => new CustomerId { Value = customerId };
        public static implicit operator EventSourceId(CustomerId accountId) => accountId.Value;
        public static implicit operator CustomerId(EventSourceId eventSourceId) => new CustomerId { Value = eventSourceId.Value };
    }
}