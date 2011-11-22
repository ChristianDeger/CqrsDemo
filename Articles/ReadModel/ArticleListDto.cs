using System;

namespace Articles.ReadModel
{
    public class ArticleListDto
    {
        public Guid Id;
        public string Name;

        public ArticleListDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}