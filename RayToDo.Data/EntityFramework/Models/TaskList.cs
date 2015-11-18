using RayToDo.Data.EntityFramework.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RayToDo.Data.EntityFramework.Models
{
    public class TaskList : AuditableEntity
    {
        private ICollection<User> invited;
        private ICollection<User> members;
        private ICollection<MemberRight> rights;
        private ICollection<Task> tasks;

        public TaskList()
        {
            this.invited = new HashSet<User>();
            this.members = new HashSet<User>();
            this.tasks = new HashSet<Task>();
            this.rights = new HashSet<MemberRight>();
        }

        public virtual User Creator { get; set; }

        public int CreatorId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<User> Invited
        {
            get { return this.invited; }
            set { this.invited = value; }
        }

        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<MemberRight> Rights
        {
            get { return this.rights; }
            set { this.rights = value; }
        }

        public virtual ICollection<Task> Tasks
        {
            get { return this.tasks; }
            set { this.tasks = value; }
        }

        [Required]
        public TaskListType Type { get; set; }
    }
}