using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Api.Database.Entity;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly ITaskFactory _factory;
        readonly IRepository _repository;
        public TaskController(ITaskFactory factory, IRepository repository)
        {
            _factory = factory;
            _repository = repository;
        }

        // GET <TaskController>/5
        [HttpGet("{id}")]
        public TaskModel Get(Guid id)
        {
            var task = _repository.Get(id);

            if (task == null)
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            
            return new TaskModel
            {
                Status = task.Status.Name,
                Timestamp = task.TimeStamp.ToString("o", CultureInfo.InvariantCulture)
            };
        }

        // POST <TaskController>
        [HttpPost]
        public object Post()
        {
            var statuses = _repository.GetStatuses().ToDictionary(x => x.Name, x => x.Id);
            var task = _factory.Create(statuses);
            _repository.Create(task);

            _repository.UpdateStatus(task.Guid, statuses["running"]);


            var background = System.Threading.Tasks.Task.Run(() =>
            {
                BackgroundWork(task.Guid, statuses);
            });

            Response.StatusCode = 202;

            return new {
                Guid = task.Guid
            };
        }

        private void BackgroundWork(Guid id, Dictionary<string, int> statuses)
        {
            _repository.UpdateStatus(id, statuses["running"]);
            Thread.Sleep(120000);
            _repository.UpdateStatus(id, statuses["finished"]);
        }
    }
}
