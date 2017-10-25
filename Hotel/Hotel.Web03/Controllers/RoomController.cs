using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web03.Models;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web01.Controllers
{
    public class RoomController : BaseController
    {
        public RoomController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List()
        {
            var viewmodel = GetRoomsListPage(10);
            return View(viewmodel);
        }

        public IActionResult Detail(string slug)
        {
            var viewmodel = GetRoomDetailPage(slug);
            return View(viewmodel);
        }
    }
}
