using Messages;
using NServiceBus.Testing;
using NUnit.Framework;

namespace HelloWorldServer.Tests
{
    [TestFixture]
    public class RequestWithResponseHandlerTests
    {
        [Test]
        public void Handle_ReturnsStatusCodeOne()
        {
            Test.Initialize();

            var message = new RequestWithResponse("Foo");

            Test.Handler<RequestWithResponseHandler>()
                .ExpectReturn<int>(i => i == 1)
                .OnMessage(message);
        }
    }
}
