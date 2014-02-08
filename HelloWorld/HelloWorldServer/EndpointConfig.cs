namespace HelloWorldServer
{
	using Messages;
	using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
			Configure.Serialization.Xml(m => m.Namespace("http://acme.com/"));

            Configure.With()
                .DefaultBuilder()
                .DefiningMessagesAs(t => t.Assembly == typeof(RequestMessage).Assembly && t.Name.EndsWith("Message"));
        }
    }
}