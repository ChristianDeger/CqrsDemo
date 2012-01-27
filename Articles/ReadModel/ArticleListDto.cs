using System;

namespace Articles.ReadModel
{
    [Serializable]
    public class ArticleListDto
    {
        public Guid ArticleId;
        public string Name;

        public ArticleListDto(Guid articleId, string name)
        {
            ArticleId = articleId;
            Name = name;
        }
    }
}