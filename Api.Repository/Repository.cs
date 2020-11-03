using Api.Database.Entity;
using Api.Database.MSSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Api.Repository
{
    public class Repository : IRepository
    {
        private readonly TargetDbContext _context;
        public Repository(TargetDbContext context)
        {
            _context = context;
        }

        public Guid Create(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task.Guid;
        }

        public Task Get(Guid id)
        {
            return _context.Tasks.Include(x => x.Status).FirstOrDefault(x => x.Guid == id);
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _context.Status;
        }
    }
}
