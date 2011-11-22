using System;
using System.Collections.Generic;

namespace Articles.ReadModel
{
    public static class Database
    {
        public static List<ArticleListDto> ArticleList = new List<ArticleListDto>();
        public static Dictionary<Guid, ArticleDetailsDto> ArticleDetails = new Dictionary<Guid, ArticleDetailsDto>();
        public static Dictionary<Guid, ArticlePriceHistoryDto> ArticePriceHistories = new Dictionary<Guid, ArticlePriceHistoryDto>();
    }
}