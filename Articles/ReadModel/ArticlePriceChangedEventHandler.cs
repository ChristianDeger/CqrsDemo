﻿using System.Collections.Generic;
using Articles.Events;
using Infrastructure;

namespace Articles.ReadModel
{
    public class ArticlePriceChangedEventHandler : IHandles<ArticleInserted>, IHandles<ArticleRenamed>,
                                                   IHandles<ArticlePriceChanged>
    {
        public void Handle(ArticleInserted message)
        {
            Database.ArticePriceHistories.Add(message.Id,
                                              new ArticlePriceHistoryDto
                                                  {
                                                      ArticleId = message.Id,
                                                      Name = message.Name,
                                                      PriceChanges = new List<ArticlePriceHistoryDto.PriceChange>()
                                                  });
        }

        public void Handle(ArticleRenamed message)
        {
            Database.ArticePriceHistories[message.Id].Name = message.Name;
        }

        public void Handle(ArticlePriceChanged message)
        {
            Database.ArticePriceHistories[message.Id].PriceChanges
                .Add(new ArticlePriceHistoryDto.PriceChange {ChangedAt = message.ChangedAt, Price = message.Price});
        }
    }
}