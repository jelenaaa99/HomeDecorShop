using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Application.Exceptions
{
    public class ForbiddenUseCaseExecutionException:Exception
    {
        public ForbiddenUseCaseExecutionException(string useCase, string user)
            :base($"User {user} is not authorized to execute {useCase}.")
        { 
        }
    }
}
