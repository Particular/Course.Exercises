using Microsoft.Owin;
using Microsoft.Owin.BuilderProperties;
using NServiceBus;
using NServiceBus.Persistence;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcApplication1.Startup))]

namespace MvcApplication1
{
    public partial class Startup
    {
        public static IBus Bus { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var properties = new AppProperties(app.Properties);
            var token = properties.OnAppDisposing;

            var configuration = new BusConfiguration();

            configuration.ScaleOut().UseSingleBrokerQueue();

            configuration.UsePersistence<RavenDBPersistence>();

            Bus = NServiceBus.Bus.Create(configuration).Start();

            token.Register(() => Bus.Dispose());
        }
    }
}
