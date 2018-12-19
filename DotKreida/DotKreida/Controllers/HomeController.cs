using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotKreida.Contracts.Services;
using DotKreida.Services;
using DotKreida.ViewModels;

namespace DotKreida.Controllers {
    public class HomeController : Controller {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService) =>
            this.homeService = homeService;

        public ActionResult Index() {
            var viewModel = homeService.GetLastAddedCourses(5);

            return View(viewModel);
        }
    }
}