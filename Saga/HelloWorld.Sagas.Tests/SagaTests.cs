namespace HelloWorld.Sagas.Tests
{
    using System;
    using Messages;
    using Messages.Commands;
    using Messages.Messages;
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

        [Test]
        public void TimeoutTest()
        {
            //.ExpectTimeoutToBeSetAt<ReadyToSellTimeout>((state, span) => span == dtPurchase)
            //.ExpectPublish<LoanStatusUpdated>(r => r.Status == LoanStatusEnum.Funded)
            //.When(s => s.Handle(new Funded { FundedDate = DateTime.Now, LoanGUID = guidTest }))

            var orderId = Guid.NewGuid();
            var message = new ShippOrder { OrderId = orderId };

            Test.Initialize();

            Test.Saga<ShippingSaga>(orderId)
                //.ExpectTimeoutToBeSetAt<FedexTimedOut>((m, at) => at == DateTime.UtcNow.AddSeconds(15))
                .ExpectTimeoutToBeSetAt<FedexTimedOut>((m, at) => at == TimeSpan.FromSeconds(15))
                .When(saga => saga.Handle(message));
        }
    }
}
