using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Domain.DTOs.Modulos.Seguridad.Usuarios;

namespace Uibasoft.Domain.Interfaces
{
    public interface IServiceLogin
    {
        Task<(bool IsSuccess, string errorMessage, LoginResponse? result)> LoginByCredentials(LoginUsuarioDto userLogin);
        bool IsValidTokenJwt(string tokenJwt);

        UsuarioDto GetInfoUser();
    }
}
