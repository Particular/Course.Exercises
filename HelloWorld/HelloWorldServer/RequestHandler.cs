namespace HelloWorldServer
{
	using Messages;
	using NServiceBus;
	using NServiceBus.Logging;

	class RequestHandler : IHandleMessages<Request>
    {
	    private readonly ISaySomething saysSomething;

	    public RequestHandler(ISaySomething something)
	    {
	        saysSomething = something;
	    }

	    public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething);
            LogManager.GetLogger("RequestHandler").Info(saysSomething.InResponseTo(message.SaySomething));
        }
    }
}
