using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Application.UseCases.DTO.Searches;
using HomeDecorShop.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Queries
{
    public class EfGetCategoriesQuery:EfUseCase,IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(HomeDecorContext context)
            : base(context)
        { 
        }

        public int Id => 13;

        public string Name => "Create category";

        public string Description => "Create category using Entity Framework";

        public PagedResponse<CategoryDTO> Execute(BasePagedSearch search)
        {
            var query = Context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
                search.PerPage = 1;
            }

            var skip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<CategoryDTO>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(skip).Take(search.PerPage.Value).Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
