using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        public string Title { get; set; }
        [StringLength(int.MaxValue)]
        public string Description { get; set; }
        public bool? IsHidden { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
