﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web04.Models;
using Hotel.WebBase.Controllers;
using Hotel.Repository;
using Hotel.WebBase.Models;

namespace Hotel.Web04.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult Index()
        {
            ViewBag.ActivePage = "contact";
            return View();
        }

        [HttpPost]
        public bool SubmitFeedback(SubmitFeedbackRequestModel request)
        {
            return true;
        }
    }
}
