using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public CompanyInfo CompanyInfo { get; set; }


        public List<TopSlide> TopSlides { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Article> Articles { get; set; }
        public List<Service> Services { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<UserFeedback> UserFeedbacks { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
