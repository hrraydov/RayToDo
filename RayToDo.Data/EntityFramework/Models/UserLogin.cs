using RayToDo.Data.EntityFramework.Models.Common;

namespace RayToDo.Data.EntityFramework.Models
{
    public class UserLogin : BaseEntity
    {
        public string Provider { get; set; }

        public string ProviderKey { get; set; }

        public int UserId { get; set; }
    }
}