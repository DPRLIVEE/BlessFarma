using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DAO_Pedido
    {
        SqlConnection conexion;


        public DAO_Pedido()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void InsertPedido(DTO_Pedido objPedido)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Insert_Pedido", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@modoPago", objPedido.modoPago);
            cmd.Parameters.AddWithValue("@FechaEmision", objPedido.FechaEmision);
            cmd.Parameters.AddWithValue("@FechaEntrega", objPedido.FechaEntrega);
            cmd.Parameters.AddWithValue("@idProveedor", objPedido.idProveedor);
            cmd.Parameters.AddWithValue("@idListaCompra", objPedido.idListaCompra);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable SelectPedido()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Select_Pedido", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;

        }
    }
}
