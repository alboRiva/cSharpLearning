using System.Linq;
using System.Reflection;
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
            var connectionString = ConfigurationManager.AppSettings["connectionString"];
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationInjection>().As<IApplicationInjection>();
            builder.RegisterInstance(new XmlConnector(
                    connectionString))
                .As<IDataConnection>();

            //ConfigurationManager

            return builder.Build();
        }
    }
}