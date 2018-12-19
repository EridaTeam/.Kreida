using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Models;

namespace DotKreida.ViewModels {
    public class HomeIndexViewModel {
        public List<Course> LastAddedCourses { get; }

        public HomeIndexViewModel(List<Course> courses) =>
            LastAddedCourses = courses;
    }
}