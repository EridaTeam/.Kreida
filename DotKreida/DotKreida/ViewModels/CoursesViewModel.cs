using DotKreida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.ViewModels
{
    public class CoursesViewModel
    {
        public List<Course> Courses { get; }

        public CoursesViewModel(List<Course> courses)
        {
            Courses = courses;
        }
    }
}