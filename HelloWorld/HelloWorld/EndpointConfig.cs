using log4net.Config;
using NServiceBus.Log4Net;
using NServiceBus.Logging;

namespace HelloWorld
{
    using NServiceBus;
    using NServiceBus.Persistence;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantToRunWhenBusStartsAndStops
    {
        public void Customize(BusConfiguration configuration)
        {
            XmlConfigurator.Configure();

            LogManager.Use<Log4NetFactory>();
            
            configuration.UsePersistence<RavenDBPersistence>();
        }

        public void Start()
        {
            LogManager.GetLogger("EndpointConfig").Info("Hello Distributed World!");
        }

        public void Stop()
        {
        }
    }
}
