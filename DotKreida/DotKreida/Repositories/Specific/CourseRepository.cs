using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DotKreida.Contracts.Repositories.Specific;
using DotKreida.Models;
using RefactorThis.GraphDiff;

namespace DotKreida.Repositories.Specific {
    public class CourseRepository : ICourseRepository {
        private readonly SqlServerContext db;

        public CourseRepository(SqlServerContext db) =>
            this.db = db;

        public void Add(Course entity) {
            db.Entry(entity.User).State = EntityState.Unchanged;
            db.Entry(entity.Topic).State = EntityState.Unchanged;

            db.Courses.Add(entity);
        }

        public IEnumerable<Course> GetAll() =>
            db.Courses.AsNoTracking().ToList();

        public Course GetById(int id) =>
            db.Courses.AsNoTracking().SingleOrDefault(x => x.Id == id);

        public void Update(Course entity) =>
            db.UpdateGraph(entity, map => map.OwnedCollection(x => x.Lessons)
                .OwnedCollection(x => x.Tests, with => with.OwnedCollection(y => y.Questions))
                .OwnedEntity(x => x.User).OwnedEntity(x => x.Topic));

        public void Remove(Course entity) =>
            db.Courses.Remove(db.Courses.Find(entity.Id));
    }
}