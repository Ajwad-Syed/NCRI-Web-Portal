using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //if (Session["Name"] != null)
            //{
            //    ViewBag.Message = "Welcome "+ Session["DisplayName"].ToString()+" to NCRI IT Page For Pakistan";
            //    ViewBag.Title = "NCRI - Pakistan";

            //    return View();
            //}
            //else
            //{
            //    return Redirect("/Login/LoginIndex");
            //}
           
        }

       
    }
}
