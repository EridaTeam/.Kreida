using Autofac;
using Autofac.Integration.Mvc;
using DotKreida.Contracts.Repositories;
using DotKreida.Models;
using DotKreida.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotKreida.Controllers.Api
{
    public class LessonsApiController : ApiController
    {
        IUnitOfWork unitOfWork;

        public LessonsApiController() { }

        public LessonsApiController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        [HttpGet]
        [Route("api/lessons/{courseId}")]
        public IEnumerable<Lesson> GetLessonsByCourseId(int courseId)
        {
            return unitOfWork.Courses.GetById(courseId).Lessons;
        }

        [HttpGet]
        [Route("api/lessons/{courseId}/{id}")]
        public Lesson GetLesson(int courseId, int id)
        {
            var lesson = unitOfWork.Courses.GetById(courseId)
                .Lessons
                .Where(o => o.Id == id)
                .FirstOrDefault();

            return lesson;
        }

        [HttpPost]
        [Route("api/lessons/{courseId}")]
        public void AddLesson(int courseId, [FromBody]Lesson lesson)
        {
            unitOfWork.Courses.GetById(courseId).Lessons.Add(lesson);
            unitOfWork.Commit();
        }

        [HttpPut]
        [Route("api/lessons/{courseId}/{id}")]
        public void UpdateLesson(int courseId, int id, [FromBody]Lesson lesson)
        {
            var course = unitOfWork.Courses.GetById(courseId);

            var lessonFromDB = course
                .Lessons
                .Where(o => o.Id == id)
                .FirstOrDefault();

            lessonFromDB = lesson;
            unitOfWork.Courses.Update(course);
            unitOfWork.Commit();
        }

        [HttpDelete]
        [Route("api/lessons/{courseId}/{id}")]
        public void DeleteLesson(int courseId, int id)
        {
            var lesson = unitOfWork.Courses
                .GetById(courseId)
                .Lessons
                .Where(o => o.Id == id)
                .FirstOrDefault();

            unitOfWork.Courses
                .GetById(courseId)
                .Lessons
                .Remove(lesson);

            unitOfWork.Commit();
        }
    }
}
