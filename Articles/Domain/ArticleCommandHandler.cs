using Articles.Commands;
using Infrastructure;

namespace Articles.Domain
{
    public class ArticleCommandHandler : IHandles<InsertArticle>,
                                         IHandles<RenameArticle>,
                                         IHandles<ChangeArticlePrice>
    {
        readonly IRepository<Article> _repository;

        public ArticleCommandHandler(IRepository<Article> repository)
        {
            _repository = repository;
        }

        public void Handle(InsertArticle message)
        {
            var article = new Article(message.Id, message.Name);
            _repository.Save(article, -1);
        }

        public void Handle(RenameArticle message)
        {
            var article = _repository.GetById(message.Id);
            article.Rename(message.Name);
            _repository.Save(article, message.OriginalVersion);
        }

        public void Handle(ChangeArticlePrice message)
        {
            var article = _repository.GetById(message.Id);
            article.ChangePrice(message.Price);
            _repository.Save(article, message.OriginalVersion);
        }
    }
}