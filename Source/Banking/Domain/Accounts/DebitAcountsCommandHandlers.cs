using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Accounts
{
    public class DebitAcountsCommandHandlers : ICanHandleCommands
    {
        private readonly IAggregateOf<DebitAccounts> _debitAccounts;

        public DebitAcountsCommandHandlers(IAggregateOf<DebitAccounts> debitAccounts)
        {
            _debitAccounts = debitAccounts;
        }

        public void Handle(OpenDebitAccount command)
        {
            _debitAccounts
                .Rehydrate(command.CustomerId)
                .Perform(_ => _.Open(Guid.NewGuid(), command.Name));
        }
    }
}