using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult ManageAllocationsWithAccountsNo()
        {

            ViewBag.Message = "Assign Collectors To Customers Or Update The Assignment";
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
        public ActionResult ManageAllocationsWithCIF()
        {
            ViewBag.Message = "Assign Collectors To Customers Or Update The Assignment";
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

        public ActionResult ManageBanks()
        {
            ViewBag.Message = "Manage Banks";
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
        public ActionResult ManageAllocationsForDigitcom()
        {
            ViewBag.Message = "Manage Allocations For Digit Com";
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
        public ActionResult ManageAccountsWithdrawal()
        {
            ViewBag.Message = "Manage Accounts Withdrawal";
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
        public ActionResult ManagementIndex()
        {
            ViewBag.Message = "Management Of Accounts";
            ViewBag.Title = "Account Management Page";
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
        public ActionResult UserManagementIndex()
        {
            ViewBag.Message = "Management Of Users";
            ViewBag.Title = "User Management Page";
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