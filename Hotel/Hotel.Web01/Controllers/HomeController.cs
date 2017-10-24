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
    public class HomeController : BaseController
    {
        public HomeController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult Index()
        {
            var homePageViewModel = GetHomePage();
            return View(homePageViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
