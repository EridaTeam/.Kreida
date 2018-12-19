using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.Models {
    public class Topic {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Topic() {
            Courses = new List<Course>();
        }
    }
}