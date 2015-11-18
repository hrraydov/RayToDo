using Microsoft.AspNet.Identity;
using RayToDo.Data.EntityFramework.Models;
using RayToDo.Services.Interfaces;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RayToDo.Api.Filters
{
    public class CheckRightAttribute : ActionFilterAttribute
    {
        public ITaskListService TaskListService { get; set; }
        public string Right { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            var taskList = request.GetRequestContext().RouteData.Values["taskList"] as TaskList;
            var userName = request.GetRequestContext().Principal.Identity.GetUserName();

            if (TaskListService.CheckRight(taskList, userName, Right))
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}