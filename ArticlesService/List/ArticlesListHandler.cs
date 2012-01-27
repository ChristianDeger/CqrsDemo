using Articles.ReadModel;

namespace ArticlesService.List
{
    public class ArticlesListHandler
    {
        readonly IArticleReadModelFacade _readModel;

        public ArticlesListHandler()
        {
            _readModel = ServiceLocator.ArticlesReadModel;
        }

        public ArticlesListResource Get()
        {
            return new ArticlesListResource { Articles = _readModel.GetArticles() };
        }
    }
}