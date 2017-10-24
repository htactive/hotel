using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase.Models
{
    public class RoomsListPageViewModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<RoomModel> Rooms { get; set; }
    }

    public class RoomDetailPageViewModel
    {
        public RoomModel Room { get; set; }
        public List<RoomModel> RelatedRooms { get; set; }
    }
}
