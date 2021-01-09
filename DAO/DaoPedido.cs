using System;
using System.Data;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAO
{
    public class DaoPedido : DaoB
    {
        public ClassResultV Usp_GetAllPedido(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            DtoPedido dto = (DtoPedido)dtoBase;
            List<SqlParameter> pr = new List<SqlParameter>
            {
                new SqlParameter("@idPedido", dto.Criterio),
                new SqlParameter("@NomUsuario", dto.NomUsuario)
                //new SqlParameter("@tienda", dto.Tienda),
                //new SqlParameter("@tipo", dto.TipoMovimiento),
                //new SqlParameter("@estado", dto.IB_Estado)
            };
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_Pedidos", pr.ToArray());
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    dto = new DtoPedido
                    {
                        idPedido = getValue("idPedido", reader).Value_Int32,
                        correlativo = getValue("correlativo", reader).Value_String,
                        NomUsuario = getValue("NomUsuario", reader).Value_String,
                        razonSocial = getValue("razonSocial", reader).Value_String,
                        fechaEmision = getValue("fechaEmision", reader).Value_DateTime,
                        fechaEntrega = getValue("fechaEntrega", reader).Value_DateTime,
                        NombreEstado = getValue("NombreEstado", reader).Value_String,
                        idEstadoPedido = getValue("idEstadoPedido", reader).Value_Int32,
                        idListaCompra = getValue("idListaCompra", reader).Value_Int32

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

        public ClassResultV Usp_GetListaCompraSeleccionada(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            DtoListaCompraSeleccionado dto = (DtoListaCompraSeleccionado)dtoBase;
            List<SqlParameter> pr = new List<SqlParameter>
            {
                new SqlParameter("@idListaCompra", dto.Criterio),
            };

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_ListaCompra_Seleccionado", pr.ToArray());
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    dto = new DtoListaCompraSeleccionado
                    {
                        nombreProducto = getValue("nombreProducto", reader).Value_String,
                        formato = getValue("formato", reader).Value_String,
                        nombreLaboratorio = getValue("nombreLaboratorio", reader).Value_String,
                        precioCompra = getValue("precioCompra", reader).Value_Decimal,
                        idProducto = getValue("idProducto", reader).Value_Int32,
                        idListaCompra = getValue("idListaCompra", reader).Value_Int32
                    };
                    cr.List.Add(dto);
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al consultar SP_Get_ListaCompra_Seleccionado";
            }
            objCn.Close();
            return cr;
        }

        public ClassResultV Usp_GetAllProveedores()
        {
            ClassResultV cr = new ClassResultV();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_Proveedores");
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    DtoProveedor dtop = new DtoProveedor
                    {
                        idProveedor = reader.GetValue(reader.GetOrdinal("idProveedor")) == DBNull.Value ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("idProveedor"))),
                        razonSocial = Convert.ToString(reader.GetValue(reader.GetOrdinal("razonSocial")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("razonSocial"))),
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

        public ClassResultV Usp_GetAllMetodoPago()
        {
            ClassResultV cr = new ClassResultV();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_MetodoPago");
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    DtoMetodoPago dtop = new DtoMetodoPago
                    {
                        idMetodoPago = reader.GetValue(reader.GetOrdinal("idMetodoPago")) == DBNull.Value ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("idMetodoPago"))),
                        metodoPago = Convert.ToString(reader.GetValue(reader.GetOrdinal("metodoPago")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("metodoPago"))),
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


        public ClassResultV Usp_GetCargarPedido(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            DtoPedido dto = (DtoPedido)dtoBase;
            List<SqlParameter> pr = new List<SqlParameter>
            {
                new SqlParameter("@idPedido", dto.Criterio),
            };

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_Cargar_Pedido", pr.ToArray());
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    DtoPedido dtop = new DtoPedido
                    {
                        idPedido = getValue("idPedido", reader).Value_Int32,
                        fechaEmision = getValue("fechaEmision", reader).Value_DateTime,
                        fechaEntrega = getValue("fechaEntrega", reader).Value_DateTime,
                        idMetodoPago = getValue("idMetodoPago", reader).Value_Int32,
                        idProveedor = getValue("idProveedor", reader).Value_Int32,
                        idProducto = getValue("idProducto", reader).Value_Int32,
                        nombreProducto = getValue("nombreProducto", reader).Value_String,
                        cantidad = getValue("cantidad", reader).Value_Int32,
                        formato = getValue("formato", reader).Value_String,
                        idLaboratorio = getValue("idLaboratorio", reader).Value_Int32,
                        nombreLaboratorio = getValue("nombreLaboratorio", reader).Value_String,
                        precioCompra = getValue("precioCompra", reader).Value_Decimal,
                        precioTotal = getValue("precioTotal", reader).Value_Decimal,
                        razonSocial = getValue("razonSocial", reader).Value_String,
                        metodoPago = getValue("metodoPago", reader).Value_String

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
        public DtoPedido Usp_InsertPedido(DtoB dtoBase)
        {
            DtoPedido dto = (DtoPedido)dtoBase;
            SqlParameter[] pr = new SqlParameter[7];
            try
            {


                pr[0] = new SqlParameter("@idMetodoPago", SqlDbType.Int)
                {
                    Value = dto.idMetodoPago
                };
                pr[1] = new SqlParameter("@fechaEntrega", SqlDbType.DateTime)
                {
                    Value = dto.fechaEntrega
                };

                pr[2] = new SqlParameter("@idProveedor", SqlDbType.Int)
                {
                    Value = dto.idProveedor
                };
                pr[3] = new SqlParameter("@idListaCompra", SqlDbType.Int)
                {
                    Value = dto.idListaCompra
                };
                pr[4] = new SqlParameter("@idUsuario", SqlDbType.Int)
                {
                    Value = dto.idUsuario
                };
                pr[5] = new SqlParameter("@precioTotal", SqlDbType.Decimal)
                {
                    Value = dto.precioTotal
                };
                pr[6] = new SqlParameter("@idPedido", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                _ = SqlHelper.ExecuteNonQuery(objCn, CommandType.StoredProcedure, "SP_Insert_Pedido", pr);
                if (!string.IsNullOrEmpty(pr[6].Value.ToString()))
                {
                    dto.idPedido = int.Parse(pr[6].Value.ToString());
                }

            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error al registrar el Pedido";
            }
            objCn.Close();
            return dto;
        }

        public ClassResultV Usp_InsertDetallePedido(DtoB dtoBase)
        {
            DtoPedido dto = (DtoPedido)dtoBase;
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

        public ClassResultV Usp_GetPedidoLista(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            DtoPedido dto = (DtoPedido)dtoBase;
            List<SqlParameter> pr = new List<SqlParameter>
            {
                new SqlParameter("@idPedido", dto.Criterio)
            };
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Get_ListaPedido", pr.ToArray());
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    dto = new DtoPedido
                    {
                        idPedido = getValue("idPedido", reader).Value_Int32,
                        correlativo = getValue("correlativo", reader).Value_String,
                        NombreEstado = getValue("NombreEstado", reader).Value_String,
                        fechaEmision = getValue("fechaEmision", reader).Value_DateTime,
                        fechaEntrega = getValue("fechaEntrega", reader).Value_DateTime,
                        metodoPago = getValue("metodoPago", reader).Value_String,
                        tipo = getValue("tipo", reader).Value_String,
                        nombreProducto = getValue("nombreProducto", reader).Value_String,
                        cantidad = getValue("cantidad", reader).Value_Int32,
                        formato = getValue("formato", reader).Value_String,
                        precioCompra = getValue("precioCompra", reader).Value_Decimal,
                        precioTotal = getValue("precioTotal", reader).Value_Decimal,
                        razonSocial = getValue("razonSocial", reader).Value_String

                    };
                    cr.List.Add(dto);
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al consultar Lista Pedido";
            }
            objCn.Close();
            return cr;
        }

        public ClassResultV Usp_UpdateProcesar(DtoB dtoBase)
        {

            ClassResultV cr = new ClassResultV();
            DtoPedido dto = (DtoPedido)dtoBase;
            SqlParameter[] pr = new SqlParameter[2];
            try
            {
                pr[0] = new SqlParameter("@idPedido", SqlDbType.Int)
                {
                    Value = dto.@idPedido
                };
                pr[1] = new SqlParameter("@idTipo", SqlDbType.Int)
                {
                    Value = dto.idTipo
                };


                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_Update_EstadoPedido", pr);
                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    dto = new DtoPedido
                    {
                        httpPedido = reader.GetValue(reader.GetOrdinal("correo")) == DBNull.Value ? string.Empty : Convert.ToString(reader.GetValue(reader.GetOrdinal("correo")))
                    };
                    cr.List.Add(dto);
                }

            }

            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al procesar el Pedido.";
            }
            objCn.Close();
            return cr;
        }

        public DtoPedido Usp_UpdatePedido(DtoB dtoBase)
        {
            DtoPedido dto = (DtoPedido)dtoBase;
            SqlParameter[] pr = new SqlParameter[6];
            try
            {


                pr[0] = new SqlParameter("@idMetodoPago", SqlDbType.Int)
                {
                    Value = dto.idMetodoPago
                };
                pr[1] = new SqlParameter("@fechaEntrega", SqlDbType.DateTime)
                {
                    Value = dto.fechaEntrega
                };

                pr[2] = new SqlParameter("@idProveedor", SqlDbType.Int)
                {
                    Value = dto.idProveedor
                };
                pr[3] = new SqlParameter("@idPedido", SqlDbType.Int)
                {
                    Value = dto.idPedido
                };
                pr[4] = new SqlParameter("@idUsuario", SqlDbType.Int)
                {
                    Value = dto.idUsuario
                };
                pr[5] = new SqlParameter("@precioTotal", SqlDbType.Decimal)
                {
                    Value = dto.precioTotal
                };

                _ = SqlHelper.ExecuteNonQuery(objCn, CommandType.StoredProcedure, "SP_Update_Pedido", pr);

            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error al actualizar el Pedido";
            }
            objCn.Close();
            return dto;
        }

    }
}
