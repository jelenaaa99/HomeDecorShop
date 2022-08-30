using HomeDecorShop.Application.UseCases;
using HomeDecorShop.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Queries
{
    public class EfGetUseCaseLogsQuery: EfUseCase, IGetUseCaseLogsQuery
    {
        public EfGetUseCaseLogsQuery(HomeDecorContext context)
            :base(context)
        {
        }

        public int Id => 9;

        public string Name => "Search use cases";

        public string Description => "";

        public PagedResponse<UseCaseLogg> Execute(UseCaseLogSearch search)
        {
            var logs = Context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrEmpty(search.UserEmail))
            {
                logs = logs.Where(x => x.UseCaseName.Contains(search.UseCaseName) || x.Username.Contains(search.UserEmail));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
                search.PerPage = 1;
            }

            var response = new PagedResponse<UseCaseLogg>();
            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            response.TotalCount = logs.Count();

            var skip = (search.Page.Value - 1) * search.PerPage.Value;

            response.Data = logs.Skip(skip).Take(search.PerPage.Value).Select(x => new UseCaseLogg
            {
                UseCaseName = x.UseCaseName,
                UserId = x.UserId,
                UserEmail = x.Username,
                Data = x.Data,
                IsAuthorized = x.IsAuthorize
            }).ToList();

            return response;
        }
    }
}
