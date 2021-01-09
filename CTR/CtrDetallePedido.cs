using DAO;
using DTO;

namespace CTR
{
    public class CtrDetallePedido
    {
        public ClassResultV Usp_InsertDetallePedido(DtoB dtoBase)
        {
            return new DaoDetallePedido().Usp_InsertDetallePedido(dtoBase);
        }
    }
}
