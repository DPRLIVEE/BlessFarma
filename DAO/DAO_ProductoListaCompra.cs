using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    class DAO_ProductoListaCompra
    {
        SqlConnection conexion;


        public DAO_ProductoListaCompra()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataSet InsertPedido(DTO_ProductoListaCompra objProductoLC)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Select_ProductoLC", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            return dt;
            
        }
    }
}
