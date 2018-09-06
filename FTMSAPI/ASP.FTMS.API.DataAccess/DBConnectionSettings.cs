using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.DataAccess.Interface
{
   public class DBConnectionSettings
    {
        public bool IsDefaultConnection;

        public string ConnectionName { get; set; }

        public string ProviderName { get; set; }

        public string ConnectionString { get; set; }

        public DBConnectionSettings() { }

        public DBConnectionSettings(string connectionName, string provider, string connectionString)
            : this(connectionName, provider, connectionString, false)
        {

        }

        public DBConnectionSettings(string name, string providerName, string connectionString, bool isDefaultConnection)
        {
            this.IsDefaultConnection = isDefaultConnection;
            this.ConnectionName = name;
            this.ProviderName = providerName;
            this.ConnectionString = connectionString;
        }
    }
}
