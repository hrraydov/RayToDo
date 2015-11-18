using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RayToDo.Api.ResponseModels.Account
{
    public class ManageInfoResponseModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoResponseModel> Logins { get; set; }

        public IEnumerable<ExternalLoginResponseModel> ExternalLoginProviders { get; set; }
    }
}