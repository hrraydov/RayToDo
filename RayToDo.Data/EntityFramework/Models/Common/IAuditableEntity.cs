using System;

namespace RayToDo.Data.EntityFramework.Models.Common
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? UpdatedOn { get; set; }
    }
}