using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(
                "Server=.;Database=TalentPlusDB;Trusted_Connection=True;");
        }
    }
}
