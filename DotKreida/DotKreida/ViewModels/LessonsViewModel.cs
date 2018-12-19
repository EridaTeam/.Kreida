using DotKreida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.ViewModels
{
    public class LessonsViewModel
    {
        List<Lesson> Lessons { get; }

        public LessonsViewModel(List<Lesson> lessons) =>
            Lessons = lessons;
    }
}