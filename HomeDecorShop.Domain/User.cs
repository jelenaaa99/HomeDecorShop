using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class User : UserInfo 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<UserUseCase> UseCases { get; set; }
        public ICollection<UseCaseLog> UseCaseLogs { get; set; } = new List<UseCaseLog>();

    }
}
