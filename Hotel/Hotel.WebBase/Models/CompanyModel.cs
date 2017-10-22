using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
