using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web04.Models;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web04.Controllers
{
    public class RoomController : BaseController
    {
        public RoomController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List(int p = 0)
        {
            var viewmodel = this.GetRoomsListPage(9, p);
            return View(viewmodel);
        }

        public IActionResult Detail(string slug)
        {
            var viewmodel = this.GetRoomDetailPage(slug);
            return View(viewmodel);
        }
    }
}
