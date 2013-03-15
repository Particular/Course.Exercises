using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace HelloWorld
{
    class MessageSender : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            var message = new Request { SaySomething = "Say something" };
            Bus.Send(message);
            LogManager.GetLogger("MessageSender").Info("Sent message.");
        }

        public void Stop()
        {

        }
    }
}
