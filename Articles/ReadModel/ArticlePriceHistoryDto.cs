using System;
using System.Collections.Generic;

namespace Articles.ReadModel
{
    public class ArticlePriceHistoryDto
    {
        public Guid ArticleId;
        public string Name;
        public List<PriceChange> PriceChanges = new List<PriceChange>();

        public class PriceChange
        {
            public int Price;
            public DateTime ChangedAt;
        }
    }
}