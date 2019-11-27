using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Accounts
{
    public class WithdrawMoneyFromDebitAccountInputValidation : CommandInputValidatorFor<WithdrawMoneyFromDebitAccount>
    {
        public WithdrawMoneyFromDebitAccountInputValidation()
        {
            RuleFor(_ => _.Account).NotNull().WithMessage("Unique identifier for account is required");
            RuleFor(_ => _.Amount).GreaterThan(0).WithMessage("You have to have an amount greater than 0 when withdrawing");
        }
    }
}