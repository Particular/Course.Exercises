using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace Messages
{
    [TimeToBeReceived("00:01:00")]
    public class Request : IMessage
    {
        public string SaySomething { get; set; }
    }
}
