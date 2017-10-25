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
    public class GalleryController : BaseController
    {
        public GalleryController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult Index(int p = 0)
        {
            var viewmodel = this.GetPhotosListPage(9, p);
            return View(viewmodel);
        }
    }
}
