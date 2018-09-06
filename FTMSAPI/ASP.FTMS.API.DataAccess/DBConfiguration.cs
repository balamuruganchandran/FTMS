using ASP.FTMS.API.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace ASP.FTMS.API.DataAccess
{
    public class DBConfiguration : IDBConfiguration
    {
        public IDictionary<string, DBConnectionSettings> connectionObj = new Dictionary<string, DBConnectionSettings>();
        public IDataAccessFactory BuildConfigurations()
        {
          
            if(connectionObj.Count(obj=>obj.Value.IsDefaultConnection)!=1)
                    throw new InvalidOperationException("No default connection string is specified");

            var factoryObj = new DataAccessFactory(connectionObj);
            return factoryObj;
        }

        public IDBConfiguration DefaultConnectionStringIs(string connectionName)
        {
            connectionObj[connectionName].IsDefaultConnection = true;
            return this;
        }

        public IDBConfiguration RegisterAllConnectionSettingFromConfig()
        {
            this.connectionObj = ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>()
                           .ToDictionary(
                                        key => key.Name,
                                        value => new DBConnectionSettings(value.Name, value.ProviderName, value.ConnectionString)
                                        );
            return this;
        }
    }
}
