using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RayToDo.Api.RequestModels.Tasks
{
    public class CreateRequestModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public DateTime? EndDateTime { get; set; }

        [Required]
        public int TaskListId { get; set; }
    }
}