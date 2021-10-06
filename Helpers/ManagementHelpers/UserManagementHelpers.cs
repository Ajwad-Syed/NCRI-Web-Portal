using NCRI_WEBPORTALFORMISC.Helpers.OtherInnerHelpers;
using NCRI_WEBPORTALFORMISC.Models.DBMODEL;
using NCRI_WEBPORTALFORMISC.Models.UserDataModel;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers
{
    public class UserManagementHelpers
    {
        public List<UserResponseModel> GetAllUsersList()
        {
            List<UserResponseModel> toReturn = new List<UserResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var users = db.Users.ToList();
                    if (users.Count() > 0)
                    {
                        toReturn = users.Select(x => new UserResponseModel()
                        {
                            phone = !string.IsNullOrEmpty(x.phone) ? x.phone : "",
                            status = !string.IsNullOrEmpty(x.status) ? x.status : "",
                            superVisor = !string.IsNullOrEmpty(x.Supervisor) ? x.Supervisor : "",
                            userEmail = !string.IsNullOrEmpty(x.email) ? x.email : "",
                            userId = x.id.ToString(),
                            userFirstName = !string.IsNullOrEmpty(x.name) ? x.name : "",
                            userPassword = !string.IsNullOrEmpty(x.password) ? x.password : "",
                            userCRMDisplayName = !string.IsNullOrEmpty(x.username) ? x.username : "",
                            type = x.type != null ? x.type.ToString() : "",
                            remarks = "Success",
                            resultCode = "1100"

                        }).ToList();
                    }
                    else
                    {
                        toReturn = new List<UserResponseModel>();
                        toReturn.Add(new UserResponseModel
                        {
                            remarks = "No Record",
                            resultCode = "1200"
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<UserResponseModel>();
                toReturn.Add(new UserResponseModel()
                {
                    remarks = "There was a Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
        public UserResponseModel AddNewUser(UserRequestModel model)
        {
            UserResponseModel toReturn = new UserResponseModel();
            try
            {
                using (var principalContext = new PrincipalContext(ContextType.Domain, "amdc", "musa.shabeer.ae", "Changeme@123"))
                {
                    UserPrincipal ldapUser = UserPrincipal.FindByIdentity(principalContext, model.userSamAccountName);
                    if (ldapUser == null)
                    {
                        UserPrincipal userPrincipal = new UserPrincipal(principalContext);

                        if (!string.IsNullOrEmpty(model.userLastName))
                            userPrincipal.Surname = model.userLastName;

                        if (!string.IsNullOrEmpty(model.userFirstName))
                            userPrincipal.GivenName = model.userFirstName;

                        if (!string.IsNullOrEmpty(model.userCRMDisplayName))
                            userPrincipal.DisplayName = model.userCRMDisplayName;

                        if (!string.IsNullOrEmpty(model.userSamAccountName))
                        {
                            userPrincipal.SamAccountName = model.userSamAccountName;
                            userPrincipal.UserPrincipalName = model.userSamAccountName + "@ncri.local";
                        }
                        if (!string.IsNullOrEmpty(model.userEmail))
                        {
                            userPrincipal.EmailAddress = model.userEmail;
                        }

                        var pwdOfNewlyCreatedUser = "Changeme@123";
                        userPrincipal.SetPassword(pwdOfNewlyCreatedUser);
                        userPrincipal.Enabled = true;
                        userPrincipal.ExpirePasswordNow();
                        try
                        {
                            userPrincipal.Save();
                        }
                        catch (Exception e)
                        {
                            toReturn.remarks = e.ToString();
                            toReturn.resultCode = "1000";
                        }
                        if (string.IsNullOrEmpty(toReturn.resultCode))
                        {
                            using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                            {
                                var newUser = new User()
                                {
                                    contactable = 0,
                                    status = !String.IsNullOrEmpty(model.status)? model.status:"Active",
                                    Session = 0,
                                    username = model.userCRMDisplayName,
                                    name = model.userFirstName + " " + model.userLastName,
                                    password = new InnerHelpers().MD5Hash("Changeme@123"),
                                    phone = !string.IsNullOrEmpty(model.phone)?model.phone:"",
                                    Supervisor = !string.IsNullOrEmpty(model.superVisor)?model.superVisor:"",
                                    email = !string.IsNullOrEmpty(model.userEmail) ? model.userEmail : "",
                                    type = int.Parse(model.type)

                                };
                                AccessButtonsResponseModel responseModel = new AccessButtonsResponseModel();
                                AccessRights access = new AccessRights();
                                if (model.type == "1")
                                {
                                    responseModel = access.AdminAccess();
                                }
                                if (model.type == "2")
                                {
                                    responseModel = access.CollectorAccess();
                                }
                                if (model.type == "3")
                                {
                                    responseModel = access.ManagerAccess();
                                }
                                if (model.type == "4")
                                {
                                    responseModel = access.SeniorManagerAccess();
                                }
                                if (model.type == "5")
                                {
                                    responseModel = access.DataEntryOperatorAccess();
                                }
                                newUser.access_btn_1 = int.Parse(responseModel.button1);
                                newUser.access_btn_2 = int.Parse(responseModel.button2);
                                newUser.access_btn_3 = int.Parse(responseModel.button3);
                                newUser.access_btn_4 = int.Parse(responseModel.button4);
                                newUser.access_btn_5 = int.Parse(responseModel.button5);
                                newUser.access_btn_6 = int.Parse(responseModel.button6);
                                newUser.access_btn_7 = int.Parse(responseModel.button7);
                                newUser.access_btn_8 = int.Parse(responseModel.button8);
                                newUser.access_btn_9 = int.Parse(responseModel.button9);
                                newUser.access_btn_10 = int.Parse(responseModel.button10);
                                newUser.access_btn_11 = int.Parse(responseModel.button11);
                                newUser.access_btn_12 = int.Parse(responseModel.button12);
                                newUser.access_btn_13 = int.Parse(responseModel.button13);
                                newUser.access_btn_14 = int.Parse(responseModel.button14);
                                newUser.access_btn_15 = int.Parse(responseModel.button15);
                                newUser.access_btn_16 = int.Parse(responseModel.button16);
                                newUser.access_btn_17 = int.Parse(responseModel.button17);
                                newUser.access_btn_18 = int.Parse(responseModel.button18);
                                newUser.access_btn_19 = int.Parse(responseModel.button19);
                                newUser.access_btn_20 = int.Parse(responseModel.button20);
                                db.Users.Add(newUser);
                                db.SaveChanges();

                            }
                            toReturn = new UserResponseModel()
                            {
                                remarks = "Success",
                                resultCode = "1100"
                            };
                        }
                    }
                    else
                    {
                        toReturn = new UserResponseModel()
                        {
                            remarks = "Already Exists",
                            resultCode = "1400"
                        };
                    }
                }

                
            }
            catch (Exception Ex)
            {
                toReturn = new UserResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public UserResponseModel UpdateUser(UserRequestModel model)
        {
            UserResponseModel toReturn = new UserResponseModel();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var userId = int.Parse(model.userId);
                    var User = db.Users.Where(x => x.id == userId).FirstOrDefault();
                    if (User != null)
                    {
                        User.status = !string.IsNullOrEmpty(model.status) ? model.status : User.status;
                        User.username = !string.IsNullOrEmpty(model.userCRMDisplayName) ? model.userCRMDisplayName : User.username;
                        User.name = !string.IsNullOrEmpty(model.userFirstName) ? model.userFirstName : User.name;
                        User.password = !string.IsNullOrEmpty(model.userPassword) ? new InnerHelpers().MD5Hash(model.userPassword) : User.password;
                        User.phone = !string.IsNullOrEmpty(model.phone) ? model.phone : User.phone;
                        User.Supervisor = !string.IsNullOrEmpty(model.superVisor) ? model.superVisor : User.Supervisor;
                        User.email = !string.IsNullOrEmpty(model.userEmail) ? model.userEmail : User.email;
                        AccessButtonsResponseModel responseModel = new AccessButtonsResponseModel();
                        AccessRights access = new AccessRights();
                        if (model.type == "1")
                        {
                            responseModel = access.AdminAccess();
                        }
                        if (model.type == "2")
                        {
                            responseModel = access.CollectorAccess();
                        }
                        if (model.type == "3")
                        {
                            responseModel = access.ManagerAccess();
                        }
                        if (model.type == "4")
                        {
                            responseModel = access.SeniorManagerAccess();
                        }
                        if (model.type == "5")
                        {
                            responseModel = access.DataEntryOperatorAccess();
                        }
                        User.access_btn_1 = int.Parse(responseModel.button1);
                        User.access_btn_2 = int.Parse(responseModel.button2);
                        User.access_btn_3 = int.Parse(responseModel.button3);
                        User.access_btn_4 = int.Parse(responseModel.button4);
                        User.access_btn_5 = int.Parse(responseModel.button5);
                        User.access_btn_6 = int.Parse(responseModel.button6);
                        User.access_btn_7 = int.Parse(responseModel.button7);
                        User.access_btn_8 = int.Parse(responseModel.button8);
                        User.access_btn_9 = int.Parse(responseModel.button9);
                        User.access_btn_10 = int.Parse(responseModel.button10);
                        User.access_btn_11 = int.Parse(responseModel.button11);
                        User.access_btn_12 = int.Parse(responseModel.button12);
                        User.access_btn_13 = int.Parse(responseModel.button13);
                        User.access_btn_14 = int.Parse(responseModel.button14);
                        User.access_btn_15 = int.Parse(responseModel.button15);
                        User.access_btn_16 = int.Parse(responseModel.button16);
                        User.access_btn_17 = int.Parse(responseModel.button17);
                        User.access_btn_18 = int.Parse(responseModel.button18);
                        User.access_btn_19 = int.Parse(responseModel.button19);
                        User.access_btn_20 = int.Parse(responseModel.button20);
                        db.SaveChanges();
                        toReturn = new UserResponseModel()
                        {
                            remarks = "Success",
                            resultCode = "1100"
                        };
                    }
                    else
                    {
                        toReturn = new UserResponseModel()
                        {
                            remarks = "No Record Found",
                            resultCode = "1200"
                        };
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new UserResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public UserResponseModel DeleteUser(UserRequestModel model)
        {
            UserResponseModel toReturn = new UserResponseModel();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var userId = int.Parse(model.userId);
                    var User = db.Users.Where(x => x.id == userId).FirstOrDefault();
                    if (User != null)
                    {

                        db.Users.Remove(User);
                        db.SaveChanges();
                        toReturn = new UserResponseModel()
                        {
                            remarks = "Success",
                            resultCode = "1100"
                        };
                    }
                    else
                    {
                        toReturn = new UserResponseModel()
                        {
                            remarks = "No Record Found",
                            resultCode = "1200"
                        };
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new UserResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
    }
}