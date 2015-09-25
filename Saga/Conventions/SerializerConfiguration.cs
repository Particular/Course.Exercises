using NServiceBus;

namespace Conventions
{
    public class SerializerConfiguration : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseSerialization<XmlSerializer>()
                .Namespace("http://acme.com/");
        }
    }
}