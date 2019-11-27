using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Accounts
{
    public class DebitAccountCommandHandlers : ICanHandleCommands
    {
        private readonly IAggregateOf<DebitAccount> _account;

        public DebitAccountCommandHandlers(IAggregateOf<DebitAccount> account)
        {
            _account = account;
        }

        public void Handle(WithdrawMoneyFromDebitAccount command)
        {
            _account
                .Rehydrate(command.Account)
                .Perform(_ => _.Withdraw(command.Amount));
        }

        public void Handle(DepositMoneyToDebitAccount command)
        {
            _account
                .Rehydrate(command.Account)
                .Perform(_ => _.Deposit(command.Amount));
        }

        public void Handle(TransferMoneyFromDebitAccount command)
        {
            _account
                .Rehydrate(command.From)
                .Perform(_ => _.Transfer(command.To, command.Amount));
        }
    }
}