using Autofac;
using Autofac.Integration.Mvc;
using DotKreida.Contracts.Repositories;
using DotKreida.Models;
using DotKreida.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotKreida.Controllers.Api
{
    public class TopicsApiController : ApiController
    {
        IUnitOfWork unitOfWork;

        public TopicsApiController()
        {
            unitOfWork = AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IUnitOfWork>();
        }

        [HttpGet]
        [Route("api/topics/")]
        public IEnumerable<Topic> GetTopics()
        {
            return unitOfWork.Topics.GetAll();
        }

        [HttpGet]
        [Route("api/topics/{id}")]
        public Topic GetTopic(int id)
        {
            return unitOfWork.Topics.GetById(id);
        }

        [HttpPost]
        [Route("api/topics")]
        public void AddTopic([FromBody]Topic topic)
        {
            unitOfWork.Topics.Add(topic);
            unitOfWork.Commit();
        }

        [HttpPut]
        [Route("api/topics/{id}")]
        public void UpdateTopic(int id, [FromBody]Topic topic)
        {
            var topicFromDB = unitOfWork.Topics.GetById(id);
            topicFromDB = topic;
            unitOfWork.Topics.Update(topicFromDB);
            unitOfWork.Commit();
        }

        [HttpDelete]
        [Route("api/topics/{id}")]
        public void DeleteTopic(int id)
        {
            var topic = unitOfWork.Topics.GetById(id);
            unitOfWork.Topics.Remove(topic);
            unitOfWork.Commit();
        }
    }
}
