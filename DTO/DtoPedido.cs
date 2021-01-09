using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPedido : DtoB
    {

        public int idPedido { get; set; }
        public int idMetodoPago { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaEntrega { get; set; }
        public int idProveedor { get; set; }
        public int idListaCompra { get; set; }
        public int idEstadoPedido { get; set; }
        public Decimal precioTotal { get; set; }
        public string correlativo { get; set; }
        public int idUsuario { get; set; }
        public int cantidad { get; set; } 
        public Decimal precioCompra { get; set; }

        public string NomUsuario { get; set; }
        public string razonSocial { get; set; }
        public string NombreEstado { get; set; }

        public string nombreProducto { get; set; }
        public string formato { get; set; }
        public int idLaboratorio { get; set; }
        public string nombreLaboratorio { get; set; }
        public int idProducto { get; set; }
        public Decimal montoTotal { get; set; }

        public string metodoPago { get; set; }

        public string tipo { get; set; }

        public int idTipo { get; set; }

        public string httpPedido { get; set; }

        


    }
}
