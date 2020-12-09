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
        public int modoPago { get; set; }
        public int FechaEmision { get; set; }
        public int FechaEntrega { get; set; }
        public int idProveedor { get; set; }
        public int idListaCompra { get; set; }

    }
}
