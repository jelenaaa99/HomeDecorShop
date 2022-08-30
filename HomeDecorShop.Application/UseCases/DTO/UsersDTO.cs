using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Application.UseCases.DTO
{
    public class UsersDTO:UserInfoDTO
    {
        public IEnumerable<UsersOrderDTO> Orders { get; set; }
    }
}
