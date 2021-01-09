using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoUsuario : DaoB
    {
        public DtoUsuario Usp_Login(DtoB dtBase)
        {
            DtoUsuario dto = (DtoUsuario)dtBase;
            DtoUsuario dtou = new DtoUsuario();
            SqlParameter[] pr = new SqlParameter[3];

            try
            {
                pr[0] = new SqlParameter("@Correo", SqlDbType.VarChar, 100);
                pr[0].Value = dto.correo;

                pr[1] = new SqlParameter("@Contraseña", SqlDbType.VarChar, 100);
                pr[1].Value = V_ValidaPrNull(dto.contraseña);

                pr[2] = new SqlParameter("@msj", SqlDbType.VarChar, 100);
                pr[2].Direction = ParameterDirection.Output;

                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure,"SP_Login", pr);

                if (Convert.ToString(pr[2].Value == DBNull.Value ? string.Empty : pr[2].Value) != "")
                {
                    dtou.LugarError = ToString("Inicio de sesión");
                    dtou.ErrorMsj = pr[2].Value.ToString();
                }
                else
                {
                    if (reader.Read())
                    {
                        dtou.nombreUsuario = Convert.ToString(reader.GetValue(reader.GetOrdinal("nombreUsuario")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("nombreUsuario")));
                        dtou.apellidoUsuario = Convert.ToString(reader.GetValue(reader.GetOrdinal("apellidoUsuario")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("apellidoUsuario")));
                        dtou.correo = Convert.ToString(reader.GetValue(reader.GetOrdinal("Correo")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("Correo")));
                      
                        dtou.nombreTipoUsuario = Convert.ToString(reader.GetValue(reader.GetOrdinal("nombreTipoUsuario")) == DBNull.Value ? string.Empty : reader.GetValue(reader.GetOrdinal("nombreTipoUsuario")));
                        dtou.idUsuario = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("IdUsuario")) == DBNull.Value ? 0 : reader.GetValue(reader.GetOrdinal("IdUsuario")));
                        dtou.Foto = (byte[])(reader.GetValue(reader.GetOrdinal("Foto")) == DBNull.Value ? byte.MinValue : reader.GetValue(reader.GetOrdinal("Foto")));
                    }
                }
            }
            catch (Exception ex)
            {
                dtou.LugarError = ex.StackTrace;
                dtou.ErrorEx = ex.Message;
                dtou.ErrorMsj = "Error al crear usuario.";
            }
            objCn.Close();
            return dtou;
        }


        public DtoUsuario Usp_GenerarCodidoContrasena(DtoB dtBase)
        {
            DtoUsuario dto = (DtoUsuario)dtBase;
            DtoUsuario dtou = new DtoUsuario();
            SqlParameter[] pr = new SqlParameter[4];
            try
            {
                pr[0] = new SqlParameter("@Correo", SqlDbType.VarChar, 80);
                pr[0].Value = dto.correo;
                pr[1] = new SqlParameter("@msj", SqlDbType.VarChar, 80);
                pr[1].Direction = ParameterDirection.Output;
                pr[2] = new SqlParameter("@codigo", SqlDbType.VarChar, 10);
                pr[2].Direction = ParameterDirection.Output;
                pr[3] = new SqlParameter("@correo", SqlDbType.VarChar, 40);
                pr[3].Direction = ParameterDirection.Output;

                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_GenerarCodidoContraseña", pr);
                if (Convert.ToString(pr[1].Value == DBNull.Value ? string.Empty : pr[1].Value) != "")
                {
                    dtou.LugarError = ToString("Usp_GenerarCodidoContraseña");
                    dtou.ErrorMsj = pr[1].Value.ToString();
                }
                if (Convert.ToString(pr[2].Value == DBNull.Value ? string.Empty : pr[2].Value) != "")
                    dtou.Codigo = pr[2].Value.ToString();
                if (Convert.ToString(pr[3].Value == DBNull.Value ? string.Empty : pr[3].Value) != "")
                    dtou.correo = pr[3].Value.ToString();
            }
            catch (Exception ex)
            {
                dtou.LugarError = ex.StackTrace;
                dtou.ErrorEx = ex.Message;
                dtou.ErrorMsj = "Error al crear codigo.";
            }
            objCn.Close();
            return dtou;
        }

        public DtoUsuario Usp_VerificarCodContraseña(DtoB dtBase)
        {
            DtoUsuario dto = (DtoUsuario)dtBase;
            DtoUsuario dtou = new DtoUsuario();
            SqlParameter[] pr = new SqlParameter[3];
            try
            {
                pr[0] = new SqlParameter("@Correo", SqlDbType.VarChar, 50);
                pr[0].Value = dto.correo;
                pr[1] = new SqlParameter("@Codigo", SqlDbType.VarChar, 10);
                pr[1].Value = dto.Codigo;
                pr[2] = new SqlParameter("@msj", SqlDbType.VarChar, 50);
                pr[2].Direction = ParameterDirection.Output;

                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_VerificarCodContraseña", pr);
                if (Convert.ToString(pr[2].Value == DBNull.Value ? string.Empty : pr[2].Value) != "")
                    dtou.ErrorMsj = pr[2].Value.ToString();
            }
            catch (Exception ex)
            {
                dtou.LugarError = ex.StackTrace;
                dtou.ErrorEx = ex.Message;
                dtou.ErrorMsj = "Error al verificar el código.";
            }
            objCn.Close();
            return dtou;
        }

        public DtoUsuario Usp_CambioContraseña(DtoB dtBase)
        {
            DtoUsuario dto = (DtoUsuario)dtBase;
            DtoUsuario dtou = new DtoUsuario();
            SqlParameter[] pr = new SqlParameter[2];
            try
            {
                pr[0] = new SqlParameter("@Correo", SqlDbType.VarChar, 50);
                pr[0].Value = dto.correo;
                pr[1] = new SqlParameter("@Contraseña", SqlDbType.VarChar, 50);
                pr[1].Value = dto.contraseña;
                SqlDataReader reader = SqlHelper.ExecuteReader(objCn, CommandType.StoredProcedure, "SP_CambioContraseña", pr);
            }
            catch (Exception ex)
            {
                dtou.LugarError = ex.StackTrace;
                dtou.ErrorEx = ex.Message;
                dtou.ErrorMsj = "Error al cambiar la contraseña.";
            }
            objCn.Close();
            return dtou;
        }
    }
}
