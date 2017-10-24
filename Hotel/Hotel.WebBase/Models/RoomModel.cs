using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string FeaturesJson { get; set; }
        public double? Price { get; set; }
        public int? CoverImageId { get; set; }
        public ImageModel CoverImage { get; set; }

        public int? CompanyId { get; set; }
        public CompanyModel Company { get; set; }

        public bool? IsHidden { get; set; }
        public int? Priority { get; set; }
        public List<RoomImageModel> RoomImages { get; set; }
    }
}
