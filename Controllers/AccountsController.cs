using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult AccountsIndex()
        {
            return View();
            //if (Session["Name"] != null)
            //{
            //    ViewBag.Message = "Welcome To Accounts Info Page";
            //    ViewBag.Title = "AMDC Accounts";
            //    return View();
            //}
            //else
            //{
            //    return Redirect("/Login/LoginIndex");
            //}
         
        }
        public ActionResult BackToBankAccounts()
        {
            ViewBag.Message = "Welcome To Back To Bank Accounts Page";
            ViewBag.Title = "Back To Bank Accounts";
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
        public ActionResult SortAccounts()
        {
            ViewBag.Message = "Welcome To Sorting Page For Accounts ";
            ViewBag.Title = "Accounts Sorting Page";
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
        public ActionResult DuplicateCaseIDsAccounts()
        {
            ViewBag.Message = "Welcome To Duplicate Case IDs Accounts Page For Accounts ";
            ViewBag.Title = "Duplicate Case IDs Page";
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
        public ActionResult OnTheBasisOfOutstanding()
        {
            ViewBag.Message = "Welcome Active Accounts Page";
            ViewBag.Title = "Active Accounts Page";
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