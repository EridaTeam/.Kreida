using DotKreida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotKreida.ViewModels
{
    public class TestViewModel
    {
        public Test Test { get; }

        public TestViewModel(Test test) =>
            Test = test;
    }
}
