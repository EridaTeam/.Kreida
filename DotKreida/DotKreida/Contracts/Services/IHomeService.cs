using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Models;
using DotKreida.Contracts.Repositories;
using DotKreida.ViewModels;

namespace DotKreida.Contracts.Services {
    public interface IHomeService {
        HomeIndexViewModel GetLastAddedCourses(int number);
    }
}