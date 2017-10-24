using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class TopSlideModel
    {
        public int Id { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public int? CompanyId { get; set; }
        public CompanyModel Company { get; set; }
        public int? ImageId { get; set; }
        public string Url { get; set; }
        public bool? IsHidden { get; set; }
        public int? Priority { get; set; }

        public ImageModel Image { get; set; }
    }
}
