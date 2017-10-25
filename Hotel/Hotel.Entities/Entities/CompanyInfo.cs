using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class CompanyInfo
    {
        [Key]
        public int CompanyId { get; set; }
        public int? LogoImageId { get; set; }
        [StringLength(256)]
        public string CompanyName { get; set; }
        [StringLength(int.MaxValue)]
        public string ShortDescription { get; set; }
        [StringLength(int.MaxValue)]
        public string LongDescription { get; set; }

        [StringLength(512)]
        public string Email1 { get; set; }
        [StringLength(512)]
        public string Email2 { get; set; }

        [StringLength(512)]
        public string Phone1 { get; set; }
        [StringLength(512)]
        public string Phone2 { get; set; }

        [StringLength(512)]
        public string Address1 { get; set; }
        [StringLength(512)]
        public string Address2 { get; set; }

        [StringLength(512)]
        public string Facebook { get; set; }
        [StringLength(512)]
        public string Twitter { get; set; }
        [StringLength(512)]
        public string GooglePlus { get; set; }
        [StringLength(512)]
        public string Skype { get; set; }
        [StringLength(512)]
        public string YouTube { get; set; }
        [StringLength(512)]
        public string FacebookIframe { get; set; }

        public float? MapLatitude { get; set; }
        public float? MapLongitude { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [ForeignKey("LogoImageId")]
        public Image Logo { get; set; }


    }
}
