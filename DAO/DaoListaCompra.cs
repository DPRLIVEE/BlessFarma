using System;
using System.Data;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace DAO
{
    public class DaoListaCompra : DaoB
    {

        public ClassResultV Usp_GetAllListaCompra(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            DtoListaCompra dto = (DtoListaCompra)dtoBase;
            List<SqlParameter> pr = new List<SqlParameter>
            {
                new SqlParameter("@Id", dto.Criterio),
                new SqlParameter("@NomUsuario", dto.NomUsuario)
                //new SqlParameter("@tienda", dto.Tienda),
                //new SqlParameter("@tipo", dto.TipoMovimiento),
                //new SqlParameter("@estado", dto.IB_Estado)
            };
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_ListaCompras", pr.ToArray());
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    dto = new DtoListaCompra
                    {
                        idListaCompra = getValue("idListaCompra", reader).Value_Int32,
                        correlativo = getValue("correlativo", reader).Value_String,
                        NombreEstado = getValue("NombreEstado", reader).Value_String,
                        fecha = getValue("fecha", reader).Value_DateTime,
                        NomUsuario = getValue("NomUsuario", reader).Value_String
                        
                    };
                    cr.List.Add(dto);
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al consultar SP_Get_ListaCompras";
            }
            objCn.Close();
            return cr;
        }

        public ClassResultV Usp_GetProdListaCompra(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            DtoProdListaCompra dto = (DtoProdListaCompra)dtoBase;
            List<SqlParameter> pr = new List<SqlParameter>
            {
                new SqlParameter("@idListaCompra", dto.Criterio)
                
               
                //new SqlParameter("@tienda", dto.Tienda),
                //new SqlParameter("@tipo", dto.TipoMovimiento),
                //new SqlParameter("@estado", dto.IB_Estado)
            };
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_ProdListaCompra", pr.ToArray());
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    dto = new DtoProdListaCompra
                    {
                        idListaCompra = getValue("idListaCompra", reader).Value_Int32,
                        idListaCorrelativo = getValue("correlativo", reader).Value_String,
                        fecha = getValue("fecha", reader).Value_DateTime,
                        nombreProducto = getValue("nombreProducto", reader).Value_String,
                        nombreLaboratorio = getValue("nombreLaboratorio", reader).Value_String,
                        idCodigo = getValue("idCodigo", reader).Value_Int32

                    };
                    cr.List.Add(dto);
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al consultar SP_Get_ProdListaCompra";
            }
            objCn.Close();
            return cr;
        }


        public DtoProducto Usp_InsertListaCompra(DtoB dtoBase)
        {
            DtoProducto dto = (DtoProducto)dtoBase;
            SqlParameter[] pr = new SqlParameter[4];
            try
            {


                pr[0] = new SqlParameter("@idListaCompra", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("@estado", SqlDbType.Int)
                {
                    Value = dto.estado
                };

                pr[2] = new SqlParameter("@fecha", SqlDbType.DateTime)
                {
                    Value = V_ValidaPrNull(dto.fecha)
                };
                pr[3] = new SqlParameter("@idUsuario", SqlDbType.Int)
                {
                    Value = dto.idUsuario
                };
                _ = SqlHelper.ExecuteNonQuery(objCn, CommandType.StoredProcedure, "SP_Insert_ListaCompra", pr);
                if (!string.IsNullOrEmpty(pr[0].Value.ToString()))
                {
                    dto.idListaCompra = int.Parse(pr[0].Value.ToString());
                }

            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error al registrar la Lista de Compras";
            }
            objCn.Close();
            return dto;
        }

        public ClassResultV Usp_InsertDetalleLista(DtoB dtoBase)
        {
            DtoProducto dto = (DtoProducto)dtoBase;
            ClassResultV cr = new ClassResultV();
            SqlParameter[] pr = new SqlParameter[2];
            try
            {
                pr[0] = new SqlParameter("@idListaCompra", SqlDbType.Int)
                {
                    Value = dto.@idListaCompra
                };
                pr[1] = new SqlParameter("@idProducto", SqlDbType.Int)
                {
                    Value = dto.idProducto
                };

                _ = SqlHelper.ExecuteNonQuery(objCn, CommandType.StoredProcedure, "SP_Insert_DetalleLista", pr);
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al registrar el detalle de la lista de compra";
            }
            objCn.Close();
            return cr;
        }

        public ClassResultV Usp_UpdateProdListaCompra(DtoB dtoBase)
        {
            DtoProducto dto = (DtoProducto)dtoBase;
            ClassResultV cr = new ClassResultV();
            SqlParameter[] pr = new SqlParameter[3];
            try
            {
                pr[0] = new SqlParameter("@idCodigo", SqlDbType.Int)
                {
                    Value = dto.@idCodigo
                };
                pr[1] = new SqlParameter("@idProducto", SqlDbType.Int)
                {
                    Value = dto.idProducto
                };
                pr[2] = new SqlParameter("@msj", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                _ = SqlHelper.ExecuteNonQuery(objCn, CommandType.StoredProcedure, "SP_Update_ProdListaCompra", pr);

                if (pr[2].Value.ToString() != string.Empty)
                {
                    dto.Msj = pr[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al actualizar los productos de la lista";
            }
            objCn.Close();
            return cr;
        }

        public DtoListaCompra Usp_CancelListaCompra(DtoB dtoBase)
        {
            DtoListaCompra dto = (DtoListaCompra)dtoBase;
            ClassResultV cr = new ClassResultV();
            SqlParameter[] pr = new SqlParameter[2];
            try
            {
                pr[0] = new SqlParameter("@idListaCompra", SqlDbType.Int)
                {
                    Value = dto.@idListaCompra
                };
                pr[1] = new SqlParameter("@msj", SqlDbType.Int);
                pr[1].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(objCn, CommandType.StoredProcedure, "SP_Cancel_ListaCompra", pr);
                if (pr[1].Value.ToString() != "")
                {
                    dto.Msj = pr[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error al anular lista de compras";
            }
            objCn.Close();
            return dto;
        }























    }
}
