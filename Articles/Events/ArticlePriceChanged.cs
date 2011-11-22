using System;
using Infrastructure;

namespace Articles.Events
{
    public class ArticlePriceChanged : Event
    {
        public readonly Guid Id;
        public readonly int Price;
        public readonly DateTime ChangedAt;

        public ArticlePriceChanged(Guid id, int price, DateTime changedAt)
        {
            Id = id;
            Price = price;
            ChangedAt = changedAt;
        }
    }
}