using DBLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid Email is required!");
            RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Password cannot be empty.")
                                    .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                                    .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                                    .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                                    .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                                    .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Password must contain at least one special character.");
        }

    }
}
