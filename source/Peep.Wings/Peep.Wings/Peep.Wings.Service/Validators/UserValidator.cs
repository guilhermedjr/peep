using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Peep.Wings.Domain.Entities;

namespace Peep.Wings.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Please enter the name")
                .NotNull().WithMessage("Please enter the name");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Please enter the email")
                .NotNull().WithMessage("Please enter the email");

            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Please enter the username")
                .NotNull().WithMessage("Please enter the username");


        }
    }
}
