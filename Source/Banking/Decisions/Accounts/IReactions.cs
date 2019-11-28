using System;
using Dolittle.Domain;

namespace Decisions.Accounts
{
    public interface IReactions
    {
        void AggregateRoot<T>(Action<IAggregateOf<T>> callback) where T : class, IAggregateRoot;
    }
}
