namespace WebApplication1.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Messages;

    public class SaySomethingController : AsyncController
    {
        public async Task<ActionResult> Index()
        {
            var message = new RequestWithResponse("Say 'WebApp'.");

            var response = await Startup.Bus.Send(message).Register();

            return new ContentResult { Content = "Response from server " + response };
        }
    }
}