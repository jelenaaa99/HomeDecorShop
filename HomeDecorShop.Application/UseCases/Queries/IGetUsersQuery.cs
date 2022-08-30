using HomeDecorShop.Application.UseCases.DTO;
using HomeDecorShop.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Application.UseCases.Queries
{
    public interface IGetUsersQuery:IQuery<BasePagedSearch, PagedResponse<UserInfoDTO>>
    {
    }
}
