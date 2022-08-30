using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class UseCaseLog:Entity
    {
        public string UseCaseName { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Data { get; set; }
        public bool IsAuthorize { get; set; }

        public User User { get; set; }
    }
}
