namespace HelloWorld.Saga
{
    using System;
    using Messages;
    using NServiceBus;
    using NServiceBus.Saga;

    public class ShippingSaga : Saga<ShippingSagaData>
        , IAmStartedByMessages<ShippOrder>
        , IHandleMessages<FedExResponse>
        , IHandleMessages<UpsResponse>        
        , IHandleTimeouts<FedexTimedOut>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ShippingSagaData> mapper)
        {
            mapper.ConfigureMapping<ShippOrder>(m => m.OrderId).ToSaga(m => m.Id);
            mapper.ConfigureMapping<FedExResponse>(m => m.OrderId).ToSaga(m => m.Id);
        }

        public void Handle(ShippOrder msg)
        {
            Data.Id = msg.OrderId;

            Data.OrderDetails = msg.ProductName + " " + msg.ShippingAddress;

            Data.SentToFedex = true;

            Console.WriteLine("Handeling ShippOrder command with id: {0}", msg.OrderId);

            Bus.Send<ShipToFedEx>(m => m.OrderId = msg.OrderId);
            
            RequestTimeout<FedexTimedOut>(TimeSpan.FromSeconds(15));
        }

        public void Handle(FedExResponse msg)
        {
            Console.WriteLine("Handling FedExResponse orderId: {0}, Data.OrderId: {1}", msg.OrderId, Data.Id);

            this.MarkAsComplete();
        }

        public void Timeout(FedexTimedOut state)
        {
            Bus.Send<ShipToUps>(m =>
            {
                m.Data = Data.OrderDetails;
                m.OrderId = Data.Id;
            });
        }

        public void Handle(UpsResponse msg)
        {
            Console.WriteLine("Handling UpsResponse orderId: {0}, Data.OrderId: {1}", msg.OrderId, Data.Id);

            this.MarkAsComplete();
        }
    }

    public class ShippingSagaData : IContainSagaData
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
        public bool SentToFedex { get; set; }
        public string OrderDetails { get; set; }
    }
}
