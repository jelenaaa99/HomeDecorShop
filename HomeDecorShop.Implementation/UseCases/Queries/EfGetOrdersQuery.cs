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
    public class EfGetOrdersQuery:EfUseCase, IGetOrdersQuery
    {

        public EfGetOrdersQuery(HomeDecorContext context)
            : base(context)
        { 
        }

        public int Id => 10;

        public string Name => "Get all orders";

        public string Description => "";

        public PagedResponse<OrdersDTO> Execute(BasePagedSearch search)
        {
            var query = Context.Orders
                .Include(x => x.OrderLines).ThenInclude(x => x.Product)
                .Include(x => x.User).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Country.Contains(search.Keyword) || x.City.Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
                search.PerPage = 1;
            }

            var skip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<OrdersDTO>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(skip).Take(search.PerPage.Value).Select(x => new OrdersDTO
            {
                Id = x.Id,
                Country = x.Country,
                City = x.City,
                Address = x.Address,
                Phone = x.Phone,
                UserId = x.UserId,
                User = x.User.Email,
                Items = x.OrderLines.Select(i => new UsersOrderLineDTO
                {
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity
                })
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
