using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using ASP.FTMS.API.DataAccess;
using ASP.FTMS.API.DataAccess.Interface;
using System.Data.SqlClient;
using System.Configuration;

namespace ASP.FTMS.API.DataAccess
{
   public class DataAccessFactory : IDataAccessFactory
    {
        private readonly IDictionary<string, DBConnectionSettings> connectionObj=new Dictionary<string,DBConnectionSettings>();
        
      
        public DataAccessFactory()
        { }
        public DataAccessFactory(IDictionary<string,DBConnectionSettings> connectionObj)
        {
            this.connectionObj = connectionObj;
        }

        public IDataAccessFactory CreateDBInstance()
        {

            DBConfiguration DbConfig = new DBConfiguration();

            IDataAccessFactory dataAccessFactoryObj = DbConfig.RegisterAllConnectionSettingFromConfig()
                .DefaultConnectionStringIs("connection")
                .BuildConfigurations();

            return dataAccessFactoryObj;
        }
        public IDataAccess Create()
        {
            
                var setting = connectionObj.FirstOrDefault(obj => obj.Value.IsDefaultConnection).Value;
                if (setting == null)
                    throw new ArgumentNullException("Unable to find default connection string");

                return new DataAccess(setting.ProviderName, setting.ConnectionString);
            
        }
        public  IDataAccess Create(string connectionName)
        {
            if (!connectionObj.ContainsKey(connectionName))
                throw new ArgumentNullException("Unable to find connection name specified.");

            var setting = connectionObj[connectionName];

            return new DataAccess(setting.ProviderName, setting.ConnectionString);
        }
       
    }
}
