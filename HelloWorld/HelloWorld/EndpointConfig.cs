using log4net;

namespace HelloWorld 
{
    using Messages;

    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://nservicebus.com/GenericHost.aspx
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefiningMessagesAs(t => t.Assembly == typeof(RequestMessage).Assembly && t.Name.EndsWith("Message"));
        }
    }
}
