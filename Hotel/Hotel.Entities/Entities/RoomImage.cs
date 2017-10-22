using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Entities
{
    public class RoomImage
    {
        [Key]
        public int Id { get; set; }
        public int? Priority { get; set; }
        public int? RoomId { get; set; }
        public int? ImageId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
    }
}
