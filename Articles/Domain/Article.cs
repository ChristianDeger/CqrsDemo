using System;
using Articles.Events;
using Infrastructure;

namespace Articles.Domain
{
    public class Article : AggregateRoot
    {
        Guid _id;

        public override Guid Id
        {
            get { return _id; }
        }

        public Article()
        {
        }

        public Article(Guid id, string name)
        {
            ApplyAndStoreChange(new ArticleInserted(id, name));
        }

        public void Apply(ArticleInserted @event)
        {
            _id = @event.Id;
        }
    }
}