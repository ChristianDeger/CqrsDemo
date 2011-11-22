using Articles.Events;
using Infrastructure;

namespace Articles.ReadModel
{
    public class ArticleDetailsEventHandler : IHandles<ArticleInserted>,
        IHandles<ArticleRenamed>
    {
        public void Handle(ArticleInserted message)
        {
            Database.ArticleDetails.Add(message.Id, new ArticleDetailsDto
                                                        {
                                                            ArticleId = message.Id,
                                                            Name =  message.Name,
                                                            Version = message.Version
                                                        });
        }

        public void Handle(ArticleRenamed message)
        {
            var article = Database.ArticleDetails[message.Id];
            article.Name = message.Name;
            article.Version = message.Version;
        }
    }
}