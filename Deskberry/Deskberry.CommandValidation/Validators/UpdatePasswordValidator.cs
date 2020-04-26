using Deskberry.CommandValidation.CommandObjects.Password;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.CommandValidation.Validators
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePassword>
    {
        public UpdatePasswordValidator()
        {
            RuleSet("Password", () =>
            {
                RuleForCurrentPassword<string>(x => x.Password);
                RuleForPasswordsEquality<bool>(x => x.ArePasswordsEqual);
            });

            RuleSet("NewPassword", () =>
            {
                RuleForNewPassword<string>(x => x.NewPassword);
            });

            RuleSet("RepeatedNewPassword", () =>
            {
                RuleForRepeatedNewPassword<string>(x => x.RepeatedNewPassword);
            });

            RuleSet("Full", () =>
            {
                RuleForCurrentPassword<string>(x => x.Password);
                RuleForPasswordsEquality<bool>(x => x.ArePasswordsEqual);

                RuleForNewPassword<string>(x => x.NewPassword);
                RuleForRepeatedNewPassword<string>(x => x.RepeatedNewPassword);
            });
        }

        protected IRuleBuilderOptions<UpdatePassword, string> RuleForCurrentPassword<TProperty>(Expression<Func<UpdatePassword, string>> expression)
        {
            return RuleFor(expression)
                .NotNull()
                .NotEmpty();
        }

        protected IRuleBuilderOptions<UpdatePassword, bool> RuleForPasswordsEquality<TProperty>(Expression<Func<UpdatePassword, bool>> expression)
        {
            return RuleFor(expression).Equal(true);
        }

        protected IRuleBuilderOptions<UpdatePassword, string> RuleForNewPassword<TProperty>(Expression<Func<UpdatePassword, string>> expression)
        {
            return RuleFor(expression)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8);
        }

        protected IRuleBuilderOptions<UpdatePassword, string> RuleForRepeatedNewPassword<TProperty>(Expression<Func<UpdatePassword, string>> expression)
        {
            return RuleFor(expression)
                .NotNull()
                .NotEmpty()
                .Equal(x => x.NewPassword);
        }
    }
}