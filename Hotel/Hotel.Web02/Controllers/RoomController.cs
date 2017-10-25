using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web02.Controllers
{
    public class RoomController : BaseController
    {
        public RoomController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List()
        {
            var rooms = GetRoomsListPage(10, null);
            return View(rooms);
        }

        public IActionResult Detail(string slug)
        {
            var model = GetRoomDetailPage(slug);
            return View(model);
        }
    }
}