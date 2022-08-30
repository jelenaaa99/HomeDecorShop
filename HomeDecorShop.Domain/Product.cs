using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public int CategoryId { get; set; }

        public Category Category  { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
