using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCRI_WEBPORTALFORMISC.Helpers.OtherInnerHelpers;
using NCRI_WEBPORTALFORMISC.Models.AllocationsDataModels;
using NCRI_WEBPORTALFORMISC.Models.CommunicationDataModels;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class CommunicationsController : Controller
    {
        #region Views
        public ActionResult CommunicationsIndex()
        {
            ViewBag.Message = "Welcome To Communitcation Page";
            ViewBag.Title = "Communitcation Page";
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
        public ActionResult SendEmail()
        {
            ViewBag.Message = "Welcome To Email Sending Page";
            ViewBag.Title = "Email Sending Page";
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
        [ActionName("SendSms")]
        public ActionResult SendSms(AllocationsResponseModel model)
        {
            var helper = new InnerHelpers();
            var response = Json(helper.SendSMSThroughJazzApi(model.id));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("SendEmail")]
        public ActionResult SendEmail(AllocationsResponseModel model)
        {
            var helper = new InnerHelpers();
            var response = Json(helper.SendEmail(model.id));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("SendCustomEmail")]
        public ActionResult SendCustomEmail(CommunicationRequestModel model)
        {
            var helper = new InnerHelpers();
            var response = Json(helper.SendEmail(model.body, model.subject, model.to));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        #endregion
    }
}