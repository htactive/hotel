using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class ArticlesListPageViewModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ArticleModel> Articles { get; set; }
    }

    public class ArticleDetailPageViewModel
    {
        public ArticleModel Article { get; set; }
        public List<ArticleModel> RelatedArticles { get; set; }
    }
}
