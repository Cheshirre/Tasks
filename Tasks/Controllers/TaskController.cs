using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            if (task != null)
                return new TaskModel
                {
                    Status = task.Status.Name,
                    Timestamp = task.TimeStamp.ToString("o", CultureInfo.InvariantCulture)
                };
            else
            {
                Response.StatusCode = 404;

                return new TaskModel();
            }
        }

        // POST <TaskController>
        [HttpPost]
        public object Post()
        {
            var statuses = _repository.GetStatuses().ToDictionary(x => x.Name);
            var task = _factory.Create(statuses);
            _repository.Create(task);

            //Task background = Task.Run(() => { });

            return new {
                Guid = task.Guid
            };
        }
    }
}
