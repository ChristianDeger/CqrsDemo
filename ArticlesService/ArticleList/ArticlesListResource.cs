using System.Collections.Generic;
using Articles.ReadModel;

namespace ArticlesService.ArticleList
{
    public class ArticlesListResource : List<ArticleListDto>
    {
        public ArticlesListResource()
        {
        }

        public ArticlesListResource(IEnumerable<ArticleListDto> collection) : base(collection)
        {
        }
    }
}