using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class NewOnboardEnrollmentController : Controller
    {
        // GET: NewOnboardEnrollment
        public ActionResult OnBoardIndex()
        {
            ViewBag.Message = "Welcome To OnBoard Enrollment Form";
            ViewBag.Title = "OnBoard Enrollment Form";
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
    }
}