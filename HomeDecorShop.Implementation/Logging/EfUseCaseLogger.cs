using HomeDecorShop.Application.UseCases;
using HomeDecorShop.Implementation.UseCases;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.Logging
{
    public class EfUseCaseLogger:EfUseCase, IUseCaseLogger
    {
        public EfUseCaseLogger(HomeDecorContext context)
            : base(context)
        { 
        }


        public void Log(UseCaseLogg log)
        {
            var newLog = new UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                UserId = log.UserId,
                Username = log.UserEmail,
                Data = log.Data,
                IsAuthorize = log.IsAuthorized
            };

            Context.UseCaseLogs.Add(newLog);
            Context.SaveChanges();
        }
    }
}
