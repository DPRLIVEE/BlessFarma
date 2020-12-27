using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_DetallePedido
    {

        SqlConnection conexion;


        public DAO_DetallePedido()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void InsertDetallePedido(DTO_DetallePedido objDPedido)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Insert_DetallePedido", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", objDPedido.idProducto);
            cmd.Parameters.AddWithValue("@cantidad", objDPedido.cantidad);
            cmd.Parameters.AddWithValue("@idPedido", objDPedido.idPedido);
            cmd.Parameters.AddWithValue("@PrecioTotal", objDPedido.precioTotal);
            
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
