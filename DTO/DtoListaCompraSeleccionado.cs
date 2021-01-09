using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoListaCompraSeleccionado : DtoB
    {
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public string formato { get; set; }
        public string nombreLaboratorio { get; set; }
        public Decimal precioCompra { get; set; }
        public int idProducto { get; set; }
        public Decimal precioTotal { get; set; }
        public Decimal montoTotal { get; set; }
        public int idListaCompra { get; set; }

    }

}
