using RayToDo.Services.Interfaces;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RayToDo.Api.Filters
{
    public class PopulateTaskListAttribute : ActionFilterAttribute
    {
        public ITaskListService TaskListService { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            var taskListId = (int)request.GetRequestContext().RouteData.Values["taskListId"];
            var taskList = TaskListService.GetById(taskListId);
            if (taskList == null)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                actionContext.ActionArguments.Add("taskList", taskList);
                base.OnActionExecuting(actionContext);
            }
        }
    }
}