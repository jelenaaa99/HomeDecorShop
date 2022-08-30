using HomeDecorShop.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Application.UseCases
{
        public interface IUseCaseLogger
        {
            void Log(UseCaseLogg log);
        }

        public class UseCaseLogSearch: PagedSearch
    {
            public string UseCaseName { get; set; }
            public string UserEmail { get; set; }
        }

        public class UseCaseLogg
    {
            public string UseCaseName { get; set; }
            public string UserEmail { get; set; }
            public int? UserId { get; set; }
            public string Data { get; set; }
            public bool IsAuthorized { get; set; }
        }
}
