using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.Models {
    public class Lesson {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

        public virtual Course Course { get; set; }
    }
}