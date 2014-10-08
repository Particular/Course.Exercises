using Messages;
using NServiceBus;

namespace HelloWorldServer
{
    class RequestWithResponseHandler : IHandleMessages<RequestWithResponse>
    {
        public IBus Bus { get; set; }

        public void Handle(RequestWithResponse message)
        {
            Bus.Return(message.SaySomething.Length % 2);
        }
    }
}