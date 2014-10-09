using System.Threading.Tasks;
using System.Web.Mvc;
using Messages;

namespace MvcApplication1.Controllers
{
    public class QuerySomethingController : AsyncController
    {
        public async Task<ActionResult> Index()
        {
            Startup.Bus.Send(new Query(10));

            return new ContentResult {Content = ""};
        }
    }
}