using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.CommunicationDataModels
{
    public class CommunicationRequestModel
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}