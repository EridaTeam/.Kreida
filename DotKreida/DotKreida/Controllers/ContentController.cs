using DotKreida.Contracts.Repositories;
using DotKreida.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotKreida.Controllers
{
    public class ContentController : Controller
    {
        IContentService contentService;

        public ContentController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpGet]
        public ActionResult Topics()
        {
            var viewModel = contentService.GetAllTopics();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Courses(int topicId)
        {
            var viewModel = contentService.GetCoursesByTopicId(topicId);

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Lessons(int courseId)
        {
            var viewModel = contentService.GetLessonsByCourseId(courseId);

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Test(int courseId)
        {
            var viewModel = contentService.GetTestByCourseId(courseId);

            return View(viewModel);
        }

    }
}