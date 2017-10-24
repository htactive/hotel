using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class RoomImageModel
    {
        public int Id { get; set; }
        public int? Priority { get; set; }
        public int? RoomId { get; set; }
        public int? ImageId { get; set; }
        public RoomModel Room { get; set; }
        public ImageModel Image { get; set; }
    }
}
