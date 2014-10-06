using NServiceBus.Persistence;

namespace HelloWorldServer
{
	using Messages;
	using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseSerialization<XmlSerializer>()
                .Namespace("http://acme.com/");

            configuration.Conventions()
                .DefiningMessagesAs(t => t.Assembly == typeof(RequestMessage).Assembly && t.Name.EndsWith("Message"));

            configuration.UsePersistence<RavenDBPersistence>();
        }
    }
}