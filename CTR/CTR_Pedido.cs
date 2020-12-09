using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    class CTR_Pedido
    {
        DAO_Pedido DAOPedido;
       
        public void InsertPedido(DTO_Pedido objPedido)
        {
            DAOPedido.InsertPedido(objPedido);
        }
    }
}
