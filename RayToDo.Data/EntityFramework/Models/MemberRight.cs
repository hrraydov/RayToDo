using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RayToDo.Data.EntityFramework.Models
{
    public class MemberRight
    {
        public virtual User Member { get; set; }

        [Key, Column(Order = 0)]
        public int MemberId { get; set; }

        public string Right { get; set; }

        public virtual TaskList TaskList { get; set; }

        [Key, Column(Order = 1)]
        public int TaskListId { get; set; }
    }
}