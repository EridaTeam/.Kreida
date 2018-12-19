using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.Models {
    public class Question {
        public int Id { get; set; }
        public string Text { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public int ValidAnswer { get; set; }

        public virtual Test Test { get; set; }
    }
}