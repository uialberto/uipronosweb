using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Domain.DTOs.Modulos.Seguridad.Usuarios
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {
            KeyRoles = new List<string>();
        }
        public Guid Id { get; set; }
        public long UniqueCode { get; set; }
        public DateTime FechaCreacionUtc { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? FechaModUtc { get; set; }
        public List<string> KeyRoles { get; set; }

    }
}
