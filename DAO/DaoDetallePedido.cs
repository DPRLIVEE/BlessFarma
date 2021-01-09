using System;
using System.Data;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAO
{
    public class DaoDetallePedido : DaoB
{
        public ClassResultV Usp_InsertDetallePedido(DtoB dtoBase)
        {
            DtoDetallePedido dto = (DtoDetallePedido)dtoBase;
            ClassResultV cr = new ClassResultV();
            SqlParameter[] pr = new SqlParameter[4];
            try
            {
                pr[0] = new SqlParameter("@idPedido", SqlDbType.Int)
                {
                    Value = dto.@idPedido
                };
                pr[1] = new SqlParameter("@idProducto", SqlDbType.Int)
                {
                    Value = dto.idProducto
                };
                pr[2] = new SqlParameter("@cantidad", SqlDbType.Int)
                {
                    Value = dto.cantidad
                };
                pr[3] = new SqlParameter("@precioCompra", SqlDbType.Int)
                {
                    Value = dto.precioCompra
                };

                _ = SqlHelper.ExecuteNonQuery(objCn, CommandType.StoredProcedure, "SP_Insert_DetallePedido", pr);
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al registrar el detalle del Pedido.";
            }
            objCn.Close();
            return cr;
        }
    }
}
