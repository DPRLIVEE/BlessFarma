using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoListaCompra : DtoB
    {

        public int idListaCompra { get; set; }
        public string correlativo { get; set; }
        public string NombreEstado { get; set; }
        public DateTime fecha { get; set; }
        public string NomUsuario { get; set; }
    }
}
