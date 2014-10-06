namespace Messages
{
    [Expires(60)]
    [Message]
    public class Request
    {
        [Encrypted]
        public string SaySomething { get; set; }
    }
}
