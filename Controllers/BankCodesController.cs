using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers;
using NCRI_WEBPORTALFORMISC.Models.BankDataModels;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class BankCodesController : Controller
    {
        #region Views
        // GET: BankCodes
        public ActionResult Index()
        {
            return View();
            //if (Session["Name"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return Redirect("/Login/LoginIndex");
            //}
        }
        #endregion
        #region Methods
        [HttpPost]
        [ActionName("GetBankCodes")]
        public ActionResult GetBankCodes()
        {

            BankHelpers helper = new BankHelpers();
            var response = Json(helper.GetAllBankCodes());
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("AddNewBankCode")]
        public ActionResult AddNewBankCode(BankCodesRequestModel model)
        {

            BankHelpers helper = new BankHelpers();
            var response = Json(helper.AddNewBankCode( model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("UpdateBankCode")]
        public ActionResult UpdateBankCode(BankCodesRequestModel model)
        {

            BankHelpers helper = new BankHelpers();
            var response = Json(helper.UpdateBankCode( model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("DeleteBankCode")]
        public ActionResult DeleteBankCode(BankCodesRequestModel model)
        {

            BankHelpers helper = new BankHelpers();
            var response = Json(helper.DeleteBankCode(model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        #endregion
    }
}