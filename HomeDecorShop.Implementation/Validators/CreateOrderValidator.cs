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
    public class CreateOrderValidator: AbstractValidator<OrderLineDTO>
    {
        public CreateOrderValidator(HomeDecorContext context) 
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product id is required")
                .Must(x => context.Products.Any(p => p.Id == x && p.IsActive)).WithMessage("Forwarded product id doesn`t exist.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required");

        }
    }
}
