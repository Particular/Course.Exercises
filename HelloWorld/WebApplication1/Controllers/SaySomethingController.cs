namespace WebApplication1.Controllers
{
    using System.Web.Mvc;
    using Messages;

    public class SaySomethingController : Controller
    {
        // GET: SaySomething
        public ActionResult Index()
        {
            Startup.Bus.Send<Request>(m => m.SaySomething = "Say 'WebApp'.");

            return new ContentResult {Content = "Message Sent"};
        }
    }
}