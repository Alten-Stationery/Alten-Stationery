using DBLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Validations
{
    public class AlertValidator : AbstractValidator<Alert>
    {

        public bool CheckDate(DateTime date)
        {
            if (date > DateTime.Today)
                return true;
            return false;
        }

        public AlertValidator()
        {

            RuleFor(x => x.AlertDate).NotEmpty().Must(CheckDate);

            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid Email is required!");

            RuleFor(x => x.EmailBody).NotNull().NotEmpty();

        }

    }
}
