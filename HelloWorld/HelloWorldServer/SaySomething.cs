namespace HelloWorldServer
{
    class SaySomething : ISaySomething
    {
        public string InResponseTo(string request)
        {
            return "Responding to " + request;
        }
    }
}