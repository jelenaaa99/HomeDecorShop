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
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {

        public EfGetUsersQuery(HomeDecorContext contex) 
            :base(contex)
        { 
        }

        public int Id => 12;

        public string Name => "Get all users";

        public string Description => "Get all users using Entity Framework";

        public PagedResponse<UserInfoDTO> Execute(BasePagedSearch search)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Email.Contains(search.Keyword) || x.FirstName.Contains(search.Keyword) || x.LastName.Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
                search.PerPage = 1;
            }

            var skip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<UserInfoDTO>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(skip).Take(search.PerPage.Value).Select(x => new UserInfoDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Country = x.Country,
                City = x.City,
                Address = x.Address,
                Phone = x.Phone
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
