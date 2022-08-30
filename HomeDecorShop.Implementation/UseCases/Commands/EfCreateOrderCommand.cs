using FluentValidation;
using HomeDecorShop.Application.Exceptions;
using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Domain;
using HomeDecorShop.Implementation.Validators;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Commands
{
    public class EfCreateOrderCommand:EfUseCase, ICreateOrderCommand
    {
        private IApplicationUser _user;
        private CreateOrderValidator _validator;
        public EfCreateOrderCommand(HomeDecorContext context, IApplicationUser user, CreateOrderValidator validator)
            : base(context)
        {
            _user = user;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Create new order";

        public string Description => "Create new order using Entity Framework";

        public void Execute(CreateOrderDTO request)
        {
           
            foreach (var i in request.OrderLines)
            {
                _validator.ValidateAndThrow(i);
            }

            var phoneRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{3,6}$";
            var orderUser = Context.Users.FirstOrDefault(x => x.Id == _user.Id);

            var newOrder = new Order();

            if (request.Country != null)
            {
                newOrder.Country = request.Country;
            }
            else 
            {
                newOrder.Country = orderUser.Country;
            }

            if (request.City != null)
            {
                newOrder.City = request.City;
            }
            else
            {
                newOrder.City = orderUser.City;
            }

            if (request.Address != null)
            {
                newOrder.Address = request.Address;
            }
            else
            {
                newOrder.Address = orderUser.Address;
            }

            if (request.Phone != null)
            {
                newOrder.Phone = request.Phone;
            }
            else
            {
                newOrder.Phone = orderUser.Phone;
            }

            if (request.Phone != null && !Regex.IsMatch(request.Phone, phoneRegex)) 
            {
                throw new UnprocessableEntityException("Phone can not be less than 9 digits.");
            }

            newOrder.UserId = _user.Id;

            Context.Orders.Add(newOrder);
            Context.SaveChanges();

            var orderId = newOrder.Id;

            var orderLines = request.OrderLines.Select(x => new OrderLine
            { 
                OrderId=orderId,
                ProductId=x.ProductId,
                Quantity=x.Quantity
            });

            Context.OrderLines.AddRange(orderLines);
            Context.SaveChanges();
        }
    }
}
