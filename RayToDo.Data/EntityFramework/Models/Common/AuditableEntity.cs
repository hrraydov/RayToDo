using System;

namespace RayToDo.Data.EntityFramework.Models.Common
{
    public class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}