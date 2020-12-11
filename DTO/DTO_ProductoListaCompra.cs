using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ProductoListaCompra
    {
        public int idProuctoListaCompra { get; set; }
        public int cantidad { get; set; }
        public int idListaCompra { get; set; }
        public int idProducto { get; set; }
    }
}
