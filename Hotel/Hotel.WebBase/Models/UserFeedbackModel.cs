using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class UserFeedbackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int? CompanyId { get; set; }
        public CompanyModel Company { get; set; }
    }
}
