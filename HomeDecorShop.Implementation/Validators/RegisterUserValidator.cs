using FluentValidation;
using HomeDecorShop.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.Validators
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserDTO>
    {

        public RegisterUserValidator(HomeDecorContext context) 
        {
            var nameRegex = @"^[A-Z][a-z]{3,}(\s[A-Z][a-z]{3,})*$";
            var passRegex = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            var phoneRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{3,6}$";

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required.")
                .Matches(nameRegex).WithMessage("Wrong first name format.");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches(nameRegex).WithMessage("Wrong last name format."); ;

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Wrong email format.")
                .Must(x => !context.Users.Any(u => u.Email == x)).WithMessage("Email address {PropertyValue} is already in use.");

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(passRegex).WithMessage("Password consists of minimum eight characters, at least one letter and one number");

            RuleFor(x => x.Country)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(x => x.City)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(phoneRegex).WithMessage("Phone can not be less than 9 digits.");
        }
    }
}
