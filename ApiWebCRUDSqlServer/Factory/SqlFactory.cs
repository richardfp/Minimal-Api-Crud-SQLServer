using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiWebCRUDSqlServer.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Server=localhost; Database=master; User=sa; Password=adminWEB123#; Trusted_Connection=False; TrustServerCertificate=True;");
        }
    }
}
