using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Proveedor
    {
        public int idProveedor { get; set; }
        public int ruc { get; set; }
        public string RazonSocial { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string tipo { get; set; }
    }
}
