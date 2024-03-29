﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web02.Controllers
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
    }
}