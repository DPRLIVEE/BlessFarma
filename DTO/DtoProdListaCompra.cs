using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoProdListaCompra : DtoB
    {
        public int idListaCompra { get; set; }
        public string idListaCorrelativo { get; set; }
        public DateTime fecha { get; set; }
        public string nombreProducto { get; set; }
        public string nombreLaboratorio { get; set; }
                
        public int idCodigo { get; set; }
    }
}
