using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RayToDo.Api.ResponseModels.Account
{
    public class UserLoginInfoResponseModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}