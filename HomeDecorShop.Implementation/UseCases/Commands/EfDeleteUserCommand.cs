using HomeDecorShop.Application.Exceptions;
using HomeDecorShop.Application.UseCases.Commands;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases.Commands
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {

        public EfDeleteUserCommand(HomeDecorContext context)
            : base(context)
        { 
        
        }
        public int Id => 3;

        public string Name => "Delete user";

        public string Description => "";

        public void Execute(int id)
        {
            var user = Context.Users.Include(x => x.UseCases).FirstOrDefault(x => x.Id==id && x.IsActive);

            if (user == null) {
                throw new EntityNotFoundException(nameof(User), id);
            }

            if (Context.Orders.Any(x => x.UserId == id)) {
                throw new UseCaseConflictException("Can`t delete user. User is linked to Order table.");
            }


            Context.UserUseCases.RemoveRange(user.UseCases);
            Context.Users.Remove(user);

            Context.SaveChanges();
            
        }
    }
}
