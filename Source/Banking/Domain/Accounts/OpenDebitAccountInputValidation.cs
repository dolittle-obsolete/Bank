using System;
using Concepts.Accounts;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Accounts
{
    public class OpenDebitAccountInputValidation : CommandInputValidatorFor<OpenDebitAccount>
    {
        public OpenDebitAccountInputValidation()
        {
            RuleFor(_ => _.CustomerId)
                .NotNull()
                .NotEmpty()
                .NotEqual((CustomerId)Guid.Empty).WithMessage("Customer identifier is required");

            RuleFor(_ => _.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}