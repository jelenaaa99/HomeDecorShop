using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Application.Exceptions
{
    public class EntityNotFoundException:Exception
    {
        public EntityNotFoundException(string type, int id)
            : base($"Entity of type {type} with an id of {id} was not found.")
        { 
        }
    }
}
