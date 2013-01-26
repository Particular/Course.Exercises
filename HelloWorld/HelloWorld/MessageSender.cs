using log4net;
using Messages;
using NServiceBus;

namespace HelloWorld
{
    class MessageSender : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            Bus.OutgoingHeaders["user"] = "udi";
            var message = new Request { SaySomething = "Say something" };
            Bus.Send(message);
            LogManager.GetLogger("MessageSender").Info("Sent message.");
        }

        public void Stop()
        {

        }
    }
}
