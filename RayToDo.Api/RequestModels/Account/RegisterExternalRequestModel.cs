using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RayToDo.Api.RequestModels.Account
{
    public class RegisterExternalRequestModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
    }
}