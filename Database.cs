using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;

public static class Database
{
    public static SqlConnection GetConnection()
    {
        string cs = ConfigurationManager
            .ConnectionStrings["QLConn"].ConnectionString;

        return new SqlConnection(cs);
    }
}