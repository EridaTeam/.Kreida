using DotKreida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.ViewModels
{
    public class TopicsViewModel
    {
        public List<Topic> Topics { get; }

        public TopicsViewModel(List<Topic> topics) =>
            Topics = topics;
    }
}