using System;

namespace Messages
{
    [Expires(60)]
    [Message]
    public class Request
    {
        public Guid Guid { get; set; }

        [Encrypted]
        public string SaySomething { get; set; }
    }
}
