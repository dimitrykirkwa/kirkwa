//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEPernits
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_DEPermitsDenormalized
    {
        public int DEPermits_HistoryID { get; set; }
        public string BUSNum { get; set; }
        public string DEPermitNumberV { get; set; }
        public int EmplID { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string DEP_DL { get; set; }
        public string DEP_DLSTATE { get; set; }
        public string CarName { get; set; }
        public string Plate { get; set; }
        public string PlateState { get; set; }
        public string Color { get; set; }
        public Nullable<int> CarYear { get; set; }
        public string Notes { get; set; }
        public System.DateTime DEP_APPDATE { get; set; }
        public Nullable<System.DateTime> DEP_RENEWDATE { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public bool Terminated { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
    }
}
