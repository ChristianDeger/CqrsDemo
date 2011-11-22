using Articles.Events;
using Infrastructure;

namespace Articles.ReadModel
{
    public class ArticleListEventHandler : IHandles<ArticleInserted>
    {
        public void Handle(ArticleInserted message)
        {
            Database.ArticleList.Add(new ArticleListDto(message.Id, message.Name));
        }
    }
}