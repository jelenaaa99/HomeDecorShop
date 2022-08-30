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
    public class EfDeleteProductCommand: EfUseCase, IDeleteProductCommand
    {
        public EfDeleteProductCommand(HomeDecorContext context)
            : base(context)
        { 
        }

        public int Id => 8;

        public string Name => "Delete product";

        public string Description => "Delete product using Entity Framework.";

        public void Execute(int request)
        {
            var product = Context.Products.FirstOrDefault(x => x.Id == request && x.IsActive);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request);
            }

            if (Context.OrderLines.Any(x => x.ProductId == request))
            {
                throw new UseCaseConflictException("Can`t delete product. Product is linked to Order Lines table.");
            }

            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}
