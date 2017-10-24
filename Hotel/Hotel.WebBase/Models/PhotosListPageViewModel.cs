using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class PhotosListPageViewModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<PhotoModel> Photos { get; set; }
    }
}
