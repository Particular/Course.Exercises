namespace HelloWorldServer.Tests
{
    using NServiceBus;
    using NServiceBus.Testing;
    using NUnit.Framework;

    [TestFixture]
    public class ExpectPublishTests
    {

        [Test]
        public void Run()
        {
            Test.Initialize(c => c.Conventions().DefiningEventsAs(t => t == typeof (ICatalogue)));
            
            var cmd = new Catalogue()
            {
                CatalogueCode = "TEST"
            };
            Test.Handler<CatalogueAddedCommandHandler>()
                .ExpectPublish<ICatalogue>(e => e.CatalogueCode == cmd.CatalogueCode)
                .OnMessage(cmd);

        }
    }

    public interface ICatalogue
    {
        string CatalogueCode { get; set; }
    }

    public class Catalogue
    {
        public string CatalogueCode { get; set; }
    }

    public class CatalogueEvent : ICatalogue
    {
        public string CatalogueCode { get; set; }
    }

    public class CatalogueAddedCommandHandler : IHandleMessages<Catalogue>
    {
        public IBus Bus { get; set; }

        public void Handle(Catalogue message)
        {
            Bus.Publish<ICatalogue>(e => e.CatalogueCode = message.CatalogueCode);
        }
    }
}
