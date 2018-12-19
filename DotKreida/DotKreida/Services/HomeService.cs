using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Contracts.Repositories;
using DotKreida.Contracts.Services;
using DotKreida.ViewModels;
using Autofac;
using Autofac.Integration.Mvc;

namespace DotKreida.Services {
    public class HomeService : IHomeService {
        private IUnitOfWork UnitOfWork { get; }

        public HomeService() {
            UnitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        public HomeIndexViewModel GetLastAddedCourses(int number) {
            var courses = UnitOfWork.Courses.GetAll()
                .OrderByDescending(x => x.PublishingDate)
                .Take(number)
                .ToList();

            return new HomeIndexViewModel(courses);
        }
    }
}