using RayToDo.Api.Filters;
using RayToDo.Data.EntityFramework.Models;
using RayToDo.Services.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace RayToDo.Api.Controllers
{
    [RoutePrefix("api/task-list/{taskListId:int}/tasks")]
    [PopulateTaskList]
    public class TasksController : BaseApiController
    {
        TaskList taskList;
        private ITaskListService taskListService;
        private ITaskService taskService;

        public TasksController(ITaskListService taskListService, ITaskService taskService)
        {
            this.taskListService = taskListService;
            this.taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        [CheckRight(Right = "see-tasks")]
        public IHttpActionResult GetAll()
        {

        }
    }
}