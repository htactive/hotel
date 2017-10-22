using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebBase.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string S3FileKey { get; set; }
    }
}
