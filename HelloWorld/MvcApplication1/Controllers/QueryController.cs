using System.Web.Mvc;
using Messages;

namespace MvcApplication1.Controllers
{
    public class QueryController : Controller
    {
        public void Index()
        {
            MvcApplication.Bus.Send(new Query() {NumberOfResponses = 10});
        }    
    }
}