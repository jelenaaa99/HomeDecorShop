using FluentValidation;
using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Implementation.Validators;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Commands
{
    public class EfCreateProductCommand:EfUseCase, ICreateProductCommand
    {
        private InsertProductValidator _validator;
        public EfCreateProductCommand(HomeDecorContext context, InsertProductValidator validator) 
            :base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Create product";

        public string Description => "Insert product using Entity Framework.";

        public void Execute(CreateProductDTO request)
        {
            _validator.ValidateAndThrow(request);

            var product = new Product
            {
                Name = request.Name,
                Description = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Img = request.Img
            };


            Context.Products.Add(product);
            Context.SaveChanges();
        }
    }
}
