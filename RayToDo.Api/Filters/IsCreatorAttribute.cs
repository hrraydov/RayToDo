using Microsoft.AspNet.Identity;
using RayToDo.Api.Infrastructure;
using RayToDo.Services.Interfaces;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RayToDo.Api.Filters
{
    public class IsCreatorAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            var taskListId = int.Parse(request.GetRouteData().Values["id"].ToString());
            var taskListService = ObjectFactory.Get<ITaskListService>();
            var taskList = taskListService.GetById(taskListId);
            if (taskList.CreatorId != request.GetRequestContext().Principal.Identity.GetUserId<int>())
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}