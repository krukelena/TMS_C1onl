using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Core
{
    public NpgsqlConnection? Connection;
    public class SimpleDBConnector
    {
       var connectionString =
             $"Host={Configurator.DbSettings.Server};" +
             $"Port={Configurator.DbSettings.Port};" +
             $"DataBase={Configurator.DbSettings.Schema};" +
             $"User ID={Configurator.DbSettings.Username};" +
             $"Password={Configurator.DbSettings.Password};";

        public NpgsqlConnection Connection { get; internal set; }

        internal void CloseConnection()
        {
            throw new NotImplementedException();
        }
    }
}
