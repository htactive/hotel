using Hotel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.WebBase.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public RoleTypeEnums RoleType { get; set; }
        public List<UserRoleModel> UserRoles { get; set; }
    }
}
