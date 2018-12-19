using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Models;

namespace DotKreida.Contracts.Repositories.Specific {
    public interface ITopicRepository : IRepository<Topic> {
        void Remove(Topic entity);
    }
}