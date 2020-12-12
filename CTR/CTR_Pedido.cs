using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_Pedido
    {
        DAO_Pedido DAOPedido;

        public CTR_Pedido()
        {

            DAOPedido = new DAO_Pedido();
        }
       
        public void InsertPedido(DTO_Pedido objPedido)
        {
            DAOPedido.InsertPedido(objPedido);
        }
        public DataTable SelectPedido()
        {
            return DAOPedido.SelectPedido();
        }
        public void UpdatePedido(int idE, int idPe)
        {
             DAOPedido.UpdatePedido(idE, idPe);       
        }
    }
}
