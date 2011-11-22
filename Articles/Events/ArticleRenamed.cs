using System;
using Infrastructure;

namespace Articles.Events
{
    public class ArticleRenamed : Event
    {
        public readonly Guid Id;
        public readonly string Name;

        public ArticleRenamed(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}