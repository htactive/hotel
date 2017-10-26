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
    public class ServiceController : BaseController
    {
        public ServiceController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List(int p = 0)
        {
            var viewmodel = this.GetServicesListPage(10, p);
            return View(viewmodel);
        }

        public IActionResult Detail(string slug)
        {
            var viewmodel = this.GetServiceDetailPage(slug);
            return View(viewmodel);
        }

    }
}
