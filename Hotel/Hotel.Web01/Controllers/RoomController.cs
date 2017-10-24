using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web01.Models;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web01.Controllers
{
    public class RoomController : BaseController
    {
        public RoomController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List(int p = 0)
        {
            var viewmodel = GetRoomsListPage(10);
            return View();
        }

        public IActionResult Detail(string slug)
        {
            var viewmodel = GetRoomDetailPage(slug);
            return View();
        }

    }
}
