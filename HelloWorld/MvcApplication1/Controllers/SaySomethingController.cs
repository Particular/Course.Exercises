using System.Web.Mvc;
using Messages;

namespace MvcApplication1.Controllers
{
    public class SaySomethingController : Controller
    {
        public ActionResult Index()
        {
            MvcApplication.Bus.Send<Request>(m => m.SaySomething = "Say 'WebApp'.");

            return new ContentResult { Content = "Message sent" };
        }
    }
}
