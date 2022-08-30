using HomeDecorShop.Application.Exceptions;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Application.UseCases.Queries;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Queries
{
    public class EfFindProductQuery : EfUseCase, IFindProductQuery
    {

        public EfFindProductQuery(HomeDecorContext context)
            : base(context)
        { 
        }
        public int Id => 6;

        public string Name => "Get single product";

        public string Description => "";

        public ProductDTO Execute(int search)
        {
            var product = Context.Products.Include(x => x.Category)
                        .FirstOrDefault(x => x.Id == search && x.IsActive);

            if (product == null) {
                throw new EntityNotFoundException(nameof(Product), search);
            }



            return new ProductDTO { 
                Id=product.Id,
                Name=product.Name,
                Description=product.Description,
                Price=product.Price,
                Img=product.Img,
                Category=new CategoryDTO { 
                    Id=product.Category.Id,
                    Name=product.Category.Name
                }
            };
        }
    }
}
