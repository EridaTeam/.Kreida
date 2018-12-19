using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotKreida.Contracts.Services;
using DotKreida.Models;
using DotKreida.ViewModels;

namespace DotKreida.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        // GET: Profile
        public ActionResult Index(int userId)
        {
            var viewModel = profileService.GetProfile(userId);

            return View(viewModel);
        }

        [HttpPost, ActionName("Index")]
        public ActionResult SetPersonalData(ProfileIndexViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            profileService.SetPersonalData(viewModel);

            return RedirectToAction("Index", new { id = viewModel.User.Id });
        }
    }
}