using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Application.UseCases.DTO.Searches;
using HomeDecorShop.Application.UseCases.Queries;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Queries
{
    public class EfGetProductsQuery : EfUseCase, IGetProductsQuery
    {

        public EfGetProductsQuery(HomeDecorContext contex) 
            :base(contex)
        { 
        }
        public int Id => 5;

        public string Name => "Get products";

        public string Description => "";

        public PagedResponse<ProductDTO> Execute(BasePagedSearch search)
        {
            var query = Context.Products.Include(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Category.Name.Contains(search.Keyword) || x.Name.Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
                search.PerPage = 1;
            }

            var skip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<ProductDTO>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(skip).Take(search.PerPage.Value).Select(x => new ProductDTO
            {
                Id=x.Id,
                Name=x.Name,
                Description = x.Description,
                Price = x.Price,
                Img=x.Img,
                Category = new CategoryDTO 
                {
                    Id=x.Category.Id,
                    Name=x.Category.Name
                }
            }).ToList();
            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
