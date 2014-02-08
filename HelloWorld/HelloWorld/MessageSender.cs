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
            var message = new RequestMessage { SaySomething = "Say something" };
            
			Bus.Send(message);
            
			LogManager.GetLogger("MessageSender").Info("Sent message.");
        }

        public void Stop()
        {

        }
    }
}
