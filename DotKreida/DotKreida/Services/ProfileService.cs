using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Contracts.Repositories;
using DotKreida.Contracts.Services;
using DotKreida.ViewModels;
using Autofac;
using Autofac.Integration.Mvc;

namespace DotKreida.Services
{
    public class ProfileService:IProfileService
    {
        private IUnitOfWork UnitOfWork { get; }

        public ProfileService()
        {
            UnitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        public ProfileIndexViewModel GetProfile(int userId)
        {
            var user = UnitOfWork.Users
                .GetById(userId);

            return new ProfileIndexViewModel(user);
        }

        public void SetPersonalData(ProfileIndexViewModel viewModel)
        {
            var user = UnitOfWork.Users
                .GetById(viewModel.User.Id);
            user = viewModel.User;
            UnitOfWork.Users.Update(user);

            UnitOfWork.Commit();
        }
    }
}