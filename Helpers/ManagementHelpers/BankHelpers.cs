using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCRI_WEBPORTALFORMISC.Models.BankDataModels;
using NCRI_WEBPORTALFORMISC.Models.DBMODEL;

namespace NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers
{
    public class BankHelpers
    {
        public List<BankCodesResponseModel> GetAllBankCodes ()
        {
            List< BankCodesResponseModel> toReturn = new List<BankCodesResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var bankCodes = db.BankCodes.ToList();
                    if (bankCodes.Count() > 0)
                    {
                        toReturn = bankCodes.Select(x => new BankCodesResponseModel()
                        {
                            bankCodeId = x.id.ToString(),
                            bankName = x.bankName,
                            bankremarks = x.remarks,
                            code = x.code,
                            companyCodes = x.company_codes,
                            contactStatus = x.contact_status,
                            subType = x.subType,
                            remarks= "Success",
                            resultCode="1100"
                        }).ToList();
                    }
                    else
                    {
                        toReturn = new List<BankCodesResponseModel>();
                        toReturn.Add(new BankCodesResponseModel()
                        {
                            remarks = "No Record",
                            resultCode = "1200"
                        });
                    }
                }
            }
            catch(Exception Ex)
            {
                toReturn = new List<BankCodesResponseModel>();
                toReturn.Add(new BankCodesResponseModel()
                {
                    remarks = "There Was Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
        public BankCodesResponseModel AddNewBankCode(BankCodesRequestModel model)
        {
            BankCodesResponseModel toReturn = new BankCodesResponseModel();
            try
            {
                using (ACC_ACCOUNTEntities db= new ACC_ACCOUNTEntities())
                {
                    var newBank = new BankCode()
                    {
                        code = !string.IsNullOrEmpty(model.code)?model.code:"",
                        company_codes = !string.IsNullOrEmpty(model.companyCodes)?model.companyCodes:"",
                        contact_status = !string.IsNullOrEmpty(model.contactStatus)?model.contactStatus:"",
                        bankName = !string.IsNullOrEmpty(model.bankName)?model.bankName:"",
                        remarks = !string.IsNullOrEmpty(model.bankremarks)?model.bankremarks:"",
                        subType = !string.IsNullOrEmpty(model.subType)?model.subType:"",
                    };
                    db.BankCodes.Add(newBank);
                    db.SaveChanges();
                    toReturn = new BankCodesResponseModel()
                    {
                        remarks = "Success",
                        resultCode = "1100"
                    };
                }
            }
            catch(Exception Ex)
            {
                toReturn = new BankCodesResponseModel()
                {
                    remarks = "There Was A Fatal Error" + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public BankCodesResponseModel UpdateBankCode(BankCodesRequestModel model)
        {
            BankCodesResponseModel toReturn = new BankCodesResponseModel();
            try
            {
                if (model.bankCodeId != null)
                {
                    using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                    {
                        var _bankCode = db.BankCodes.Where(x => x.id == model.bankCodeId).FirstOrDefault();
                        _bankCode.code = !string.IsNullOrEmpty(model.code) ? model.code : "";
                        _bankCode.company_codes = !string.IsNullOrEmpty(model.companyCodes) ? model.companyCodes : "";
                        _bankCode.contact_status = !string.IsNullOrEmpty(model.contactStatus) ? model.contactStatus : "";
                        _bankCode.bankName = !string.IsNullOrEmpty(model.bankName) ? model.bankName : "";
                        _bankCode.remarks = !string.IsNullOrEmpty(model.bankremarks) ? model.bankremarks : "";
                        _bankCode.subType = !string.IsNullOrEmpty(model.subType) ? model.subType : "";
                        db.SaveChanges();
                        toReturn = new BankCodesResponseModel()
                        {
                            remarks = "Success",
                            resultCode = "1100"
                        };
                    } 
                }
                else
                {
                    toReturn = new BankCodesResponseModel()
                    {
                        remarks = "No Record",
                        resultCode = "1200"
                    };
                }
            }
            catch(Exception Ex)
            {
                toReturn = new BankCodesResponseModel()
                {
                    remarks = "There Was A Fatal Error" + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public BankCodesResponseModel DeleteBankCode(BankCodesRequestModel model)
        {
            BankCodesResponseModel toReturn = new BankCodesResponseModel();
            try
            {
                if (model.bankCodeId != null)
                {
                    using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                    {
                        var _bankCode = db.BankCodes.Where(x => x.id == model.bankCodeId).FirstOrDefault();
                        db.BankCodes.Remove(_bankCode);
                        db.SaveChanges();
                        toReturn = new BankCodesResponseModel()
                        {
                            remarks = "Success",
                            resultCode = "1100"
                        };
                    } 
                }
                else
                {
                    toReturn = new BankCodesResponseModel()
                    {
                        remarks = "No Record",
                        resultCode = "1200"
                    };
                }
            }
            catch(Exception Ex)
            {
                toReturn = new BankCodesResponseModel()
                {
                    remarks = "There Was A Fatal Error" + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
    }
}