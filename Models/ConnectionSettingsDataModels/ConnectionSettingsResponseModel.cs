using FluentEmail.MailKitSmtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.ConnectionSettingsDataModels
{
    public class ConnectionSettingsResponseModel
    {
        public SmtpClientOptions options { get; set; }
    }
}