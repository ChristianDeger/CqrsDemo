using System.Collections.Generic;

namespace Articles.ReadModel
{
    public interface IArticleReadModelFacade
    {
        IEnumerable<ArticleListDto> GetArticles();
    }

    public class ArticleReadModelFacade : IArticleReadModelFacade
    {
        public IEnumerable<ArticleListDto> GetArticles()
        {
            return Database.ArticleList;
        }
    }
}