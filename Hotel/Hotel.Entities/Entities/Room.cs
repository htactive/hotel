using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string Slug { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(int.MaxValue)]
        public string Description { get; set; }
        [StringLength(int.MaxValue)]
        public string FeaturesJson { get; set; }
        public double? Price { get; set; }
        public int? CoverImageId { get; set; }
        [ForeignKey("CoverImageId")]
        public Image CoverImage { get; set; }

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public bool? IsHidden { get; set; }
        public int? Priority { get; set; }
        public List<RoomImage> RoomImages { get; set; }
    }
}
