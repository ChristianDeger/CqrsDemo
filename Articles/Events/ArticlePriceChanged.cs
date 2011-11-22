using System;
using Infrastructure;

namespace Articles.Events
{
    public class ArticlePriceChanged : Event
    {
        public readonly Guid Id;
        public readonly int Price;

        public ArticlePriceChanged(Guid id, int price)
        {
            Id = id;
            Price = price;
        }
    }
}