//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NCRI_WEBPORTALFORMISC.Models.DBMODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class field_visit
    {
        public int id { get; set; }
        public string caseId { get; set; }
        public Nullable<System.DateTime> daterequested { get; set; }
        public string collector { get; set; }
        public string request_status { get; set; }
        public Nullable<int> field_visit_officer { get; set; }
        public int isSync { get; set; }
    }
}
