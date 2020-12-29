using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_DetallePedido
    {
        DAO_DetallePedido DAOPedido;

        public CTR_DetallePedido()
        {

            DAOPedido = new DAO_DetallePedido();
        }
        public void CTR_Insert_DetallePedido(DTO_DetallePedido objDPedido)
        {
            DAOPedido.InsertDetallePedido(objDPedido);
        }
        public DataTable CTR_SelectDetallePedido(int idPedido)
        {
            return DAOPedido.SelectDetallePedido(idPedido);
        }
    }
}
