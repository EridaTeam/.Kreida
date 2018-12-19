using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotKreida.Contracts.Repositories;
using DotKreida.Contracts.Repositories.Specific;
using DotKreida.Repositories.Specific;

namespace DotKreida.Repositories {
    public class UnitOfWork : IUnitOfWork, IDisposable {
        private readonly SqlServerContext db = new SqlServerContext();

        public IUserRepository Users { get; }
        public ITopicRepository Topics { get; }
        public ICourseRepository Courses { get; }

        public UnitOfWork() {
            Users = new UserRepository(db);
            Topics = new TopicRepository(db);
            Courses = new CourseRepository(db);
        }

        public void Commit() {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}