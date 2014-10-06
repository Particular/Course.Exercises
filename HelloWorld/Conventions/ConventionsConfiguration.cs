using System;
using System.Linq;
using NServiceBus;

namespace Conventions
{
    public class ConventionsConfiguration : INeedInitialization
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningMessagesAs(type => type.GetCustomAttributes(true).Any(t => t.GetType().Name == "MessageAttribute"))
                .DefiningTimeToBeReceivedAs(GetExpiration);
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
