using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knowledgeBaseLibrary
{
    public static class GlobalConfig            
    {
        /// <summary>
        /// Possibility to save to one or many places
        /// </summary>
        public static IDataConnection Connection { get; private set; }      //version 6.0

        public static void InitiazileConnections(Enums.DatabaseType db)
        {
            switch (db)
            {
                case Enums.DatabaseType.Sql:
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;

                case Enums.DatabaseType.Xml:
                    //TODO: implement Xml connector
                    break;

                default:
                    throw new InvalidEnumArgumentException(); 
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
