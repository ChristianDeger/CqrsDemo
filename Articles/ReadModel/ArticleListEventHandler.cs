using System.Linq;
using Articles.Events;
using Infrastructure;

namespace Articles.ReadModel
{
    public class ArticleListEventHandler : IHandles<ArticleInserted>, IHandles<ArticleRenamed>
    {
        public void Handle(ArticleInserted message)
        {
            Database.ArticleList.Add(new ArticleListDto(message.Id, message.Name));
        }

        public void Handle(ArticleRenamed message)
        {
            Database.ArticleList.First(x => x.ArticleId == message.Id).Name = message.Name;
        }
    }
}