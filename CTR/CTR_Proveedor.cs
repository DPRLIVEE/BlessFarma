using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DAO;

namespace CTR
{
    public class CTR_Proveedor
    {
        DAO_Proveedor objProveedor;

        public CTR_Proveedor()
        {
            objProveedor = new DAO_Proveedor();
        }
        public DataSet SelectProveedor()
        {
            return objProveedor.SelectProveedor();
        }
    }
}