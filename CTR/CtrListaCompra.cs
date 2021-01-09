using DAO;
using DTO;

namespace CTR
{
    public class CtrListaCompra
    {


        public ClassResultV Usp_GetAllListaCompra(DtoB dtoBase)
        {
            return new DaoListaCompra().Usp_GetAllListaCompra(dtoBase);
        }
        public DtoListaCompra Usp_CancelListaCompra(DtoB dtoBase)
        {
            return new DaoListaCompra().Usp_CancelListaCompra(dtoBase);
        }
        
        public ClassResultV Usp_GetProdListaCompra(DtoB dtoBase)
        {
            return new DaoListaCompra().Usp_GetProdListaCompra(dtoBase);
        }

        public ClassResultV Usp_UpdateProdListaCompra(DtoB dtoBase)
        {
            return new DaoListaCompra().Usp_UpdateProdListaCompra(dtoBase);
        }
        public DtoProducto Usp_InsertListaCompra(DtoB dtoBase)
        {
            return new DaoListaCompra().Usp_InsertListaCompra(dtoBase);
        }

        public ClassResultV Usp_InsertDetalleLista(DtoB dtoBase)
        {
            return new DaoListaCompra().Usp_InsertDetalleLista(dtoBase);
        }
        

    }
}
