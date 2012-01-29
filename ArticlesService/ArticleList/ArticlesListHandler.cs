using Articles.ReadModel;

namespace ArticlesService.ArticleList
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
            return new ArticlesListResource(_readModel.GetArticles());
        }
    }
}