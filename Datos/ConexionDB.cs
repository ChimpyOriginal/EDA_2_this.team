using System.Data.SqlClient;
using System.Configuration;

namespace ControlEscolar.Datos
{
    public class ConexionDB
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ControlEscolarConnectionString"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
