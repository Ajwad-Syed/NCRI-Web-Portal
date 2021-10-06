using NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers;
using NCRI_WEBPORTALFORMISC.Models.UserDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
   
        public class UserController : Controller
        {
            [HttpPost]
            [ActionName("GetAllUsers")]
            public ActionResult GetAllUsers()
            {

                UserManagementHelpers helper = new UserManagementHelpers();
                var response = Json(helper.GetAllUsersList());
                response.MaxJsonLength = int.MaxValue;
                return response;
            }
            [HttpPost]
            [ActionName("AddUser")]
            public ActionResult AddUser(UserRequestModel model)
            {

                UserManagementHelpers helper = new UserManagementHelpers();
                var response = Json(helper.AddNewUser(model));
                response.MaxJsonLength = int.MaxValue;
                return response;
            }
            [HttpPost]
            [ActionName("UpdateUser")]
            public ActionResult UpdateUser(UserRequestModel model)
            {

                UserManagementHelpers helper = new UserManagementHelpers();
                var response = Json(helper.UpdateUser(model));
                response.MaxJsonLength = int.MaxValue;
                return response;
            }
            [HttpPost]
            [ActionName("DeleteUser")]
            public ActionResult DeleteUser(UserRequestModel model)
            {

                UserManagementHelpers helper = new UserManagementHelpers();
                var response = Json(helper.DeleteUser(model));
                response.MaxJsonLength = int.MaxValue;
                return response;
            }
        }
    
}