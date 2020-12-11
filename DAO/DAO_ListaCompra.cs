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
    public class DAO_ListaCompra
    {
        SqlConnection conexion;
        public DAO_ListaCompra()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable SelectListaCompra()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Select_ListaCompra", conexion);
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
