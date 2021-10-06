using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.BankDataModels
{
    public class BankCodesRequestModel
    {
        public int bankCodeId { get; set; }
        public string code { get; set; }
        public string companyCodes { get; set; }
        public string bankName { get; set; }
        public string subType { get; set; }
        public string bankremarks { get; set; }
        public string contactStatus { get; set; }
    }
}