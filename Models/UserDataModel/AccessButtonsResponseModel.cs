using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCRI_WEBPORTALFORMISC.Models.UserDataModel
{
    public class AccessButtonsResponseModel
    {
        public string button1 { get; set; }
        public string button2 { get; set; }
        public string button3 { get; set; }
        public string button4 { get; set; }
        public string button5 { get; set; }
        public string button6 { get; set; }
        public string button7 { get; set; }
        public string button8 { get; set; }
        public string button9 { get; set; }
        public string button10 { get; set; }
        public string button11 { get; set; }
        public string button12 { get; set; }
        public string button13 { get; set; }
        public string button14 { get; set; }
        public string button15 { get; set; }
        public string button16 { get; set; }
        public string button17 { get; set; }
        public string button18 { get; set; }
        public string button19 { get; set; }
        public string button20 { get; set; }

    }
    public class AccessRights
    {
        public AccessButtonsResponseModel AdminAccess()
        {
            AccessButtonsResponseModel adminaccess = new AccessButtonsResponseModel()
            {
                button1 = "1",
                button2 = "1",
                button3 = "1",
                button4 = "1",
                button5 = "1",
                button6 = "1",
                button7 = "1",
                button8 = "1",
                button9 = "1",
                button10 = "1",
                button11 = "1",
                button12 = "1",
                button13 = "1",
                button14 = "1",
                button15 = "1",
                button16 = "1",
                button17 = "1",
                button18 = "1",
                button19 = "1",
                button20 = "1",
            };
            return adminaccess;

        }
        public AccessButtonsResponseModel CollectorAccess()
        {
            AccessButtonsResponseModel adminaccess = new AccessButtonsResponseModel()
            {
                button1 = "1",
                button2 = "1",
                button3 = "0",
                button4 = "0",
                button5 = "0",
                button6 = "0",
                button7 = "0",
                button8 = "0",
                button9 = "0",
                button10 = "1",
                button11 = "0",
                button12 = "0",
                button13 = "0",
                button14 = "0",
                button15 = "0",
                button16 = "0",
                button17 = "0",
                button18 = "0",
                button19 = "0",
                button20 = "0",
            };
            return adminaccess;

        }
        public AccessButtonsResponseModel ManagerAccess()
        {
            AccessButtonsResponseModel adminaccess = new AccessButtonsResponseModel()
            {
                button1 = "1",
                button2 = "1",
                button3 = "1",
                button4 = "0",
                button5 = "0",
                button6 = "0",
                button7 = "1",
                button8 = "0",
                button9 = "0",
                button10 = "0",
                button11 = "0",
                button12 = "0",
                button13 = "1",
                button14 = "1",
                button15 = "0",
                button16 = "0",
                button17 = "0",
                button18 = "0",
                button19 = "0",
                button20 = "0",
            };
            return adminaccess;

        }
        public AccessButtonsResponseModel SeniorManagerAccess()
        {
            AccessButtonsResponseModel adminaccess = new AccessButtonsResponseModel()
            {
                button1 = "1",
                button2 = "1",
                button3 = "1",
                button4 = "1",
                button5 = "1",
                button6 = "1",
                button7 = "1",
                button8 = "1",
                button9 = "1",
                button10 = "1",
                button11 = "1",
                button12 = "1",
                button13 = "1",
                button14 = "1",
                button15 = "1",
                button16 = "1",
                button17 = "1",
                button18 = "1",
                button19 = "1",
                button20 = "1",
            };
            return adminaccess;

        }
        public AccessButtonsResponseModel DataEntryOperatorAccess()
        {
            AccessButtonsResponseModel adminaccess = new AccessButtonsResponseModel()
            {
                button1 = "1",
                button2 = "0",
                button3 = "0",
                button4 = "1",
                button5 = "0",
                button6 = "0",
                button7 = "0",
                button8 = "0",
                button9 = "0",
                button10 = "1",
                button11 = "0",
                button12 = "0",
                button13 = "0",
                button14 = "0",
                button15 = "0",
                button16 = "1",
                button17 = "1",
                button18 = "1",
                button19 = "0",
                button20 = "0",
            };
            return adminaccess;

        }
    }
}