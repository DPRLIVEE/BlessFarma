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
            cmd.Parameters.AddWithValue("@estadoP", objPedido.Estado);
            cmd.Parameters.AddWithValue("@MontoTotal", objPedido.MontoTotal);
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
        public void UpdatePedido(DTO_Pedido objPedido)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdatePedido", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPedido", objPedido.idPedido));
            cmd.Parameters.AddWithValue("@modoPago", objPedido.modoPago);   
            cmd.Parameters.AddWithValue("@FechaEntrega", objPedido.FechaEntrega);
            cmd.Parameters.AddWithValue("@idProveedor", objPedido.idProveedor);
            cmd.Parameters.AddWithValue("@MontoTotal", objPedido.MontoTotal);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void UpdateEstadoPedido(int idP, int idE)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateEstadoPedido", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idPedido", idP));
            cmd.Parameters.AddWithValue("@idEstado", idE);
         
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void DeletePedido(int idPedido)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Delete_Pedido", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@idPedido", idPedido));
            cmd.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
