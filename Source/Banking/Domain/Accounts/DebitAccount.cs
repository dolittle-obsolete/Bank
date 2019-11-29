using Concepts.Accounts;
using Dolittle.Domain;
using Dolittle.Rules;
using Dolittle.Runtime.Events;
using Events.Accounts;

namespace Domain.Accounts
{
    public class DebitAccount : AggregateRoot
    {
        private static readonly Reason InsufficientFunds = Reason.Create("05d34d5f-c06e-468b-b01d-2c0f972af350", "Insufficient funds on account '{Account}'");

        private double _balance;

        public DebitAccount(EventSourceId eventSourceId) : base(eventSourceId) { }

        public void Deposit(double amount)
        {
            var oldBalance = _balance;
            Apply(new DepositPerformedToDebitAccount(amount));
            Apply(new BalanceChanged(oldBalance, _balance));
        }

        public void Withdraw(double amount)
        {
            if (Evaluate(() => MustHaveSufficientFundsToWitdrawAmount(amount)))
            {
                var oldBalance = _balance;
                Apply(new WithdrawalPerformedFromDebitAccount(amount));
                Apply(new BalanceChanged(oldBalance, _balance));
            }
        }

        public void DepositFromOtherAccount(AccountId from, double amount)
        {
            var oldBalance = _balance;
            Apply(new DepositPerformedToDebitAccountFromOtherAccount(from, amount));
            Apply(new BalanceChanged(oldBalance, _balance));
        }

        public void Transfer(AccountId to, double amount)
        {
            if (Evaluate(() => MustHaveSufficientFundsToWitdrawAmount(amount)))
            {
                var oldBalance = _balance;
                Apply(new MoneyTransferredFromDebitAccount(to, amount));
                Apply(new BalanceChanged(oldBalance, _balance));
            }
        }

        RuleEvaluationResult MustHaveSufficientFundsToWitdrawAmount(double amount)
        {
            var newBalance = _balance - amount;
            if (newBalance < 0) return RuleEvaluationResult.Fail(amount, InsufficientFunds.WithArgs(new{Account=EventSourceId}));
            return RuleEvaluationResult.Success;
        }

        void On(DepositPerformedToDebitAccount deposit)
        {
            _balance += deposit.Amount;
        }

        void On(DepositPerformedToDebitAccountFromOtherAccount deposit)
        {
            _balance += deposit.Amount;
        }

        void On(WithdrawalPerformedFromDebitAccount withdrawal)
        {
            _balance -= withdrawal.Amount;
        }

        void On(MoneyTransferredFromDebitAccount transfer)
        {
            _balance -= transfer.Amount;
        }
    }
}