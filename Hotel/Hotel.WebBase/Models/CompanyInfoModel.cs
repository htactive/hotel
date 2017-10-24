using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class CompanyInfoModel
    {
        public int CompanyId { get; set; }
        public int? LogoImageId { get; set; }
        public string CompanyName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public string Email1 { get; set; }
        public string Email2 { get; set; }

        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
        public string Skype { get; set; }
        public string YouTube { get; set; }

        public float? MapLatitude { get; set; }
        public float? MapLongitude { get; set; }

        public CompanyModel Company { get; set; }
        public ImageModel Logo { get; set; }

    }
}
