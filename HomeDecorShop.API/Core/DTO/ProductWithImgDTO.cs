using HomeDecorShop.Application.UseCases.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDecorShop.API.Core.DTO
{
    public class ProductWithImgDTO: CreateProductDTO
    {
        public IFormFile Image { get; set; }
    }
}
