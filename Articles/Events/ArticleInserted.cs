using System;
using Infrastructure;

namespace Articles.Events
{
    public class ArticleInserted : Event
    {
        public readonly Guid Id;
        public readonly string Name;

        public ArticleInserted(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}