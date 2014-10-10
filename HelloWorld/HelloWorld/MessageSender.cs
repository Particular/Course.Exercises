using System;

namespace HelloWorld
{
	using NServiceBus.Logging;
	using Messages;
	using NServiceBus;

	class MessageSender : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Bus.OutgoingHeaders["user"] = "udi";

            var message = new Request { SaySomething = "Say something", Guid = Guid.NewGuid() };

            Bus.Send(message);
            
			LogManager.GetLogger("MessageSender").Info("Sent message.");
        }

        public void Stop()
        {
        }
    }
}
