using Microsoft.Owin;
using WebApplication1;

[assembly: OwinStartup(typeof (Startup))]

namespace WebApplication1
{
    using Microsoft.Owin.BuilderProperties;
    using NServiceBus;
    using NServiceBus.Persistence;
    using Owin;

    public partial class Startup
    {
        public static IBus Bus { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var properties = new AppProperties(app.Properties);
            var token = properties.OnAppDisposing;

            var configuration = new BusConfiguration();

            configuration.ScaleOut().UseSingleBrokerQueue();
            configuration.RijndaelEncryptionService();
            configuration.UsePersistence<RavenDBPersistence>();
            //configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
            configuration.EndpointName("WebApplication1");
            Bus = NServiceBus.Bus.Create(configuration);

            token.Register(() => Bus.Dispose());
        }
    }
}