using Autofac;
using Autofac.Integration.Mvc;
using DotKreida.Contracts.Repositories;
using DotKreida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotKreida.Controllers.Api
{
    public class QuestionsApiController : ApiController
    {
        IUnitOfWork unitOfWork;

        public QuestionsApiController() { }

        public QuestionsApiController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        [HttpGet]
        [Route("api/questions/{courseId}")]
        public IEnumerable<Question> GetQuestionsByCourseId(int courseId)
        {
            return unitOfWork.Courses.GetById(courseId).Tests
                .FirstOrDefault()
                .Questions;
        }

        [HttpGet]
        [Route("api/questions/{courseId}/{id}")]
        public Question GetQuestion(int courseId, int id)
        {
            var question = unitOfWork.Courses.GetById(courseId)
                .Tests
                .FirstOrDefault()
                .Questions
                .Where(o => o.Id == id)
                .FirstOrDefault();

            return question;
        }

        [HttpPost]
        [Route("api/questions/{courseId}")]
        public void AddQuestion(int courseId, [FromBody]Question question)
        {
            unitOfWork.Courses.GetById(courseId)
                .Tests
                .FirstOrDefault()
                .Questions
                .Add(question);
            unitOfWork.Commit();
        }

        [HttpPut]
        [Route("api/questions/{courseId}/{id}")]
        public void UpdateLesson(int courseId, int id, [FromBody]Question question)
        {
            var course = unitOfWork.Courses.GetById(courseId);

            var questionFromDB = course
                .Tests
                .FirstOrDefault()
                .Questions
                .Where(o => o.Id == id)
                .FirstOrDefault();

            questionFromDB = question;
            unitOfWork.Courses.Update(course);
            unitOfWork.Commit();
        }

        [HttpDelete]
        [Route("api/questions/{courseId}/{id}")]
        public void DeleteQuestion(int courseId, int id)
        {
            var question = unitOfWork.Courses
                .GetById(courseId)
                .Tests
                .FirstOrDefault()
                .Questions
                .Where(o => o.Id == id)
                .FirstOrDefault();

            unitOfWork.Courses
                .GetById(courseId)
                .Tests
                .FirstOrDefault()
                .Questions
                .Remove(question);

            unitOfWork.Commit();
        }
    }
}
