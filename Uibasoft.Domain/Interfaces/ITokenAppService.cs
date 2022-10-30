using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Domain.Interfaces
{
    public interface ITokenAppService
    {
        bool IsValidTokenJwt(string key, string issuer, string tokenJwt);
    }
}
