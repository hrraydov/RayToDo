using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RayToDo.Data.EntityFramework.Models;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RayToDo.Api.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private User currentUser;

        public BaseApiController()
        {
            currentUser = null;
        }

        protected User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    var manager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    currentUser = manager.FindById<User, int>(User.Identity.GetUserId<int>());
                }

                return currentUser;
            }
        }
    }
}