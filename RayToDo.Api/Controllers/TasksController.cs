using RayToDo.Api.RequestModels.Tasks;
using RayToDo.Data.EntityFramework.Models;
using RayToDo.Services.Interfaces;
using System.Web.Http;

namespace RayToDo.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/tasks")]
    public class TasksController : BaseApiController
    {
        private ITaskListService taskListService;
        private ITaskService taskService;

        public TasksController(ITaskListService taskListService, ITaskService taskService)
        {
            this.taskListService = taskListService;
            this.taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetByTaskList(int taskListId)
        {
            var taskList = taskListService.GetById(taskListId);
            if (!taskListService.CheckRight(taskList, CurrentUser.UserName, "see-tasks"))
            {
                return Unauthorized();
            }
            var tasks = taskService.GetByTaskListId(taskList.Id);
            return Ok(tasks);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody]CreateRequestModel model)
        {
            var taskList = taskListService.GetById(model.TaskListId);
            if (!taskListService.CheckRight(taskList, CurrentUser.UserName, "create-tasks"))
            {
                return Unauthorized();
            }
            Priority priority = Priority.Normal;
            switch (model.Priority)
            {
                case "High": priority = Priority.High; break;
                case "Low": priority = Priority.Low; break;
                case "Normal": priority = Priority.Normal; break;
            }
            var task = new Task
            {
                Description = model.Description,
                EndDateTime = model.EndDateTime,
                Priority = priority,
                Title = model.Title,
                TaskListId = model.TaskListId
            };
            taskService.Add(task);
            return Created(Request.RequestUri, task);
        }
    }
}