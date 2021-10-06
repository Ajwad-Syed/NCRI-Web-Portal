using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.AllocationsDataModels
{
    public class AllocationsResponseModel
    {
        public string id { get; set; }
        public string caseId { get; set; }
        public string CustomerName { get; set; }
        public string AccountNo { get; set; }
        public string CIF { get; set; }
        public string CollectorName { get; set; }
        public string AccountStatus { get; set; }
        public string Outstandings { get; set; }
        public string remarks { get; set; }
        public string resultCode { get; set; }
    }
}