using System;
using Infrastructure;

namespace Articles.Commands
{
    public class ChangeArticlePrice : Command
    {
        public readonly Guid Id;
        public readonly int Price;
        public readonly int OriginalVersion;

        public ChangeArticlePrice(Guid id, int price, int originalVersion)
        {
            Id = id;
            Price = price;
            OriginalVersion = originalVersion;
        }
    }
}