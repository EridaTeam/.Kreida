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
    public class TestsApiController : ApiController
    {
        IUnitOfWork unitOfWork;

        public TestsApiController(IUnitOfWork unitOfWork)
        {
            unitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        [HttpGet]
        [Route("api/tests/{courseId}")]
        public Test GetTestByCourseId(int courseId)
        {
            return unitOfWork.Courses.GetById(courseId).Tests.FirstOrDefault();
        }

        [HttpPost]
        [Route("api/tests/{courseId}")]
        public void AddLesson(int courseId, [FromBody]Test test)
        {
            unitOfWork.Courses.GetById(courseId).Tests.Add(test);
            unitOfWork.Commit();
        }

        [HttpPut]
        [Route("api/tests/{courseId}/{id}")]
        public void UpdateTest(int courseId, int id, [FromBody]Test test)
        {
            var course = unitOfWork.Courses.GetById(courseId);

            var testFromDB = course
                .Tests
                .Where(o => o.Id == id)
                .FirstOrDefault();

            testFromDB = test;
            unitOfWork.Courses.Update(course);
            unitOfWork.Commit();
        }

        [HttpDelete]
        [Route("api/tests/{courseId}/{id}")]
        public void DeleteTest(int courseId, int id)
        {
            var test = unitOfWork.Courses
                .GetById(courseId)
                .Tests
                .Where(o => o.Id == id)
                .FirstOrDefault();

            unitOfWork.Courses
                .GetById(courseId)
                .Tests
                .Remove(test);

            unitOfWork.Commit();
        }
    }
}
