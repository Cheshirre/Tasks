using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLibrary
{
    public interface ITaskFactory
    {
        Task Create(); 
    }
}
