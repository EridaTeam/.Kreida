using DotKreida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotKreida.ViewModels
{
    public class ProfileIndexViewModel
    {
        public User User { get; }

        public ProfileIndexViewModel(User user) =>
            User = user;
    }
}