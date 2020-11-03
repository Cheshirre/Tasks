using Api.Database.Entity;
using Api.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public interface ITaskFactory
    {
        Task Create(Dictionary<string, Status> statuses); 
    }
}
