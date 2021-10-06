using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Helpers.OtherInnerHelpers
{
    public class LADPHelpers
    {
        public DirectorySearcher BuildSingleUserSearcher(DirectoryEntry de, string userName)
        {
            DirectorySearcher ds = null;

            ds = new DirectorySearcher(de);

            ds.Filter = "(&(objectCategory=User)(objectClass=person)(samaccountname=" + userName + "*))";
            // Full Name
            ds.PropertiesToLoad.Add("name");

            // Email Address
            ds.PropertiesToLoad.Add("mail");

            // First Name
            ds.PropertiesToLoad.Add("displayname");

            // Last Name (Surname)
            ds.PropertiesToLoad.Add("sn");

            // Login Name
            ds.PropertiesToLoad.Add("userPrincipalName");

            // Distinguished Name
            ds.PropertiesToLoad.Add("distinguishedName");
            ds.PropertiesToLoad.Add("samaccountname");


            return ds;
        }
        public string GetCurrentDomainPath()
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");

            return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
        }
    }
}