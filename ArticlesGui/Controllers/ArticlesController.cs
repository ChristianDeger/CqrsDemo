using System.Web.Mvc;

namespace ArticlesGui.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
    }
}