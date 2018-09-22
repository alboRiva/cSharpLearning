using System;
using System.Collections.Generic;
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
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();        //version 6.0

        public static void InitiazileConnections(bool database, bool textFile)
        {
            if (database)
            {
                SqlConnector sql = new SqlConnector();
                //Add to a IDataConnection list
                Connections.Add(sql);
            }

            if (textFile)
            {
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
