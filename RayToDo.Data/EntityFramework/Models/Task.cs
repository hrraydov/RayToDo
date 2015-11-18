using RayToDo.Data.EntityFramework.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace RayToDo.Data.EntityFramework.Models
{
    public class Task : AuditableEntity
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int TaskListId { get; set; }

        public virtual TaskList TaskList { get; set; }

        public int? WorkingOnId { get; set; }

        public virtual User WorkingOn { get; set; }
    }
}