using System.Collections.Generic;

using Articles.ReadModel;

namespace ArticlesService.List
{
    public class ArticlesListResource
    {
        public IEnumerable<ArticleListDto> Articles { get; set; }
    }
}