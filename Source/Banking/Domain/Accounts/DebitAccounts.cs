using System.Collections.Generic;
using Concepts.Accounts;
using Dolittle.Domain;
using Dolittle.Rules;
using Dolittle.Runtime.Events;
using Events.Accounts;

namespace Domain.Accounts
{
    public class DebitAccounts : AggregateRoot
    {
        List<string>    _accounts = new List<string>();

        static Reason AccountNameAlreadyExists = Reason.Create("cd13df2e-daad-4f5b-9bee-2fff38baec21", "Account with {Name} already exists");

        public DebitAccounts(EventSourceId eventSourceId) : base(eventSourceId) { }

        public void Open(AccountId accountId, string name)
        {
            if( Evaluate(() => AccountNameShouldBeUnique(name)) )
                Apply(new DebitAccountOpened(accountId, name));
        }

        private RuleEvaluationResult AccountNameShouldBeUnique(string name)
        {
            if( _accounts.Contains(name) ) return RuleEvaluationResult.Fail(name, AccountNameAlreadyExists.WithArgs(new{Name=name}));
            return RuleEvaluationResult.Success;
        }

        void On(DebitAccountOpened @event)
        {
            _accounts.Add(@event.Name);
        }
    }
}