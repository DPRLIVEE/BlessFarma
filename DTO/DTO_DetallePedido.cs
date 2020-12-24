using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DetallePedido
    {
        public int idDetallePedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int idPedido { get; set; }
        public decimal precioTotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
