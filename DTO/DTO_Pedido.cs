using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace DTO
{
    public class DTO_Pedido
    {
        public int idPedido { get; set; }
        public string modoPago { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int idProveedor { get; set; }
        public int idListaCompra { get; set; }
        public int Estado { get; set; }

    }
}
