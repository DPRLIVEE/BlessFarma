using DAO;
using DTO;
namespace CTR
{
    public class CtrPedido
    {
        public ClassResultV Usp_GetAllPedido(DtoB dtoBase)
        {
            return new DaoPedido().Usp_GetAllPedido(dtoBase);
        }
        public ClassResultV Usp_GetCargarPedido(DtoB dtoBase)
        {
            return new DaoPedido().Usp_GetCargarPedido(dtoBase);
        }

        public ClassResultV Usp_GetListaCompraSeleccionada(DtoB dtoBase)
        {
            return new DaoPedido().Usp_GetListaCompraSeleccionada(dtoBase);
        }
        public ClassResultV Usp_GetAllProveedores()
        {
            return new DaoPedido().Usp_GetAllProveedores();
        }
        public ClassResultV Usp_GetAllMetodoPago()
        {
            return new DaoPedido().Usp_GetAllMetodoPago();
        }

        public DtoPedido Usp_InsertPedido(DtoB dtoBase)
        {
            return new DaoPedido().Usp_InsertPedido(dtoBase);
        }

        public ClassResultV Usp_InsertDetallePedido(DtoB dtoBase)
        {
            return new DaoPedido().Usp_InsertDetallePedido(dtoBase);
        }

        public ClassResultV Usp_GetPedidoLista(DtoB dtoBase)
        {
            return new DaoPedido().Usp_GetPedidoLista(dtoBase);
        }

        public ClassResultV Usp_UpdateProcesar(DtoB dtoBase)
        {
            return new DaoPedido().Usp_UpdateProcesar(dtoBase);
        }

        public DtoPedido Usp_UpdatePedido(DtoB dtoBase)
        {
            return new DaoPedido().Usp_UpdatePedido(dtoBase);
        }
    }
}
