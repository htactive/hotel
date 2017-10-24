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
    public class ArticleController : BaseController
    {
        public ArticleController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List(int page = 0)
        {
            return View();
        }

        public IActionResult Detail(string slug)
        {
            return View();
        }

    }
}
