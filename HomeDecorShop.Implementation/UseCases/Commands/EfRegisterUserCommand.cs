using FluentValidation;
using HomeDecorShop.Application.UseCases.Commands;
using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Implementation.Validators;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Commands
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        public EfRegisterUserCommand(HomeDecorContext context, RegisterUserValidator validator)
            : base(context)
        {
            _validator = validator;
        }
        public int Id => 2;

        public string Name => "Register user";

        public string Description => "";

        public void Execute(RegisterUserDTO request)
        {
            _validator.ValidateAndThrow(request);

            var user = new User
            {
                FirstName=request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Country = request.Country,
                City = request.City,
                Address = request.Address,
                Phone = request.Phone,
            };

            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
