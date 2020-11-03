using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
