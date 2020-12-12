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
    public class DAO_Usuario
    {
        SqlConnection conexion;


        public DAO_Usuario()
        {

            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public int login(string correo, string contraseña)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("sp_Login", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.Close();
            if (dt.Rows.Count != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
