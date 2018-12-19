using Autofac;
using Autofac.Integration.Mvc;
using DotKreida.Contracts.Repositories;
using DotKreida.Contracts.Services;
using DotKreida.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.Services
{
    public class ContentService : IContentService
    {
        private IUnitOfWork UnitOfWork { get; }

        public ContentService()
        {
            UnitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        public TopicsViewModel GetAllTopics()
        {
            var topics = UnitOfWork.Topics.GetAll().ToList();

            return new TopicsViewModel(topics);
        }

        public CoursesViewModel GetCoursesByTopicId(int topicId)
        {
            var courses = UnitOfWork.Topics
                .GetById(topicId)
                .Courses
                .ToList();

            return new CoursesViewModel(courses);
        }

        public TestViewModel GetTestByCourseId(int courseId)
        {
            var test = UnitOfWork.Courses
                .GetById(courseId)
                .Tests
                .FirstOrDefault();

            return new TestViewModel(test);
        }

        public LessonsViewModel GetLessonsByCourseId(int courseId)
        {
            var lessons = UnitOfWork.Courses
                .GetById(courseId)
                .Lessons
                .ToList();

            return new LessonsViewModel(lessons);
        }
    }
}