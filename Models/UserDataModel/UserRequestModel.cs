using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.UserDataModel
{
    public class UserRequestModel
    {
        public string userId { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userCRMDisplayName { get; set; }
        public string userSamAccountName { get; set; }
        public string userPassword { get; set; }
        public string userEmail { get; set; }
        public string type { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string superVisor { get; set; }
    }
}