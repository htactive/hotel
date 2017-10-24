using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string Html { get; set; }
        public int? CoverImageId { get; set; }
        public ImageModel CoverImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsHidden { get; set; }
        public string Author { get; set; }
        public int? CompanyId { get; set; }
        public CompanyModel Company { get; set; }
    }
}
