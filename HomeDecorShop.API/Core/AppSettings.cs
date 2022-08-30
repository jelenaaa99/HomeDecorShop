using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDecorShop.API.Core
{
    public class AppSettings
    {
        public string ConnString { get; set; }
        public JwtSettings JwtSettings { get; set; }
    }

}
