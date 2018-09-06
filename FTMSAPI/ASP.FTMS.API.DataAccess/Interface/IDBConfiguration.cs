using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.FTMS.API.DataAccess.Interface
{
  public  interface IDBConfiguration
    {
       

        IDBConfiguration RegisterAllConnectionSettingFromConfig();

        IDBConfiguration DefaultConnectionStringIs(string connectionName);

        IDataAccessFactory BuildConfigurations();
    }
}
