using RayToDo.Api.Infrastructure.Mapping;
using RayToDo.Data.EntityFramework.Models;

namespace RayToDo.Api.ResponseModels.Account
{
    public class BaseUserResponseModel : IMapFrom<User>
    {
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}