using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using knowledgeBaseLibrary.DataAccess;

namespace knowledgeBaseUI
{
   
    class ApplicationInjection : IApplicationInjection
    {
        public IDataConnection _dataConnection;
        public ApplicationInjection(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }
        public void Run()
        {
            Application.Run(new Search(_dataConnection));
        }
    }
}
