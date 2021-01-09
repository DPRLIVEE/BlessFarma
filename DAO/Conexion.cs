using System.Configuration;

namespace DAO
{
    public class Conexion
    {
        public string StrConL { get; set; }
        public string StrConI { get; set; }
        public string StrConMySQL { get; set; }
        #region Conexion
        public Conexion()
        {
            StrConL = ConfigurationManager.ConnectionStrings["BlessFarma"].ConnectionString;
        }
        #endregion

    }
}
