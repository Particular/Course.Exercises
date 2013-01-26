using NServiceBus;

namespace HelloWorldServer
{
    public class Class1 : IConfigureThisEndpoint, AsA_Server,
                IWantCustomInitialization, ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            NServiceBus.Configure.With().DefaultBuilder()
                .XmlSerializer("http://acme.com");
        }

        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<Auth>();
        }
    }
}
