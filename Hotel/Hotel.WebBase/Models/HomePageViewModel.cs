using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class HomePageViewModel
    {
        public CompanyInfoModel CompanyInfo { get; set; }
        public List<TopSlideModel> TopSlides { get; set; }
        public List<RoomModel> Rooms { get; set; }
        public List<ServiceModel> Services { get; set; }
        public List<ArticleModel> Articles { get; set; }
        public List<PhotoModel> Photos { get; set; }
    }
}
