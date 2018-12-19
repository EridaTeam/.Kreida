using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.Models {
    public class Test {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Test() {
            Questions = new List<Question>();
        }
    }
}