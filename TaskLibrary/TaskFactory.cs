using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLibrary
{
    public class TaskFactory : ITaskFactory
    {
        public Task Create()
        {
            try
            {
                return new Task {
                    Guid = Guid.NewGuid(),
                    Status = Status.Created,
                    TimeStamp = DateTime.Now
                };
            }
            catch (Exception)
            {
                //....
                throw;
            }
        }
    }
}
