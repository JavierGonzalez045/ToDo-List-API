using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Javier_API_Test.Models
{
    public class PostView
    {
        /*
         In this property we make a kind of view where the values of the name of the task 
         and its date of completion are entered, and the remaining values are being passed back.
         */
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }
}
