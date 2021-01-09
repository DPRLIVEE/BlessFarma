using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoUsuario : DtoB
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string Codigo { get; set; }
        public int idTipoUsuario { get; set; }
        public string nombreTipoUsuario { get; set; }
        public byte[] Foto { get; set; }
    }
}
