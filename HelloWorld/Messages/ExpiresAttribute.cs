namespace Messages
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExpiresAttribute : Attribute
    {
        public ExpiresAttribute(int expiresAfterSeconds)
        {
            ExpiresAfter = TimeSpan.FromSeconds(expiresAfterSeconds);
        }

        public TimeSpan ExpiresAfter { get; private set; }
    }
}
