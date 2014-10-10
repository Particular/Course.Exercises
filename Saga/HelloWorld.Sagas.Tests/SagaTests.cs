namespace HelloWorld.Sagas.Tests
{
    using System;
    using Messages;
    using NServiceBus.Testing;
    using NUnit.Framework;
    using Saga;

    [TestFixture]
    public class SagaTests
    {
        [Test]
        public void BasicTest()
        {
            var orderId = Guid.NewGuid();
            var message = new ShippOrder {OrderId = orderId};

            Test.Initialize();

            Test.Saga<ShippingSaga>(orderId)
                .WhenReceivesMessageFrom("HelloWorld.MessageSender")
                .ExpectSend<ShipToFedEx>(m => m.OrderId = orderId)
                .When(saga => saga.Handle(message));
        }
    }
}
