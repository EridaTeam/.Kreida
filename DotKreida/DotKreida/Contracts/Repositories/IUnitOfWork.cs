using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Contracts.Repositories.Specific;

namespace DotKreida.Contracts.Repositories {
    public interface IUnitOfWork {
        IUserRepository Users { get; }
        ITopicRepository Topics { get; }
        ICourseRepository Courses { get; }

        void Commit();
    }
}