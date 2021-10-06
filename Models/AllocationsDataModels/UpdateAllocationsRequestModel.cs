using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.AllocationsDataModels
{
    public class UpdateAllocationsRequestModel
    {
        public string AccountNos { get; set; }
        public string CollectorName { get; set; }
        public string CIFS { get; set; }
    }
}