using Hotel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public BookingStatusEnums? Status { get; set; }

        public int? CompanyId { get; set; }
        public CompanyModel Company { get; set; }
    }
}
