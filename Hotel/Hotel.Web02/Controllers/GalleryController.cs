using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web02.Controllers
{
    public class GalleryController : BaseController
    {
        public GalleryController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult Index(int p = 0)
        {
            var galary = GetPhotosListPage(20, p);
            return View(galary);
        }
    }
}