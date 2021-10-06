using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.AllocationsDataModels
{
    public class UpdateAccountRequestModel
    {
        public string id { get; set; }
        public string customerName { get; set; }
        public string caseId { get; set; }
    }
}