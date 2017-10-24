using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class ServicesListPageViewModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ServiceModel> Services { get; set; }
    }

    public class ServiceDetailPageViewModel
    {
        public ServiceModel Service { get; set; }
        public List<ServiceModel> RelatedServices { get; set; }
    }
}
