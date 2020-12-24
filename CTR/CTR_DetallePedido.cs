using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    class CTR_DetallePedido
    {
        DAO_DetallePedido DAODPedido;

        public CTR_DetallePedido()
        {

            DAODPedido = new DAO_DetallePedido();
        }
        public void CTR_Insert_DetallePedido(DTO_DetallePedido objDPedido)
        {
            DAODPedido.InsertDetallePedido(objDPedido);

        }
    }
}
