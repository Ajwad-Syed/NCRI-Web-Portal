using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using NCRI_WEBPORTALFORMISC.Models.DBMODEL;
using System.Text;
using System.Web;
using NCRI_WEBPORTALFORMISC.Models;
using System.Net.Http;
using FluentEmail.MailKitSmtp;
using System.Configuration;
using FluentEmail.Core;
using NCRI_WEBPORTALFORMISC.Models.CommunicationDataModels;

namespace NCRI_WEBPORTALFORMISC.Helpers.OtherInnerHelpers
{
    public class InnerHelpers
    {
        public string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash((new UTF8Encoding()).GetBytes(input));
            for (int i = 0; i < (int)bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public string Decrypto(string text)
        {
            try
            {

                var hashmd5 = new MD5CryptoServiceProvider();
                byte[] toEncryptArray = Convert.FromBase64String(text);

                byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(text));

                hashmd5.Clear();
                TripleDESCryptoServiceProvider TripleDesProvider = new TripleDESCryptoServiceProvider();
                TripleDesProvider.Key = keyArray;
                TripleDesProvider.Mode = CipherMode.ECB;
                TripleDesProvider.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = TripleDesProvider.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                TripleDesProvider.Clear();

                return Encoding.UTF8.GetString(resultArray);
                //return Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception Ex)
            {
                return string.Empty;
            }
        }
        public CommunicationsResponseModel SendSMSThroughTestApi(string id)
        {
            var toReturn = new CommunicationsResponseModel();
            try
            {               
                if (!string.IsNullOrEmpty(id))
                {
                    int customerId = int.Parse(id);
                    using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                    {
                        var customer = db.Customers.Where(x => x.id == customerId).FirstOrDefault();
                        if (customer != null)
                        {
                            string urlParameters = "?hash=5453be47a415a508ea48044bacd1cb5e&receivenum=03455990367&sendernum=8583&textmessage=Hello Anwar Ali From NCRI Pakistan";
                            //StringBuilder Message = new StringBuilder("Dear Mr  your liability for against Bank  is pending");
                            //Message.Replace("$Customer_Name", customer.Customer_Name);
                            //Message.Replace("$Current_OS", Math.Ceiling(customer.Cur_Os.Value).ToString());
                            //Message.Replace("$Bankname", customer.Bankname);
                            //StringBuilder urlParameters = new StringBuilder("?hash=5453be47a415a508ea48044bacd1cb5e&receivenum=03119995125&sendernum=8583&textmessage=Hello Anwar Ali From NCRI Pakistan");
                            //urlParameters.Replace("$Message", Message.ToString());
                            //urlParameters.Replace("$PhoneNo", "03455990367");
                            var smsApi = "http://api.veevotech.com/sendsms";
                            HttpClient client = new HttpClient();
                            client.BaseAddress = new Uri(smsApi);
                            // Add an Accept header for JSON format.                  
                            var requestString = urlParameters.ToString();
                            // List data response.
                            HttpResponseMessage response = client.GetAsync(requestString).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                            if (response.IsSuccessStatusCode)
                            {
                                return toReturn = new CommunicationsResponseModel()
                                {
                                    remarks = "Success",
                                    resultCode = "1100"
                                };

                            }
                            else
                            {
                                return toReturn = new CommunicationsResponseModel()
                                {
                                    remarks = "Not Sent",
                                    resultCode = "1400"
                                };
                            }
                          
                        }
                        else
                        {
                            return toReturn = new CommunicationsResponseModel()
                            {
                                remarks = "No Record",
                                resultCode = "1200"
                            };
                        }
                    } 
                }
                else
                {
                    return toReturn = new CommunicationsResponseModel()
                    {
                        remarks = "Missing",
                        resultCode = "1300"
                    }; ;
                }
            }
            catch (Exception Ex)
            {
                return toReturn = new CommunicationsResponseModel()
                {
                    remarks = "Fatal Error "+Ex.ToString(),
                    resultCode = "1000"
                };
            }
        }
        public CommunicationsResponseModel SendSMSThroughJazzApi(string id)
        {
            var toReturn = new CommunicationsResponseModel();
            try
            {               
                if (!string.IsNullOrEmpty(id))
                {
                    int customerId = int.Parse(id);
                    using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                    {
                        var customer = db.Customers.Where(x => x.id == customerId).FirstOrDefault();
                        if (customer != null)
                        {
                            string urlParameters = "?Username=03018232593&Password=G4Zc6iiG&From=NCRI&To=03455990367&Message=Hello NCRI";
                            var smsApi = "https://connect.jazzcmt.com/sendsms_url.html";
                            HttpClient client = new HttpClient();
                            client.BaseAddress = new Uri(smsApi);
                            // Add an Accept header for JSON format.                  
                            var requestString = urlParameters.ToString();
                            // List data response.
                            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                            if (response.IsSuccessStatusCode)
                            {
                                return toReturn = new CommunicationsResponseModel()
                                {
                                    remarks = "Success",
                                    resultCode = "1100"
                                };

                            }
                            else
                            {
                                return toReturn = new CommunicationsResponseModel()
                                {
                                    remarks = "Not Sent",
                                    resultCode = "1400"
                                };
                            }
                          
                        }
                        else
                        {
                            return toReturn = new CommunicationsResponseModel()
                            {
                                remarks = "No Record",
                                resultCode = "1200"
                            };
                        }
                    } 
                }
                else
                {
                    return toReturn = new CommunicationsResponseModel()
                    {
                        remarks = "Missing",
                        resultCode = "1300"
                    }; ;
                }
            }
            catch (Exception Ex)
            {
                return toReturn = new CommunicationsResponseModel()
                {
                    remarks = "Fatal Error "+Ex.ToString(),
                    resultCode = "1000"
                };
            }
        }
        public CommunicationsResponseModel SendEmail(string id)
        {
            CommunicationsResponseModel toReturn = new CommunicationsResponseModel();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    int customerId = int.Parse(id);
                    using (ACC_ACCOUNTEntities db = new ACC_ACCOUNTEntities())
                    {
                        var customer = db.Customers.Where(x => x.id == customerId).FirstOrDefault();
                        if (customer != null)
                        {
                            var smtpOptions = new OtherInnerHelpers.ConnectionSettings().GetSettings();
                            MailKitSender sender = new MailKitSender(smtpOptions.options);
                            var toAddress = "musabinshabeer@gmail.com";
                            StringBuilder Message = new StringBuilder("Dear Mr. $Customer_Name, your liability for AED $Current_OS against Bank $Bankname is pending. Please clear your dues or ignore if already paid");
                            Message.Replace("$Customer_Name", customer.Customer_Name);
                            Message.Replace("$Current_OS", Math.Ceiling(customer.Cur_Os.Value).ToString());
                            Message.Replace("$Bankname", customer.Bankname);
                            var email = Email
                              //Sender
                              .From(smtpOptions.options.User)
                              //Addressee
                              .To(toAddress)
                              //CC to
                              //Message title
                              .Subject("Alert:Loan Return Reminder")
                              //Email content
                              .Body(Message.ToString() + " "+DateTime.Now);
                            var result = sender.Send(email);

                            if (result.Successful)
                            {
                                toReturn = new CommunicationsResponseModel()
                                {
                                    remarks = "SuccessFully Sent",
                                    resultCode = "1100"
                                };
                            }
                            else
                            {
                                toReturn = new CommunicationsResponseModel()
                                {
                                    remarks = "Error",
                                    resultCode = "1000"
                                };

                            }
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                toReturn = new CommunicationsResponseModel()
                {
                    remarks = "There Was A Fatal Error" + Ex,
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
        public CommunicationsResponseModel SendEmail(string Body,string subject, string to)
        {
            CommunicationsResponseModel toReturn = new CommunicationsResponseModel();
            try
            {
                var smtpOptions = new OtherInnerHelpers.ConnectionSettings().GetSettings();
                MailKitSender sender = new MailKitSender(smtpOptions.options);
                var toAddress = to;                          
                var email = Email
                    //Sender
                    .From(smtpOptions.options.User)
                    //Addressee
                    .To(toAddress)
                    //CC to
                    //Message title
                    .Subject(subject)
                    //Email content
                    .Body(Body + " "+DateTime.Now);
                var result = sender.Send(email);

                if (result.Successful)
                {
                    toReturn = new CommunicationsResponseModel()
                    {
                        remarks = "SuccessFully Sent",
                        resultCode = "1100"
                    };
                }
                else
                {
                    toReturn = new CommunicationsResponseModel()
                    {
                        remarks = "Error",
                        resultCode = "1000"
                    };

                }
                   
              

            }
            catch (Exception Ex)
            {
                toReturn = new CommunicationsResponseModel()
                {
                    remarks = "There Was A Fatal Error" + Ex,
                    resultCode = "1000"
                };
            }
            return toReturn;
        }
    }
}