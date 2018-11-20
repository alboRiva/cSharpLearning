using Autofac;
using knowledgeBaseLibrary.DataAccess;
using System.Configuration;

namespace knowledgeBaseUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            //Needed to add a reference to System.Configuration.dll in project
            //var connectionString = ConfigurationManager.AppSettings["connectionStringSql"];
            var connectionString = ConfigurationManager.AppSettings["connectionStringSql"];
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationInjection>().As<IApplicationInjection>();
            builder.RegisterInstance(new SqlConnector(
                    connectionString))
                .As<IDataConnection>();

            return builder.Build();
        }
    }
}