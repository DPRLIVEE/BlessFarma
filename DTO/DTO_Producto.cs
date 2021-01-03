using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Producto
    {
        public string formato { get; set;}
        public decimal precioCompra { get; set; }

        public decimal PrecioTotal { get; set; }
        public int cantidad { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
    }
}
