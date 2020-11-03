using Api.Database.Entity;
using System;
using System.Collections.Generic;

namespace Api.Repository
{
    public interface IRepository
    {
        Guid Create(Task task);
        Task Get(Guid id);
        IEnumerable<Status> GetStatuses();
        bool UpdateStatus(Guid id, int statusId);
    }
}
