using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDecorShop.Application.UseCases.DTO
{
    public class UsersOrderDTO:BaseDTO
    {
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public IEnumerable<UsersOrderLineDTO> OrderItems { get; set; }
    }
}
