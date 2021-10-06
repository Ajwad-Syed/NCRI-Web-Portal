using NCRI_WEBPORTALFORMISC.Helpers.OtherInnerHelpers;
using NCRI_WEBPORTALFORMISC.Models.LoginDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class LoginController : Controller
    {
        #region views
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }
        #endregion
        #region Methods
        [HttpPost]
        [ActionName("LoginUser")]
        public ActionResult LoginUser(LoginRequestModel model)
        {
            var helper = new LoginHelpers();
            var user = helper.LoginUser(model);
            if (user.resultCode == "1100")
            {
                Session["Name"] = user.UserName;
                Session["DisplayName"] = user.DisplayName;
            }
            var response = Json(user);
            response.MaxJsonLength = int.MaxValue;            
            return response;
        }
        #endregion
    }
}