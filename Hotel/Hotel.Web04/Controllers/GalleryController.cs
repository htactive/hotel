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
    public class GalleryController : BaseController
    {
        public GalleryController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult Index(int p = 0)
        {
            return View();
        }
    }
}
