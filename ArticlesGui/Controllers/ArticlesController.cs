using System.Web.Mvc;
using Articles.ReadModel;

namespace ArticlesGui.Controllers
{
    public class ArticlesController : Controller
    {
        readonly IArticleReadModelFacade _readModel;

        public ArticlesController()
        {
            _readModel = ServiceLocator.ArticlesReadModel;
        }

        public ActionResult List()
        {
            return View(_readModel.GetArticles());
        }
    }
}