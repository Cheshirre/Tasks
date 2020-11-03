using Api.Database.Entity;
using Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tasks
{
    public class TaskFactory : ITaskFactory
    {
        public Task Create(Dictionary<string, int> statuses)
        {
            return new Task
            {
                Guid = Guid.NewGuid(),
                StatusId = statuses["created"],
                TimeStamp = DateTime.Now
            };
        }
    }
}
