using FluentValidation;
using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Implementation.Validators;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Commands
{
    public class EfCreateCategoryCommand:EfUseCase, ICreateCategoryCommand
    {

        private CreateCategoryValidator _validator;
        public EfCreateCategoryCommand(HomeDecorContext cotext, CreateCategoryValidator validator)
            : base(cotext)
        {
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Create category";

        public string Description => "Create category using Entity Framework";

        public void Execute(CategoryDTO request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name,
            };


            Context.Categories.Add(category);
            Context.SaveChanges();
        }
    }
}
