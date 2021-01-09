using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class DaoProducto : DaoB
    {
        public ClassResultV Usp_GetAllProductos()
        {
            ClassResultV cr = new ClassResultV();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_Productos");
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    DtoProducto dtop = new DtoProducto
                    {
                        idProducto = reader.GetValue(reader.GetOrdinal("idProducto")) == DBNull.Value ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("idProducto"))),
                        nombreProducto = Convert.ToString(reader.GetValue(reader.GetOrdinal("nombreProducto")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("nombreProducto"))),
                        nombreLaboratorio = Convert.ToString(reader.GetValue(reader.GetOrdinal("nombreLaboratorio")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("nombreLaboratorio")))
                    };
                    cr.List.Add(dtop);
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = ex.Message;
            }
            objCn.Close();
            return cr;
        }

    }
}
