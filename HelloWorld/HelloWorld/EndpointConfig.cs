using Messages;

namespace HelloWorld
{
    using NServiceBus;
    using NServiceBus.Persistence;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningMessagesAs(t => t.Assembly == typeof(RequestMessage).Assembly && t.Name.EndsWith("Message"));

            configuration.UsePersistence<RavenDBPersistence>();
        }
    }
}
