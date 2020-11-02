using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLibrary
{
    public enum Status {
        Created,
        Running,
        Finishing
    }

    public class Task
    {
        public Status Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid Guid { get; set; }
    }
}
