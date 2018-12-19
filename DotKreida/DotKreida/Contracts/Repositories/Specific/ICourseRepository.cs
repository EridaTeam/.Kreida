using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Models;

namespace DotKreida.Contracts.Repositories.Specific {
    public interface ICourseRepository : IRepository<Course> {
        void Remove(Course entity);
    }
}