using System.Collections.Generic;
using DAO;
using DTO;

namespace CTR
{
    public class CtrTipoUsuario
    {
        public List<DtoTipoUsuario> Usp_GetAllPerfiles()
        {
            return new DaoTipoUsuario().Usp_GetAllPerfiles();
        }
    }
}
