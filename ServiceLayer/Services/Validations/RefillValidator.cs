using DBLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Validations
{
    public class RefillValidator:AbstractValidator<Refill>
    {
        public bool CheckDate(DateTime date)
        {
            if (date > DateTime.Today)
                return true;
            return false;
        }
        public RefillValidator() 
        {
            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x=>x.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.RefillDate).NotEmpty().Must(CheckDate);
        }
    }
}
