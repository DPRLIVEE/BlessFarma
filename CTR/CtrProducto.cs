using System.Collections.Generic;
using DAO;
using DTO;

namespace CTR
{
    public class CtrProducto
    {
        public ClassResultV Usp_GetAllProductos()
        {
            return new DaoProducto().Usp_GetAllProductos();
        }
    }
}
