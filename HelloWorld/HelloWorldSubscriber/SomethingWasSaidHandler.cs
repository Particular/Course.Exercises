namespace HelloWorldSubscriber
{
    using Messages;
    using NServiceBus;
    using NServiceBus.Logging;

    public class SomethingWasSaidHandler : IHandleMessages<SomethingWasSaid>
    {
        public IBus Bus { get; set; }

        public void Handle(SomethingWasSaid message)
        {
            LogManager.GetLogger("SomethingWasSaidHandler").Info("=======================================");
            LogManager.GetLogger("SomethingWasSaidHandler").Info(string.Format("Handling SomethingWasSaid event with id: {0}", message.Guid));

        }
    }
}