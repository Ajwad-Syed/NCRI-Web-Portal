using LinqKit;
using NCRI_WEBPORTALFORMISC.Models.AllocationsDataModels;
using NCRI_WEBPORTALFORMISC.Models.DBMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Helpers.ManagementHelpers
{
    public class AllocationsHelpers
    {
        public UpdateAllocationsResponseModel UpdateCollectorAllocationsWithAccountNo(UpdateAllocationsRequestModel model)
        {
            UpdateAllocationsResponseModel toReturn = new UpdateAllocationsResponseModel();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    if (!string.IsNullOrEmpty(model.AccountNos))
                    {
                        if (!string.IsNullOrEmpty(model.CollectorName))
                        {
                            var accountNos = model.AccountNos.Split('\n');
                            foreach (var accountNo in accountNos)
                            {
                                var allocation = db.Customers.Where(x => x.Account_No_ == accountNo).FirstOrDefault();

                                if (allocation != null)
                                {
                                    allocation.Collectorname = model.CollectorName;
                                    db.SaveChanges();
                                }
                                toReturn = new UpdateAllocationsResponseModel()
                                {
                                    resultCode = "1100",
                                    remarks = "Succuss"
                                };
                            }
                        }
                        else
                        {
                            toReturn = new UpdateAllocationsResponseModel()
                            {
                                resultCode = "1300",
                                remarks = "Please Provide Collectors Name"
                            };
                        }
                    }
                    else
                    {
                        toReturn = new UpdateAllocationsResponseModel()
                        {
                            remarks = "Please Provide Account Nos",
                            resultCode = "1300"
                        };
                    }



                }
            }
            catch(Exception Ex)
            {
                toReturn = new UpdateAllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public UpdateAllocationsResponseModel UpdateAccountWithId(UpdateAccountRequestModel model)
        {
            UpdateAllocationsResponseModel toReturn = new UpdateAllocationsResponseModel();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    if (!string.IsNullOrEmpty(model.id))
                    {
                        int accountId = int.Parse(model.id);
                        if (!string.IsNullOrEmpty(model.caseId))
                        {
                            var allocation = db.Customers.Where(x => x.id == accountId).FirstOrDefault();
                            if (allocation != null)
                            {
                                allocation.Customer_Name = !string.IsNullOrEmpty(model.customerName) ? model.customerName : allocation.Customer_Name;
                                allocation.CaseId = model.caseId;
                                db.SaveChanges();
                            }
                            toReturn = new UpdateAllocationsResponseModel()
                            {
                                resultCode = "1100",
                                remarks = "Succuss"
                            };

                        }
                        else
                        {
                            toReturn = new UpdateAllocationsResponseModel()
                            {
                                resultCode = "1300",
                                remarks = "Please Provide Collectors Name"
                            };
                        }
                    }
                    else
                    {
                        toReturn = new UpdateAllocationsResponseModel()
                        {
                            remarks = "Please Provide Account Nos",
                            resultCode = "1300"
                        };
                    }



                }
            }
            catch (Exception Ex)
            {
                toReturn = new UpdateAllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public UpdateAllocationsResponseModel UpdateAccountsAsWithdrawnWithAccountNo(WithdrawAccountRequestModel model)
        {
            UpdateAllocationsResponseModel toReturn = new UpdateAllocationsResponseModel();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    if (!string.IsNullOrEmpty(model.AccountNos))
                    {
                        if (!string.IsNullOrEmpty(model.Status))
                        {
                            var accountNos = model.AccountNos.Split('\n');
                            foreach (var accountNo in accountNos)
                            {
                                var account = db.Customers.Where(x => x.Account_No_ == accountNo).FirstOrDefault();

                                if (account != null)
                                {
                                    account.Status = model.Status;
                                    db.SaveChanges();
                                }
                                toReturn = new UpdateAllocationsResponseModel()
                                {
                                    resultCode = "1100",
                                    remarks = "Succuss"
                                };
                            }
                        }
                        else
                        {
                            toReturn = new UpdateAllocationsResponseModel()
                            {
                                resultCode = "1300",
                                remarks = "Please Provide Collectors Name"
                            };
                        }
                    }
                    else
                    {
                        toReturn = new UpdateAllocationsResponseModel()
                        {
                            remarks = "Please Provide Account Nos",
                            resultCode = "1300"
                        };
                    }



                }
            }
            catch (Exception Ex)
            {
                toReturn = new UpdateAllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public UpdateAllocationsResponseModel UpdateCollectorAllocationsWithCIF(UpdateAllocationsRequestModel model)
        {
            UpdateAllocationsResponseModel toReturn = new UpdateAllocationsResponseModel();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    if (!string.IsNullOrEmpty(model.CIFS))
                    {
                        if (!string.IsNullOrEmpty(model.CollectorName))
                        {
                            var CIFS = model.CIFS.Split('\n');
                            foreach (var CIF in CIFS)
                            {
                                var allocations = db.Customers.Where(x => x.CIF == CIF).ToList();
                                if (allocations.Count() > 0)
                                {
                                    foreach (var allocation in allocations)
                                    {
                                        if (allocation != null)
                                        {
                                            allocation.Collectorname = model.CollectorName;
                                            db.SaveChanges();
                                        }
                                    }
                                }
                                toReturn = new UpdateAllocationsResponseModel()
                                {
                                    resultCode = "1100",
                                    remarks = "Succuss"
                                };
                            }
                        }
                        else
                        {
                            toReturn = new UpdateAllocationsResponseModel()
                            {
                                resultCode = "1300",
                                remarks = "Please Provide Collectors Name"
                            };
                        }
                    }
                    else
                    {
                        toReturn = new UpdateAllocationsResponseModel()
                        {
                            remarks = "Please Provide CIFS",
                            resultCode = "1300"
                        };
                    }



                }
            }
            catch (Exception Ex)
            {
                toReturn = new UpdateAllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public List<AllocationsResponseModel> GetActiveAllocationsWithRespectOfBank(AllocationsRequestModel Model)
        {
            List<AllocationsResponseModel> toReturn = new List<AllocationsResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var RequestQuery = db.Customers.Where(x => x.Status == "Active").AsQueryable();
                    var predicate = PredicateBuilder.New<Customer>();
                    if (!string.IsNullOrEmpty(Model.BankName))
                    {
                        predicate = predicate.And(x => x.Bankname.Contains(Model.BankName));

                        if (!string.IsNullOrEmpty(Model.AccountNo))
                        {
                            var AccountNos = Model.AccountNo.Split('\n');
                            predicate = predicate.And(x => !AccountNos.Contains(x.Account_No_));
                        }
                        if (!string.IsNullOrEmpty(Model.Outstanding))
                        {
                            if (!string.IsNullOrEmpty(Model.Operation))
                            {
                                var outstanding = double.Parse(Model.Outstanding);
                                if (Model.Operation == ">")
                                {
                                    predicate = predicate.And(x => x.Cur_Os > outstanding);
                                }
                                else
                                {
                                    predicate = predicate.And(x => x.Cur_Os < outstanding);
                                }
                            }
                        }
                        var allocations = RequestQuery.Where(predicate).Select(x => new { x.CIF, x.Account_No_, x.Customer_Name, x.Collectorname, x.Status, x.Cur_Os }).ToList();
                        if (allocations.Count() > 0)
                        {
                            toReturn = allocations.Select(x => new AllocationsResponseModel()
                            {
                                AccountNo = x.Account_No_,
                                CIF = x.CIF,
                                AccountStatus = x.Status,
                                CollectorName = x.Collectorname,
                                CustomerName = x.Customer_Name,
                                Outstandings = x.Cur_Os.ToString(),
                                remarks = "Success",
                                resultCode = "1100"
                            }).ToList();
                        }
                        else
                        {
                            toReturn = new List<AllocationsResponseModel>();
                            toReturn.Add(new AllocationsResponseModel()
                            {
                                remarks = "No Record",
                                resultCode = "1200"
                            });
                        }
                    }
                    else
                    {
                        toReturn = new List<AllocationsResponseModel>();
                        toReturn.Add(new AllocationsResponseModel()
                        {
                            remarks = "Please Provide Bank Name",
                            resultCode = "1300"
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<AllocationsResponseModel>();
                toReturn.Add(new AllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        } 
        public List<AllocationsResponseModel> GetActiveAllocations(AllocationsRequestModel Model)
        {
            List<AllocationsResponseModel> toReturn = new List<AllocationsResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var RequestQuery = db.Customers.Where(x => x.Status == "Active").AsQueryable();
                    var predicate = PredicateBuilder.New<Customer>(); 
                    if (!string.IsNullOrEmpty(Model.Outstanding))
                    {
                        if (!string.IsNullOrEmpty(Model.Operation))
                        {
                            var outstanding = double.Parse(Model.Outstanding);
                            if (Model.Operation == ">")
                            {
                                predicate = predicate.And(x => x.Cur_Os >= outstanding);
                            }
                            else
                            {
                                predicate = predicate.And(x => x.Cur_Os <= outstanding);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(Model.LastUpdateDate))
                    {
                        var lastUdated = DateTime.Parse(Model.LastUpdateDate);
                        predicate = predicate.And(x => x.dateCreated >= lastUdated);
                    }
                    var allocations = RequestQuery.Where(predicate).Select(x => new {x.id,x.CaseId, x.CIF, x.Account_No_, x.Customer_Name, x.Collectorname, x.Status, x.Cur_Os }).ToList();
                    if (allocations.Count() > 0)
                    {
                        toReturn = allocations.Select(x => new AllocationsResponseModel()
                        {
                            id= x.id.ToString(),
                            AccountNo = x.Account_No_,
                            CIF = x.CIF,
                            AccountStatus = x.Status,
                            CollectorName = x.Collectorname,
                            CustomerName = x.Customer_Name,
                            Outstandings = x.Cur_Os.ToString(),
                            remarks = "Success",
                            resultCode = "1100"
                        }).ToList();
                    }
                    else
                    {
                        toReturn = new List<AllocationsResponseModel>();
                        toReturn.Add(new AllocationsResponseModel()
                        {
                            remarks = "No Record",
                            resultCode = "1200"
                        });
                    }
                  
                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<AllocationsResponseModel>();
                toReturn.Add(new AllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
        public List<AllocationsResponseModel> GetDupliacteCaseIdsAllocationsFromBankName(AllocationsRequestModel Model)
        {
            List<AllocationsResponseModel> toReturn = new List<AllocationsResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var RequestQuery = db.Customers.AsQueryable();
                    var predicate = PredicateBuilder.New<Customer>();
                    predicate = predicate.And(x => x.Status == "Active");
                    if (!string.IsNullOrEmpty(Model.AccountNo))
                    {
                        var AccountNos = Model.AccountNo.Split('\n');
                        predicate = predicate.And(x => AccountNos.Contains(x.Account_No_));
                    }
                    if (!string.IsNullOrEmpty(Model.CollectorName))
                    {
                        var CollectorNames = Model.CollectorName.Split('\n');
                        predicate = predicate.And(x => CollectorNames.Contains(x.Collectorname));
                    }
                    if (!string.IsNullOrEmpty(Model.CIF))
                    {
                        var CIFS = Model.CIF.Split('\n');
                        predicate = predicate.And(x => CIFS.Contains(x.CIF));
                    }
                    if (!string.IsNullOrEmpty(Model.BankName))
                    {
                        predicate = predicate.And(x => x.Bankname.Contains(Model.BankName));
                    }
                    var allocations = RequestQuery.Where(predicate).Select(x => new { x.id, x.CIF, x.Account_No_, x.Customer_Name, x.Collectorname, x.Status, x.CaseId }).ToList();
                    if (allocations.Count() > 0)
                    {
                        var response = allocations.Select(x => new AllocationsResponseModel()
                        {
                            AccountNo = x.Account_No_,
                            CIF = x.CIF,
                            AccountStatus = x.Status,
                            id = x.id.ToString(),
                            caseId = x.CaseId,
                            CollectorName = x.Collectorname,
                            CustomerName = x.Customer_Name,
                            remarks = "Success",
                            resultCode = "1100"
                        }).ToList();
                        foreach (var x in response)
                        {
                            var duplicatevalues = (from val in response where val.caseId == x.caseId select val).ToList();
                            if (duplicatevalues.Count() > 1)
                            {
                                foreach (var y in duplicatevalues)
                                {
                                    toReturn.Add(y);
                                }
                            }
                        }
                        toReturn = toReturn.Distinct().ToList();
                        if (toReturn.Count() == 0)
                        {
                            toReturn = new List<AllocationsResponseModel>();
                            toReturn.Add(new AllocationsResponseModel()
                            {
                                remarks = "No Record",
                                resultCode = "1200"
                            });
                        }
                    }
                    else
                    {
                        toReturn = new List<AllocationsResponseModel>();
                        toReturn.Add(new AllocationsResponseModel()
                        {
                            remarks = "No Record",
                            resultCode = "1200"
                        });
                    }


                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<AllocationsResponseModel>();
                toReturn.Add(new AllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
        public List<AllocationsResponseModel> SortAllocationsOnBasisOfNew(AllocationsRequestModel Model)
        {
            List<AllocationsResponseModel> toReturn = new List<AllocationsResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var RequestQuery = db.Customers.AsQueryable();
                    var predicate = PredicateBuilder.New<Customer>();
                    if (!string.IsNullOrEmpty(Model.BankName))
                    {
                        predicate = predicate.And(x => x.Bankname.Contains(Model.BankName));

                        if (!string.IsNullOrEmpty(Model.AccountNo))
                        {
                            var AccountNos = Model.AccountNo.Split('\n');
                            predicate = predicate.And(x => AccountNos.Contains(x.Account_No_));
                            var newAccounts = new List<String>();
                            var toBeUpdateAllocations = RequestQuery.Where(predicate).Select(x => new { x.Account_No_ }).ToList();
                            foreach (var accountNo in AccountNos)
                            {
                                if (toBeUpdateAllocations.Where(x => x.Account_No_ == accountNo).FirstOrDefault() == null)
                                {
                                    newAccounts.Add(accountNo);
                                }
                            }
                            if (newAccounts.Count() > 0)
                            {
                                toReturn = newAccounts.Select(x => new AllocationsResponseModel()
                                {
                                    AccountNo = x,
                                    remarks = "Success",
                                    resultCode = "1100"
                                }).ToList();
                            }
                            else
                            {
                                toReturn = new List<AllocationsResponseModel>();
                                toReturn.Add(new AllocationsResponseModel()
                                {
                                    remarks = "No Record",
                                    resultCode = "1200"
                                });
                            }
                        }
                        else
                        {
                            toReturn = new List<AllocationsResponseModel>();
                            toReturn.Add(new AllocationsResponseModel()
                            {
                                remarks = "Please Provide Account Nos",
                                resultCode = "1300"
                            });
                        }
                    }
                    else
                    {
                        toReturn = new List<AllocationsResponseModel>();
                        toReturn.Add(new AllocationsResponseModel()
                        {
                            remarks = "Please Provide Bank Name",
                            resultCode = "1300"
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<AllocationsResponseModel>();
                toReturn.Add(new AllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
        public List<AllocationsResponseModel> SortAllocationsOnBasisOfOld(AllocationsRequestModel Model)
        {
            List<AllocationsResponseModel> toReturn = new List<AllocationsResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var RequestQuery = db.Customers.AsQueryable();
                    var predicate = PredicateBuilder.New<Customer>();
                    if (!string.IsNullOrEmpty(Model.BankName))
                    {
                        predicate = predicate.And(x => x.Bankname.Contains(Model.BankName));

                        if (!string.IsNullOrEmpty(Model.AccountNo))
                        {
                            var AccountNos = Model.AccountNo.Split('\n');
                            predicate = predicate.And(x => AccountNos.Contains(x.Account_No_));
                            var toBeUpdateAllocations = RequestQuery.Where(predicate).Select(x => new { x.Account_No_, x.CIF, x.Collectorname, x.Status, x.Customer_Name }).ToList();

                            if (toBeUpdateAllocations.Count() > 0)
                            {
                                toReturn = toBeUpdateAllocations.Select(x => new AllocationsResponseModel()
                                {
                                    AccountNo = x.Account_No_,
                                    AccountStatus = x.Status,
                                    CIF = x.CIF,
                                    CollectorName = x.Collectorname,
                                    CustomerName = x.Customer_Name,
                                    remarks = "Success",
                                    resultCode = "1100"
                                }).ToList();
                            }
                            else
                            {
                                toReturn = new List<AllocationsResponseModel>();
                                toReturn.Add(new AllocationsResponseModel()
                                {
                                    remarks = "No Record",
                                    resultCode = "1200"
                                });
                            }
                        }
                        else
                        {
                            toReturn = new List<AllocationsResponseModel>();
                            toReturn.Add(new AllocationsResponseModel()
                            {
                                remarks = "Please Provide Account Nos",
                                resultCode = "1300"
                            });
                        }
                    }
                    else
                    {
                        toReturn = new List<AllocationsResponseModel>();
                        toReturn.Add(new AllocationsResponseModel()
                        {
                            remarks = "Please Provide Bank Name",
                            resultCode = "1300"
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<AllocationsResponseModel>();
                toReturn.Add(new AllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
        public List<AllocationsResponseModel> GetAllocations(AllocationsRequestModel Model)
        {
            List<AllocationsResponseModel> toReturn = new List<AllocationsResponseModel>();
            try
            {
                using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                {
                    var RequestQuery = db.Customers.AsQueryable();
                    var predicate = PredicateBuilder.New<Customer>();
                    if (!string.IsNullOrEmpty(Model.AccountNo))
                    {
                        var AccountNos = Model.AccountNo.Split('\n');                       
                        predicate = predicate.And(x => AccountNos.Contains(x.Account_No_));                       
                    }
                    if (!string.IsNullOrEmpty(Model.CollectorName))
                    {
                        var CollectorNames = Model.CollectorName.Split('\n');
                        predicate = predicate.And(x => CollectorNames.Contains( x.Collectorname ));
                    }
                    if (!string.IsNullOrEmpty(Model.CIF))
                    {
                        var CIFS = Model.CIF.Split('\n');
                        predicate = predicate.And(x => CIFS.Contains(x.CIF));
                    }                    
                    var allocations = RequestQuery.Where(predicate).Select(x => new { x.CIF, x.Account_No_, x.Customer_Name, x.Collectorname,x.Status }).ToList();
                    if (allocations.Count() > 0)
                    {
                        toReturn = allocations.Select(x => new AllocationsResponseModel()
                        {
                            AccountNo = x.Account_No_,
                            CIF = x.CIF,
                            CollectorName = x.Collectorname,
                            CustomerName = x.Customer_Name,
                            AccountStatus= x.Status,
                            remarks = "Success",
                            resultCode = "1100"
                        }).ToList();
                    }
                    else
                    {
                        toReturn = new List<AllocationsResponseModel>();
                        toReturn.Add(new AllocationsResponseModel()
                        {
                            remarks = "No Record",
                            resultCode = "1200"
                        });
                    }


                }
            }
            catch (Exception Ex)
            {
                toReturn = new List<AllocationsResponseModel>();
                toReturn.Add(new AllocationsResponseModel()
                {
                    remarks = "There Was A Fatal Error " + Ex.ToString(),
                    resultCode = "1000"
                });
            }
            return toReturn;
        }
    }
}