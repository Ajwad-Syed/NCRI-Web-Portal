using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.BankDataModels
{
    public class BankResponseModel
    {
        public string bankName { get; set; }
        public string remarks { get; set; }
        public string resultCode { get; set; }
    }
}