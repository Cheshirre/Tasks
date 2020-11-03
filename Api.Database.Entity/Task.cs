using System;
using System.Collections.Generic;

namespace Api.Database.Entity
{
    public class Task
    {
        public int StatusId { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid Guid { get; set; }
        public virtual Status Status { get; set; }
    }
}
