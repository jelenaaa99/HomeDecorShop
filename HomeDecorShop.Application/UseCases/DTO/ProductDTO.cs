using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Application.UseCases.DTO
{
    public class ProductDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public CategoryDTO Category { get; set; }
    }

    public class CategoryDTO : BaseDTO
    {
        public string Name { get; set; }
    }
}
