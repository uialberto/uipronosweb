using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Domain.DTOs.Modulos.Seguridad.Usuarios
{
    public class LoginResponse
    {
        public bool Login { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? ExpireTokenUtc { get; set; }
    }
}
