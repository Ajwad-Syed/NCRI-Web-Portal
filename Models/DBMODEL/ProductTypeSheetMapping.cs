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
    
    public partial class ProductTypeSheetMapping
    {
        public int Id { get; set; }
        public string ProductMappingName { get; set; }
        public string SheetMappingName { get; set; }
        public string BankName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}