using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.WebBase.Controllers;
using Hotel.Repository;

namespace Hotel.Web02.Controllers
{
    public class ArticleController : BaseController
    {
        public ArticleController(InstanceRepository repository) : base(repository)
        {
        }

        public IActionResult List(int p = 0)
        {
            var viewmodel = this.GetArticlesListPage(8, p);
            return View(viewmodel);
        }


        public IActionResult Detail(string slug)
        {
            var viewmodel = this.GetArticleDetailPage(slug);
            ViewBag.NewestArticles = this.GetArticlesListPage(5, null).Articles;
            return View(viewmodel);
        }
    }
}