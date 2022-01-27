using Javier_API_Test.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//
namespace Javier_API_Test.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tasks>> Get();
        Task<Tasks> Post(PostView task);
        Task<Tasks> GetById(Guid id);
        Task UpdateStatusPatchAsync(Guid id, ViewStatus updateStatus);
    }
}
