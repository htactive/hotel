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
    public class ContactController : BaseController
    {
        public ContactController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public bool SubmitFeedback(SubmitFeedbackRequestModel request)
        {
            return true;
        }

    }
}
