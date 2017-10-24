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
    public class ArticleController : BaseController
    {
        public ArticleController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List(int p = 0)
        {
            ViewBag.ActivePage = "article";
            return View();
        }

        public IActionResult Detail(string slug)
        {
            ViewBag.ActivePage = "article";
            ViewBag.ArticalTitle = "Hồ bơi đẹp nhất Châu Á";
            return View();
        }
    }
}
