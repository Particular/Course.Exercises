using NServiceBus;

namespace HelloWorldServer
{
    public class Class1 : IConfigureThisEndpoint, AsA_Server,
                IWantCustomInitialization, ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            NServiceBus.Configure.With()
                .DefaultBuilder()
                .XmlSerializer("http://acme.com")
                .RijndaelEncryptionService()
                .RunCustomAction(() =>
                Configure.Instance.Configurer.ConfigureComponent<SaySomething>(
                                     DependencyLifecycle.SingleInstance)
                );
        }


        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<Auth>();
        }
    }
}
