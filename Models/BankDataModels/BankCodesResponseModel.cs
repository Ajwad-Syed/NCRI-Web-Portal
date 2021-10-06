using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.BankDataModels
{
    public class BankCodesResponseModel
    {
        public string bankCodeId { get; set; }
        public string code { get; set; }
        public string companyCodes { get; set; }
        public string bankName { get; set; }
        public string subType { get; set; }
        public string bankremarks { get; set; }
        public string contactStatus { get; set; }
        public string remarks { get; set; }
        public string resultCode { get; set; }
    }
}