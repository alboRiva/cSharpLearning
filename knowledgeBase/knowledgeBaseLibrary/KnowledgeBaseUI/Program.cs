using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeBaseUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialize the database connection
            knowledgeBaseLibrary.GlobalConfig.InitiazileConnections(true,true);

            Application.Run(new SubmitPostPage());
            //Application.Run(new SearchPage());
        }
    }
}
