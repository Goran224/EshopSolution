using Eshop_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_Service.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(JwtGenerateModel model, int id);

    }
}
