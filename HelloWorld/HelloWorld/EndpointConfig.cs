namespace HelloWorld 
{
    using NServiceBus;
    using NServiceBus.Logging;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://nservicebus.com/GenericHost.aspx
	*/
    public class EndpointConfig : IConfigureThisEndpoint, IWantToRunWhenBusStartsAndStops
    {
        public void Start()
        {
            LogManager.GetLogger("EndpointConfig").Info("Hello World!");
        }

        public void Stop()
        {

        }
    }
}
