using Concepts.Accounts;
using Dolittle.Commands;

namespace Domain.Accounts
{
    public class WithdrawMoneyFromDebitAccount : ICommand
    {
        public AccountId Account { get; set; }
        public double Amount { get; set; }
    }
}