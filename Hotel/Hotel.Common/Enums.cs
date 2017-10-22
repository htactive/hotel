using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Common
{
    public enum RoleTypeEnums
    {
        Administrator = 100,
    }
    public enum UserStatusEnums
    {
        Active = 1,
        Deactive = 2,
    }

    public enum BookingStatusEnums
    {
        Pending = 1,
        Approved = 2,
        Canceled = 3
    }
}