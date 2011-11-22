using System;
using System.Collections.Generic;

namespace Articles.ReadModel
{
    public interface IArticleReadModelFacade
    {
        IEnumerable<ArticleListDto> GetArticles();
        ArticleDetailsDto GetArticleDetails(Guid id);
        ArticlePriceHistoryDto GetPriceHistory(Guid id);
    }

    public class ArticleReadModelFacade : IArticleReadModelFacade
    {
        public IEnumerable<ArticleListDto> GetArticles()
        {
            return Database.ArticleList;
        }

        public ArticleDetailsDto GetArticleDetails(Guid id)
        {
            return Database.ArticleDetails[id];
        }

        public ArticlePriceHistoryDto GetPriceHistory(Guid id)
        {
            return Database.ArticePriceHistories[id];
        }
    }
}