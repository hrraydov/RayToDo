using AutoMapper;
using RayToDo.Api.RequestModels.TaskLists;
using RayToDo.Api.ResponseModels.TaskLists;
using RayToDo.Data.EntityFramework.Models;
using RayToDo.Services.Interfaces;
using System;
using System.Web.Http;

namespace RayToDo.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/task-lists")]
    public class TaskListsController : BaseApiController
    {
        private ITaskListService taskListService;

        public TaskListsController(ITaskListService taskListService)
        {
            this.taskListService = taskListService;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody]CreateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskList = new TaskList
            {
                CreatorId = CurrentUser.Id,
                Description = model.Description,
                Name = model.Name,
                Type = model.Type == "team" ? TaskListType.Team : TaskListType.Personal
            };

            taskListService.Add(taskList);

            return Created(Request.RequestUri, Mapper.Map<BaseTaskListResponseModel>(taskList));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var taskList = taskListService.GetById(id);
            if (taskList == null)
            {
                return NotFound();
            }
            if (taskList.Creator.Id != CurrentUser.Id)
            {
                return Ok(Mapper.Map<BaseTaskListResponseModel>(taskList));
            }

            return Ok(Mapper.Map<BaseTaskListResponseModel>(taskList));
        }

        [HttpPost]
        [Route("{id:int}/invite")]
        public IHttpActionResult Invite(int id, [FromBody]InviteRequestModel model)
        {
            var taskList = taskListService.GetById(id);
            if (taskList == null)
            {
                return NotFound();
            }
            try
            {
                taskListService.Invite(taskList, model.UserName);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception);
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/accept-invitation")]
        public IHttpActionResult AcceptInvitation(int id)
        {
            var taskList = taskListService.GetById(id);
            if (taskList == null)
            {
                return NotFound();
            }
            try
            {
                taskListService.AcceptInvitation(taskList, CurrentUser.UserName);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception);
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/decline-invitation")]
        public IHttpActionResult DeclineInvitation(int id)
        {
            var taskList = taskListService.GetById(id);
            if (taskList == null)
            {
                return NotFound();
            }
            try
            {
                taskListService.DeclineInvitation(taskList, CurrentUser.UserName);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception);
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/add-right")]
        public IHttpActionResult AddRight([FromUri]int id, [FromBody]AddRightRequestModel model)
        {
            var taskList = taskListService.GetById(id);
            if (taskList == null)
            {
                return NotFound();
            }
            try
            {
                taskListService.AddRight(taskList, model.UserName, model.Right);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception);
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/remove-right")]
        public IHttpActionResult RemoveRight([FromUri]int id, [FromBody]RemoveRightRequestModel model)
        {
            var taskList = taskListService.GetById(id);
            if (taskList == null)
            {
                return NotFound();
            }
            try
            {
                taskListService.RemoveRight(taskList, model.UserName, model.Right);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception);
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}