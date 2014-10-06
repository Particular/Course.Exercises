namespace Messages
{
    [Expires(60)]
    [Message]
    public class Request
    {
        public string SaySomething { get; set; }
    }
}
