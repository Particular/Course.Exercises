namespace HelloWorld
{
    using NServiceBus;
    using NServiceBus.Logging;
    using NServiceBus.Persistence;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantToRunWhenBusStartsAndStops
    {
        public void Customize(BusConfiguration configuration)
        {
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
