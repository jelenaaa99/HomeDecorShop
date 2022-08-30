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
    public class EfUpdateUserUseCase : EfUseCase, IUpdateUserUseCaseCommand
    {
        private readonly UpdateUserUseCaseValidator _validator;
        public EfUpdateUserUseCase(
            HomeDecorContext context,
            UpdateUserUseCaseValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "Update user use cases";

        public string Description => "";

        public void Execute(UpdateUserUseCaseDTO request)
        {
            _validator.ValidateAndThrow(request);

            var userUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == request.UserId)
                                      .ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            var addUseCases = request.UseCaseIds.Select(x => new UserUseCase
            {
                UseCaseId = x,
                UserId = request.UserId.Value
            });

            Context.AddRange(addUseCases);

            Context.SaveChanges();
        }
    }
}
