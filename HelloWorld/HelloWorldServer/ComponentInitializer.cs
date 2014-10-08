
namespace HelloWorldServer
{
    using NServiceBus;

    class ComponentInitializer : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.RegisterComponents(c => c.ConfigureComponent<SaySomething>(DependencyLifecycle.InstancePerCall));
        }
    }
}