using System.Data.SqlClient;

namespace Utils
{
    public class DbUtils
    {
        private readonly string _connection;
        public DbUtils(string datasource, string database)
        {
            _connection = new SqlConnectionStringBuilder
            {
                DataSource = datasource, IntegratedSecurity = true, InitialCatalog = database
            }.ConnectionString;
        }

        public SqlConnection GetDbConnection()
        {
            return new SqlConnection(_connection);
        }
    }
}