using Deskberry.CommandValidation.CommandObjects.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.CommandValidation.Validators
{
    public class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(40);

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}