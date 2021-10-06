using NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers;
using NCRI_WEBPORTALFORMISC.Models.AllocationsDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCRI_WEBPORTALFORMISC.Controllers
{
    public class AllocationsController : Controller
    {
        //  Update Collector Allocations
        [HttpPost]
        [ActionName("UpdateCollectorAllocationsWithAccountnos")]
        public ActionResult UpdateCollectorAllocationsWithAccountnos(UpdateAllocationsRequestModel model )
        {
           
            var helper = new AllocationsHelpers();
            var response = helper.UpdateCollectorAllocationsWithAccountNo( model);
            return Json(response);

        }
        [HttpPost]
        [ActionName("UpdateCollectorAllocationsWithCIFS")]
        public ActionResult UpdateCollectorAllocationsWithCIFS(UpdateAllocationsRequestModel model )
        {
           
            var helper = new AllocationsHelpers();
            var response = helper.UpdateCollectorAllocationsWithCIF( model);
            return Json(response);

        }
        [HttpPost]
        [ActionName("UpdateAccountsAsWithdrawnWithAccountNo")]
        public ActionResult UpdateAccountsAsWithdrawnWithAccountNo(WithdrawAccountRequestModel model)
        {

            var helper = new AllocationsHelpers();
            var response = helper.UpdateAccountsAsWithdrawnWithAccountNo(model);
            return Json(response);

        }
        [HttpPost]
        [ActionName("GetAllocations")]
        public ActionResult GetAllocations(AllocationsRequestModel model)
        {

            AllocationsHelpers helper = new AllocationsHelpers();
            var response = Json(helper.GetAllocations(model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("GetActiveAllocations")]
        public ActionResult GetActiveAllocations(AllocationsRequestModel model)
        {

            AllocationsHelpers helper = new AllocationsHelpers();
            var response = Json(helper.GetActiveAllocations(model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        } 
        [HttpPost]
        [ActionName("GetActiveAllocationsWithRespectOfBank")]
        public ActionResult GetActiveAllocationsWithRespectOfBank(AllocationsRequestModel model)
        {

            AllocationsHelpers helper = new AllocationsHelpers();
            var response = Json(helper.GetActiveAllocationsWithRespectOfBank(model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("GetNewAllocationsFromGivenData")]
        public ActionResult GetNewAllocationsFromGivenData(AllocationsRequestModel model)
        {

            AllocationsHelpers helper = new AllocationsHelpers();
            var response = Json(helper.SortAllocationsOnBasisOfNew(model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("GetOldAllocationsFromGivenData")]
        public ActionResult GetOldAllocationsFromGivenData(AllocationsRequestModel model)
        {

            AllocationsHelpers helper = new AllocationsHelpers();
            var response = Json(helper.SortAllocationsOnBasisOfOld(model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("GetDupliacteCaseIdsAllocationsFromBankName")]
        public ActionResult GetDupliacteCaseIdsAllocationsFromBankName(AllocationsRequestModel model)
        {

            AllocationsHelpers helper = new AllocationsHelpers();
            var response = Json(helper.GetDupliacteCaseIdsAllocationsFromBankName(model));
            response.MaxJsonLength = int.MaxValue;
            return response;
        }
        [HttpPost]
        [ActionName("UpdateAccountByAccountId")]
        public ActionResult UpdateAccountByAccountId(UpdateAccountRequestModel model)
        {

            var helper = new AllocationsHelpers();
            var response = helper.UpdateAccountWithId(model);
            return Json(response);

        }

    }
}