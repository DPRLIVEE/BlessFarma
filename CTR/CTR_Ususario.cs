using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace CTR
{
    public class CTR_Ususario
    {
        DAO_Usuario objUsuario;

        public CTR_Ususario()
        {
            objUsuario = new DAO_Usuario();
        }
        public int login(string correo, string contraseña)
        {
            return objUsuario.login(correo, contraseña);
        }
    }
}
