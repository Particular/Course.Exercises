using System;

namespace Messages
{
    [Event]
    public class SomethingWasSaid
    {
        public Guid Guid { get; set; }
    }
}