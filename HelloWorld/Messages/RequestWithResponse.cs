namespace Messages
{
    [Message]
    public class RequestWithResponse
    {
        public RequestWithResponse(string saySomething)
        {
            SaySomething = saySomething;
        }

        [Encrypted]
        public string SaySomething { get; private set; }
    }
}