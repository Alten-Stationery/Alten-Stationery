using DBLayer.Models;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Validations
{
    public class ItemValidator:AbstractValidator<Item>
    {

        public  bool GreaterThan(DateTime date)
        {
            if (date > DateTime.Today)
                return true;
            return false;
        }

        public ItemValidator() 
        {
            RuleFor(x => x.ItemId).NotNull();

            RuleFor(x=>x.Name).NotEmpty();

            RuleFor(x=>x.Description).NotEmpty();

            RuleFor(x=>x.Type).NotEmpty();

            RuleFor(x=>x.Threshold).GreaterThan(0);

            RuleFor(x => x.ExpirationDate)
                .NotEmpty()
                .Must(GreaterThan).WithMessage("Expiration Date cannot be in the past");

            RuleFor(x=>x.Quantity).GreaterThan(0);

            RuleFor(x => x.Location).NotEmpty();

                
        }
    }
}
