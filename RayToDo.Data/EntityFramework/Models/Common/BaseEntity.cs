using System.ComponentModel.DataAnnotations;

namespace RayToDo.Data.EntityFramework.Models.Common
{
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}