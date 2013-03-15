using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace HelloWorldServer
{
    class RequestHandler : IHandleMessages<Request>
    {
        public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething);
        }
    }

}
