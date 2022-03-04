using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class TokenOption
    {
        public int Expires { get; set; }
        public string SecurityKey { get; set; }
    }
}