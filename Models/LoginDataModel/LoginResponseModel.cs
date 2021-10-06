using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.LoginDataModel
{
    public class LoginResponseModel
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string remarks { get; set; }
        public string resultCode { get; set; }
    }
}