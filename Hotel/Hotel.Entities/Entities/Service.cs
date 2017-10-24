using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string Slug { get; set; }
        [StringLength(256)]
        public string Title { get; set; }
        [StringLength(int.MaxValue)]
        public string Html { get; set; }
        [StringLength(int.MaxValue)]
        public string ShortDescription { get; set; }
        public int? CoverImageId { get; set; }
        [ForeignKey("CoverImageId")]
        public Image CoverImage { get; set; }
        public bool? IsHidden { get; set; }
        public int? Priority { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
