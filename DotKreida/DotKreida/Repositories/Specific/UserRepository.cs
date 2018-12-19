using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DotKreida.Contracts.Repositories.Specific;
using DotKreida.Models;
using RefactorThis.GraphDiff;


namespace DotKreida.Repositories.Specific {
    public class UserRepository : IUserRepository {
        private readonly SqlServerContext db;

        public UserRepository(SqlServerContext db) =>
            this.db = db;

        public void Add(User entity) =>
            db.Users.Add(entity);

        public IEnumerable<User> GetAll() =>
            db.Users.AsNoTracking().ToList();

        public User GetById(int id) =>
            db.Users.AsNoTracking().SingleOrDefault(x => x.Id == id);

        public void Update(User entity) =>
            db.UpdateGraph(entity, map => map.OwnedCollection(x => x.Courses, with => with
                .OwnedCollection(y => y.Lessons).OwnedCollection(y => y.Tests, with2 => with2.OwnedCollection(z => z.Questions))
                .OwnedEntity(y => y.Topic)));

        public void Remove(User entity) =>
            db.Users.Remove(db.Users.Find(entity.Id));
    }
}