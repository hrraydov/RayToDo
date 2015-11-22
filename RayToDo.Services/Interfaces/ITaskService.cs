using RayToDo.Data.EntityFramework.Models;
using System.Collections.Generic;

namespace RayToDo.Services.Interfaces
{
    public interface ITaskService : IDataService<Task>
    {
        IEnumerable<Task> GetByTaskListId(int taskListId);
    }
}