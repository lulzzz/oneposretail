using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnePos.DataCollector
{
   public class GetDatabaseInfo
    {
       public IDatabase GetDatabase(string DbType,string ConnectionString)
       {
           switch (DbType)
           {
               case "SqlServer":
                return new SqlServerHandler(ConnectionString);
               //case "Oracle" :
               // return new OracleHandler(ConnectionString);
               //case "Sharepoint Lists":
               // return new SharepointHandler(ConnectionString);
           }
           return new SqlServerHandler(ConnectionString);
       }
   
   
    }
}
