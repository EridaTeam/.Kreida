using DotKreida.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.Contracts.Services
{
    public interface IContentService
    {
        TopicsViewModel GetAllTopics();
        CoursesViewModel GetCoursesByTopicId(int topicId);
        TestViewModel GetTestByCourseId(int courseId);
        LessonsViewModel GetLessonsByCourseId(int courseId);
    }
}