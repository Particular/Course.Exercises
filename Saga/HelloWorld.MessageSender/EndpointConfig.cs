
namespace HelloWorld.MessageSender
{
    using NServiceBus;
    using NServiceBus.Persistence;

	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
	    public void Customize(BusConfiguration configuration)
	    {
            configuration.UsePersistence<RavenDBPersistence>();
	    }
    }
}
