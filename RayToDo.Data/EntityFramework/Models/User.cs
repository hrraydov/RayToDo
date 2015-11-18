using Microsoft.AspNet.Identity;
using RayToDo.Data.EntityFramework.Models.Common;
using System.Collections.Generic;

namespace RayToDo.Data.EntityFramework.Models
{
    public class User : BaseEntity, IUser<int>
    {
        private ICollection<UserLogin> logins;
        private ICollection<MemberRight> rights;
        private ICollection<TaskList> taskLists;
        private ICollection<TaskList> invitedFor;
        private ICollection<TaskList> memberOf;
        private ICollection<Task> workingOn;

        public User()
        {
            taskLists = new HashSet<TaskList>();
            invitedFor = new HashSet<TaskList>();
            memberOf = new HashSet<TaskList>();
            rights = new HashSet<MemberRight>();
            logins = new HashSet<UserLogin>();
            workingOn = new HashSet<Task>();
        }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public virtual ICollection<UserLogin> Logins
        {
            get
            {
                return logins;
            }
            set
            {
                logins = value;
            }
        }

        public string PasswordHash { get; set; }

        public virtual ICollection<MemberRight> Rights
        {
            get { return rights; }
            set { rights = value; }
        }

        public string SecurityStamp { get; set; }

        public virtual ICollection<TaskList> TaskLists
        {
            get { return taskLists; }
            set { taskLists = value; }
        }

        public virtual ICollection<TaskList> InvitedFor
        {
            get { return invitedFor; }
            set { invitedFor = value; }
        }

        public virtual ICollection<TaskList> MemberOf
        {
            get { return memberOf; }
            set { memberOf = value; }
        }

        public virtual ICollection<Task> WorkingOn
        {
            get { return workingOn; }
            set { workingOn = value; }
        }

        public string UserName { get; set; }
    }
}