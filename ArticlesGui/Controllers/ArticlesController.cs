using System;
using System.Web.Mvc;
using Articles.Commands;
using Articles.ReadModel;
using Infrastructure;

namespace ArticlesGui.Controllers
{
    public class ArticlesController : Controller
    {
        readonly IArticleReadModelFacade _readModel;
        readonly ICommandSender _commandSender;

        public ArticlesController()
        {
            _readModel = ServiceLocator.ArticlesReadModel;
            _commandSender = ServiceLocator.CommandSender;
        }

        public ActionResult List()
        {
            return View(_readModel.GetArticles());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(InsertArticleInputModel model)
        {
            _commandSender.Send(new InsertArticle(Guid.NewGuid(), model.Name));
            return RedirectToAction("List");
        }

        public ActionResult Details(Guid id)
        {
            return View(_readModel.GetArticleDetails(id));
        }
    }
}