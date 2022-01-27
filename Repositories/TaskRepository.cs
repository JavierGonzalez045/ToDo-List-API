using Javier_API_Test.Models;
using Javier_API_Test.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Here a repository is being created in which the different methods created in the TaskControllers class are implemented
namespace Javier_API_Test.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        //Implementation of Post Method
        public async Task<Tasks> Post(PostView task)
        {
            Tasks todo = new Tasks { Title = task.Title, DueDate = task.DueDate, CreatedDate = DateTime.Now, Status = 0, Id = new Guid() };
            

            _context.Tasks.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        //Implementation of Get Method
        public async Task<IEnumerable<Tasks>> Get()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetById(Guid filter)
        {
            return await _context.Tasks.FindAsync(filter);
        }


        //Implementation of Patch Method
        public async Task UpdateStatusPatchAsync(Guid id, ViewStatus updateStatus)
        {
            var status = await _context.Tasks.FindAsync(id);
            if (status != null)
            {

                status.Status = updateStatus.Status;
                await _context.SaveChangesAsync();
            }
        }

    } 
}
