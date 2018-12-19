using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotKreida.Models {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public User() {
            Courses = new List<Course>();
        }
    }
}