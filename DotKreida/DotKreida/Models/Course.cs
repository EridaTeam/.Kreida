using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotKreida.Models {
    public class Course {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishingDate { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

        public Course() {
            Lessons = new List<Lesson>();
            Tests = new List<Test>();
        }
    }
}