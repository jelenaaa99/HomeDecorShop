using HomeDecorShop.Application.Exceptions;
using HomeDecorShop.Application.UseCases.Commands;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Commands
{
    public class EfDeleteCategoryCommand: EfUseCase, IDeleteCategoryCommand
    {

        public EfDeleteCategoryCommand(HomeDecorContext context)
            : base(context)
        { 
        }

        public int Id => 14;

        public string Name => "Delete category";

        public string Description => "Delete category using Entity Framework.";

        public void Execute(int request)
        {
            var category = Context.Categories.FirstOrDefault(x => x.Id == request && x.IsActive);

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            if (Context.Products.Any(x => x.CategoryId == request))
            {
                throw new UseCaseConflictException("Can`t delete category. Category is linked to Product table.");
            }

            Context.Categories.Remove(category);
            Context.SaveChanges();
        }
    }
}
