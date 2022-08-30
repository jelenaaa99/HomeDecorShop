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
    public class InsertProductValidator:AbstractValidator<CreateProductDTO>
    {
        public InsertProductValidator(HomeDecorContext context) 
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(20).WithMessage("Maximum length for name is 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.");

            RuleFor(x => x.Img)
                .NotEmpty().WithMessage("Image is required.");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category id is required.")
                .Must(x => context.Categories.Any(c => c.Id == x && c.IsActive)).WithMessage("Forwarded category id doesn`t exist.");

        }
    }
}
