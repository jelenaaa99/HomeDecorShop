using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(HomeDecorContext context) {
            Context = context;
        }

        protected HomeDecorContext Context { get; }
    }
}
