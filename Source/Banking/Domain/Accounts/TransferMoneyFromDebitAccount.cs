using Concepts.Accounts;
using Dolittle.Commands;

namespace Domain.Accounts
{
    public class TransferMoneyFromDebitAccount : ICommand
    {
        public AccountId From { get; set; }
        public AccountId To { get; set; }
        public double Amount { get; set; }
    }
}