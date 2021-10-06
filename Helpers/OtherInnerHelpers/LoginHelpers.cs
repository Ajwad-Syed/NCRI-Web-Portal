using NCRI_WEBPORTALFORMISC.Models.LoginDataModel;
using System;
using NCRI_WEBPORTALFORMISC.Models.DBMODEL;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.DirectoryServices;

namespace NCRI_WEBPORTALFORMISC.Helpers.OtherInnerHelpers
{
    public class LoginHelpers
    {
        public LoginResponseModel LoginUser (LoginRequestModel model)
        {
            LoginResponseModel toReturn = new LoginResponseModel();
            try
            {
                using (db_it_departmentEntities db = new db_it_departmentEntities())
                {
                    using (var context = new PrincipalContext(ContextType.Domain, "ncri", "Administrator", "Sep@2020!"))
                    {
                        var test = context.ValidateCredentials(model.UserName, model.Password);
                        if (test == true)
                        {                           
                            var user = db.tbl_users.Where(x => x.username == (model.UserName)).FirstOrDefault();
                            if (user != null)
                            {
                                toReturn = new LoginResponseModel()
                                {
                                    DisplayName= user.name,
                                    UserName = user.username,
                                    remarks = "User Found In DB",
                                    resultCode = "1100"
                                };
                            }
                            else
                            {
                                toReturn = new LoginResponseModel()
                                {
                                    remarks = "User Not Found In DB",
                                    resultCode = "1200"
                                };
                            }

                        }
                        else
                        {
                            toReturn = new LoginResponseModel()
                            {
                                remarks = "Wrong Credentials",
                                resultCode = "1500"
                            };
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                toReturn = new LoginResponseModel()
                {
                    remarks = "CHECK LDAP "+ Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
    }
}