﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web02.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}