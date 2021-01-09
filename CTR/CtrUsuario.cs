using System.Collections.Generic;
using DAO;
using DTO;

namespace CTR
{
    public class CtrUsuario
    {
        public DtoUsuario Usp_Login(DtoB dtoBase)
        {
            return new DaoUsuario().Usp_Login(dtoBase);
        }
        public DtoUsuario Usp_GenerarCodidoContrasena(DtoB dtoBase)
        {
            return new DaoUsuario().Usp_GenerarCodidoContrasena(dtoBase);
        }
        public DtoUsuario Usp_VerificarCodContraseña(DtoB dtoBase)
        {
            return new DaoUsuario().Usp_VerificarCodContraseña(dtoBase);
        }
        public DtoUsuario Usp_CambioContraseña(DtoB dtoBase)
        {
            return new DaoUsuario().Usp_CambioContraseña(dtoBase);
        }
 
    }
}
