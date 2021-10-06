using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.AllocationsDataModels
{
    public class AllocationsRequestModel
    {
        public string CollectorName { get; set; }
        public string AccountNo { get; set; }
        public string CIF { get; set; }
        public string BankName { get; set; }
        public string Outstanding { get; set; }
        public string Operation { get; set; }
        public string LastUpdateDate { get; set; }
    }
}