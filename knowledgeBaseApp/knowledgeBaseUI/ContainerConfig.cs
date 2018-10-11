using System.Linq;
using System.Reflection;
using Autofac;
using knowledgeBaseLibrary.DataAccess;

namespace knowledgeBaseUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationInjection>().As<IApplicationInjection>();
            builder.RegisterInstance(new XmlConnector(
                    @"C:\Users\rivaa\source\repos\cSharpLearning\knowledgeBaseApp\knowledgeBaseLibrary\Data\PostRepository.xml"))
                .As<IDataConnection>();

            //ConfigurationManager

            return builder.Build();
        }
    }
}