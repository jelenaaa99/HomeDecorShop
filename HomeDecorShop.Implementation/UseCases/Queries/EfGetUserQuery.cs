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
    public class EfGetUserQuery : EfUseCase, IGetUserQuery
    {

        public EfGetUserQuery(HomeDecorContext context)
            : base(context)
        { 
        
        }
        public int Id => 1;

        public string Name => "Get single user";

        public string Description => "";

        public UsersDTO Execute(int id)
        {
            var user = Context.Users.Find(id);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), id);
            }

            var query = Context.Users.Include(x => x.Orders)
                                        .ThenInclude(x => x.OrderLines)
                                        .ThenInclude(x => x.Product)
                                        .Where(x => x.Id == id).FirstOrDefault();

            var result =  new UsersDTO
            {
                Id=query.Id,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Email = query.Email,
                Country = query.Country,
                City = query.City,
                Address = query.Address,
                Phone = query.Phone,
                Orders = query.Orders.Select(y => new UsersOrderDTO
                {
                    Id = y.Id,
                    Date = y.CreatedAt,
                    Country = y.Country,
                    City = y.City,
                    Phone = y.Phone,
                    OrderItems = y.OrderLines.Select(j => new UsersOrderLineDTO
                    {
                        ProductName = j.Product.Name,
                        Quantity = j.Quantity
                    })
                })
            };

            return result; 
        }
    }
}
