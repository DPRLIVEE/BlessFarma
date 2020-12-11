using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAO;

namespace CTR
{
    public class CTR_ListaCompra
    {
        DAO_ListaCompra objListaC;
        public CTR_ListaCompra()
        {
            objListaC = new DAO_ListaCompra();
        }

        public DataTable SelectListaCompra()
        {
            return objListaC.SelectListaCompra();
        }
    }
}