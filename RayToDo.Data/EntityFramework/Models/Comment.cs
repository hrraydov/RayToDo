using RayToDo.Data.EntityFramework.Models.Common;

namespace RayToDo.Data.EntityFramework.Models
{
    public class Comment : AuditableEntity
    {
        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}