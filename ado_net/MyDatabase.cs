using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace ado_net
{
    public class MyDatabase
    {
        public string server { get; set; }
        public string database { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        private DbConnection dbConnection;
        private DbCommand dbcommand;
        public MyDatabase(IOptions<Config> opts)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            Config config = opts.Value;
            builder["Server"] = config.server;
            builder["Database"] = config.database;
            builder["User ID"] = config.user;
            builder["Password"] = config.password;
            builder["Trusted_Connection"] = false;
            string sqlConnectionString = builder.ToString();
            System.Console.WriteLine();
            dbConnection = new SqlConnection(sqlConnectionString);
            dbConnection.StateChange += this._log;

        }
        public void Open()
        {

            dbConnection.Open();

        }
        public void Close()
        {

            dbConnection.Close();

        }
        public DbCommand command()
        {
            if (dbcommand == null)
            {
                dbcommand = dbConnection.CreateCommand();
                return dbcommand;
            }
            else
            {
                return dbcommand;
            }
        }
        private void _log(object sender, StateChangeEventArgs e)
        {
            System.Console.WriteLine("State: " + e.CurrentState);
        }
    }
}