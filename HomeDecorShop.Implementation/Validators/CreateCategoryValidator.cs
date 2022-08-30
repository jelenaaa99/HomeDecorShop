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
    public class CreateCategoryValidator : AbstractValidator<CategoryDTO>
    {
        private HomeDecorContext _context;
        public CreateCategoryValidator(HomeDecorContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
               .Cascade(CascadeMode.Stop)
               .Empty().WithMessage("You are not allowed to insert category id.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Minimum length is 3 characters.")
                .Must(CategoryNotInUse).WithMessage("There is already a category with that name.");

        }

        private bool CategoryNotInUse(string name)
        {
            var exists = _context.Categories.Any(c => c.Name == name);

            return !exists;
        }
    }
}
