using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RayToDo.Api.RequestModels.TaskLists
{
    public class RemoveRightRequestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Right { get; set; }
    }
}