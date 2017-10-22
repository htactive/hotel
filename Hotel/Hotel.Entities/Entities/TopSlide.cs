using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class TopSlide
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string Text1 { get; set; }
        [StringLength(256)]
        public string Text2 { get; set; }
        [StringLength(256)]
        public string Text3 { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int? ImageId { get; set; }
        [StringLength(256)]
        public string Url { get; set; }
        public bool? IsHidden { get; set; }
        public int? Priority { get; set; }

        [ForeignKey("ImageId")]
        public Image Image { get; set; }

    }
}
