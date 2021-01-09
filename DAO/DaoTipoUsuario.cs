using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoTipoUsuario : DaoB
    {

        public List<DtoTipoUsuario> Usp_GetAllPerfiles()
        {
            List<DtoTipoUsuario> list = new List<DtoTipoUsuario>();
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_GetAllPerfiles", pr);
                while (reader.Read())
                {
                    DtoTipoUsuario dtou = new DtoTipoUsuario();
                    dtou.idTipoUsuario = reader.GetValue(reader.GetOrdinal("idTipoUsuario")) == DBNull.Value ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("idTipoUsuario")));
                    dtou.nombreTipoUsuario = reader.GetValue(reader.GetOrdinal("nombreTipoUsuario")) == DBNull.Value ? string.Empty : Convert.ToString(reader.GetValue(reader.GetOrdinal("nombreTipoUsuario")));
                    list.Add(dtou);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            objCn.Close();
            return list;
        }

    }
}
