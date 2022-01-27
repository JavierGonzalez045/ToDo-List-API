using Javier_API_Test.Models;
using Javier_API_Test.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Here the route controllers are being created
namespace Javier_API_Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //GET METHOD
        [HttpGet]
        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            return await _taskRepository.Get();
        }

        //GET BY ID METHOD
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        //POST METHOD
        [HttpPost]
        public async Task<ActionResult<Tasks>> Post([FromBody] PostView task)
        {
            var newTask = await _taskRepository.Post(task);
          //  return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
            return Ok(newTask);
        }

        //PATCH METHOD
        [HttpPatch("{id}")]//Repare Patch, do the patch without the JsonPatchDocument
        public async Task<IActionResult> UpdateStatusPatch([FromBody] ViewStatus updateStatus, [FromRoute] Guid id)
        {
            await _taskRepository.UpdateStatusPatchAsync(id, updateStatus);
            return Ok();
        }
    }
}

