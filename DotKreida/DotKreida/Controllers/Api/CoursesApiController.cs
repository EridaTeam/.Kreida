using Autofac;
using Autofac.Integration.Mvc;
using DotKreida.Contracts.Repositories;
using DotKreida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DotKreida.Controllers.Api
{
    public class CoursesApiController:ApiController
    {
        IUnitOfWork unitOfWork;

        public CoursesApiController(IUnitOfWork unitOfWork)
        {
            unitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        [HttpGet]
        [Route("api/courses/{topicId}")]
        public IEnumerable<Course> GetCourses(int topicId)
        {
            return unitOfWork.Topics.GetById(topicId).Courses;
        }

        [HttpGet]
        [Route("api/courses/{id}")]
        public Course GetCourse(int id)
        {
            return unitOfWork.Courses.GetById(id);
        }

        [HttpPost]
        [Route("api/courses")]
        public void AddCourse([FromBody]Course course)
        {
            unitOfWork.Courses.Add(course);
            unitOfWork.Commit();
        }

        [HttpPut]
        [Route("api/courses/{id}")]
        public void UpdateCourse(int id, [FromBody]Course course)
        {
            var courseFromDB = unitOfWork.Courses.GetById(id);
            courseFromDB = course;
            unitOfWork.Courses.Update(courseFromDB);
            unitOfWork.Commit();
        }

        [HttpDelete]
        [Route("api/courses/{id}")]
        public void DeleteCourse(int id)
        {
            var course = unitOfWork.Courses.GetById(id);
            unitOfWork.Courses.Remove(course);
            unitOfWork.Commit();
        }
    }
}