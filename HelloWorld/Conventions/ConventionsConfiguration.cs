namespace Conventions
{
    using System;
    using System.Linq;
    using NServiceBus;

    public class ConventionsConfiguration : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningMessagesAs(type => type.GetCustomAttributes(true).Any(t => t.GetType().Name == "MessageAttribute"))
                .DefiningEventsAs(type => type.GetCustomAttributes(true).Any(t => t.GetType().Name == "EventAttribute"))
                .DefiningTimeToBeReceivedAs(GetExpiration)
                .DefiningEncryptedPropertiesAs(p => p.GetCustomAttributes(true).Any(t => t.GetType().Name == "EncryptedAttribute"));
        }

        private TimeSpan GetExpiration(Type type)
        {
            dynamic expiresAttribute = type.GetCustomAttributes(true)
                        .SingleOrDefault(t => t.GetType()
                        .Name == "ExpiresAttribute");

            return expiresAttribute == null
                       ? TimeSpan.MaxValue
                       : expiresAttribute.ExpiresAfter;
        }
    }
}
