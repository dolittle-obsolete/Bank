using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Accounts
{
    public class TransferMoneyFromDebitAccountInputValidation : CommandInputValidatorFor<TransferMoneyFromDebitAccount>
    {
        public TransferMoneyFromDebitAccountInputValidation()
        {
            RuleFor(_ => _.From).NotNull().WithMessage("From account identifier is required");
            RuleFor(_ => _.To).NotNull().WithMessage("To account identifier is required");
            RuleFor(_ => _.Amount).GreaterThan(0).WithMessage("You have to have an amount greater than 0 when transferring");
        }
    }
}