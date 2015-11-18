using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RayToDo.Api.ResponseModels.Account
{
    public class UserInfoResponseModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}