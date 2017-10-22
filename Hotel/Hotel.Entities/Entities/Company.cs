using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string CompanyCode { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
