using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Javier_API_Test.Models;


namespace Javier_API_Test.Models
{
    //Here we are declaring the properties of the task that they request us.

    public class Tasks
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
        public Guid Id { get; set;}
    }

    public enum Status
    {
        Pending = 0,
        Canceled = 1,
        Completed = 2
        
    }
}


