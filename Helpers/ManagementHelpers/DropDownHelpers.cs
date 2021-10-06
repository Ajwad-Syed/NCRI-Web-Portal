
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCRI_WEBPORTALFORMISC.Models.DBMODEL;
using NCRI_WEBPORTALFORMISC.Models.UserDataModel;
using NCRI_WEBPORTALFORMISC.Models.BankDataModels;

namespace NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers
{
    public class DropDownHelpers
    {
       
        #region User
        public List<UserDropDownResponseModel> GetAllFieldUsers()
        {
            List<UserDropDownResponseModel> toReturn = new List<UserDropDownResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var CollectorsId = new List<int>();
                    CollectorsId.Add(13);
                    CollectorsId.Add(15);
                    CollectorsId.Add(18);
                    CollectorsId.Add(1085);
                    CollectorsId.Add(1066);
                    CollectorsId.Add(1051);
                    CollectorsId.Add(3131);
                    CollectorsId.Add(3136);
                    CollectorsId.Add(3149);
                    CollectorsId.Add(3126);
                    CollectorsId.Add(3128);
                    var contactCodes = db.Users.Where(x=>CollectorsId.Contains(x.id)).ToList();
                    if (contactCodes.Count() > 0)
                    {
                        toReturn = contactCodes.Select(x => new UserDropDownResponseModel()
                        {
                            userId = x.id.ToString(),
                            userName = x.name,
                            remarks = "Success",
                            resultCode = "1100"
                        }).ToList();
                    }
                    else
                    {
                        toReturn = new List<UserDropDownResponseModel>();
                        toReturn.Add(new UserDropDownResponseModel()
                        {
                            remarks = "No Record",
                            resultCode = "1200"
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<UserDropDownResponseModel>();
                toReturn.Add(new UserDropDownResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                }
                );
            }
            return toReturn;
        }
        public List<BankResponseModel> GetUniqueBankCodes()
        {
            List<BankResponseModel> toReturn = new List<BankResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var bankCodes = db.BankCodes.Select(x => x.bankName).Distinct().ToList();
                    if (bankCodes.Count() > 0)
                    {
                        toReturn = bankCodes.Select(x => new BankResponseModel()
                        {
                            bankName = x,
                            remarks = "Success",
                            resultCode = "1100"
                        }).ToList();
                    }
                    else
                    {
                        toReturn = new List<BankResponseModel>();
                        toReturn.Add(new BankResponseModel()
                        {
                            remarks = "No Record",
                            resultCode = "1200"
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<BankResponseModel>();
                toReturn.Add(new BankResponseModel()
                {
                    remarks = "There Was Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
        #endregion

    }
}