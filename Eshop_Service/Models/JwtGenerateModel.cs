using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_Service.Models
{
    public class JwtGenerateModel  : LoginModel
    {
        public bool IsAdmin { get; set; }
    }
}
