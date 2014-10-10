namespace HelloWorldServer
{
	using Messages;
	using NServiceBus;
	using NServiceBus.Logging;

	class RequestHandler : IHandleMessages<Request>
    {
	    private readonly ISaySomething saysSomething;
	    private readonly IBus bus;

	    public RequestHandler(ISaySomething something, IBus bus)
	    {
	        this.bus = bus;
	        saysSomething = something;
	    }

	    public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething);
            LogManager.GetLogger("RequestHandler").Info(saysSomething.InResponseTo(message.SaySomething));

            bus.Publish<SomethingWasSaid>(e => { e.Guid = message.Guid; });
        }
    }
}
