using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DotKreida.Contracts.Repositories.Specific;
using DotKreida.Models;
using RefactorThis.GraphDiff;

namespace DotKreida.Repositories.Specific {
    public class TopicRepository : ITopicRepository {
        private readonly SqlServerContext db;

        public TopicRepository(SqlServerContext db) =>
            this.db = db;

        public void Add(Topic entity) =>
            db.Topics.Add(entity);

        public IEnumerable<Topic> GetAll() =>
            db.Topics.AsNoTracking().ToList();

        public Topic GetById(int id) =>
            db.Topics.AsNoTracking().SingleOrDefault(x => x.Id == id);

        public void Update(Topic entity) =>
            db.UpdateGraph(entity, map => map.OwnedCollection(x => x.Courses, with => with
                .OwnedCollection(y => y.Lessons).OwnedCollection(y => y.Tests, with2 => with2
                .OwnedCollection(z => z.Questions)).OwnedEntity(y => y.User)));

        public void Remove(Topic topic) =>
            db.Topics.Remove(db.Topics.Find(topic.Id));
    }
}