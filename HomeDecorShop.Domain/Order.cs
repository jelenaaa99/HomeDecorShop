using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Order : UserInfo
    {
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
