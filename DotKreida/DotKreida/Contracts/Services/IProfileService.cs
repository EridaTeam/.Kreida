using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotKreida.ViewModels;

namespace DotKreida.Contracts.Services
{
    public interface IProfileService
    {
        ProfileIndexViewModel GetProfile(int userId);
        void SetPersonalData(ProfileIndexViewModel viewModel);
    }
}
