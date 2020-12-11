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
    public class DAO_Proveedor
    {
        SqlConnection conexion;
        public DAO_Proveedor()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataSet SelectProveedor()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Select_Proveedor", conexion);
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

