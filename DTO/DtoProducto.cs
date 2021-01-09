using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoProducto : DtoB
    {
        //variables Producto 
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public int stock { get; set; }
        public int stockMinimo { get; set; }
        public int stockMaximo { get; set; }
        public string formato { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public int cantidadPorPaquete { get; set; }
        public int disponibilidad { get; set; }

        public int idCodigo { get; set; }

        //Variables lista compra 

        public int idListaCompra { get; set; }
        public string estado { get; set; }
        public DateTime fecha { get; set; }
        public int idUsuario { get; set; }


        //Variables laboratorio

        public int idLaboratorio { get; set; }
        public string nombreLaboratorio { get; set; }
        public string RUC { get; set; }

    }

}
