using NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class DropDownController : Controller
    {
        #region Methods
        
        [HttpPost]
        [ActionName("CollectorsDropDown")]
        public ActionResult CollectorsDropDown()
        {

         
            var helper = new DropDownHelpers();
            var response = helper.GetAllFieldUsers();
            return Json(response);

        }
        [HttpPost]
        [ActionName("BanksDropDown")]
        public ActionResult BanksDropDown()
        {

            DropDownHelpers helper = new DropDownHelpers();
            var response = Json(helper.GetUniqueBankCodes());
            response.MaxJsonLength = int.MaxValue;
            return response;
        }

        #endregion
    }
}