using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_ProductoListCompra
    {
        DAO_ProductoListaCompra objProductoLC;
        public CTR_ProductoListCompra()
        {
            objProductoLC = new DAO_ProductoListaCompra();
        }

        public DataTable SelectProductoLC(DTO_ProductoListaCompra objProducotLC)
        {
            return objProductoLC.SelectProductoLC(objProducotLC);
        }
    }
}
