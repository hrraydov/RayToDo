using System.ComponentModel.DataAnnotations;

namespace RayToDo.Api.RequestModels.TaskLists
{
    public class CreateRequestModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}