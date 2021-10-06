using FluentEmail.MailKitSmtp;
using NCRI_WEBPORTALFORMISC.Models.ConnectionSettingsDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Helpers.OtherInnerHelpers
{
    public class ConnectionSettings
    {
        public ConnectionSettingsResponseModel GetSettings()
        {
            ConnectionSettingsResponseModel toReturn = new ConnectionSettingsResponseModel();
            var smtpClientOptions = new SmtpClientOptions
            {
                Server = "smtpout.secureserver.net",
                Port = 465,
                UseSsl = true,
                RequiresAuthentication = true,
                User = "itasia@ncrigroups.com",
                Password = "Forn0tfication"
            };
            toReturn.options = smtpClientOptions;
            return toReturn;
        }
    }
}