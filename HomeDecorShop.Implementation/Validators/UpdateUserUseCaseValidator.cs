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
    public class UpdateUserUseCaseValidator:AbstractValidator<UpdateUserUseCaseDTO>
    {
        public UpdateUserUseCaseValidator(HomeDecorContext context)
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("User is required.")
                .Must(x => context.Users.Any(u => u.Id == x)).WithMessage("User doesnt exist.");

            RuleFor(x => x.UseCaseIds)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Use cases are required")
                .Must(x => x.Count() == x.Distinct().Count()).WithMessage("Duplicate values are not allowed");

        }
    }
}
